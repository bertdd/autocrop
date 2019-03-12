using DDigit.ImageProcessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoCrop
{
  public partial class AutoCropForm : Form
  {
    public AutoCropForm()
    {
      InitializeComponent();
      autoCrop.FileNameChanged += (sender, e) => fileNameStatusLabel.Text = (sender as Cropper).FileName;

      autoCrop.ImageLoaded += (sender, e) =>
      {
        var model = sender as Cropper;
        pictureBox.Image = model.ImageData;
        sizeLabel.Text = $"{model.ImageWidth} x {model.ImageHeight}";
        detectButton.Enabled = true;
      };

      autoCrop.TopBackgroundDetected += (o, e) => SetColor(topBackgroundPanel, e.C);
      autoCrop.BottomBackgroundDetected += (o, e) => SetColor(bottomBackgroundPanel, e.C);
      autoCrop.LeftBackgroundDetected += (o, e) => SetColor(leftBackgroundPanel, e.C);
      autoCrop.RightBackgroundDetected += (o, e) => SetColor(rightBackgroundPanel, e.C);

      autoCrop.BackGroundDetected += (o, e) =>
      {
        Invoke(new ShowColorDistanceDelegate(ShowColorDistance), new object[] { e.I });
      };
    }

    delegate void SetColorDelegate(Panel panel, Color color);
    void SetPanelColor(Panel p, Color c) => p.BackColor = c;

    void SetColor(Panel p, Color c)
    {
      Invoke(new SetColorDelegate(SetPanelColor), new object[] { p, c });
    }

    delegate void ShowColorDistanceDelegate(List<int> sides);

    void ShowColorDistance(List<int> ingoredSides)
    {
      if (ingoredSides.Contains(0)) { topBackgroundPanel.BackColor = Color.Black; }
      if (ingoredSides.Contains(1)) { bottomBackgroundPanel.BackColor = Color.Black; }
      if (ingoredSides.Contains(2)) { leftBackgroundPanel.BackColor = Color.Black; }
      if (ingoredSides.Contains(3)) { rightBackgroundPanel.BackColor = Color.Black; }

      if (topBackgroundPanel.BackColor != Color.Black)
      {
        if (leftBackgroundPanel.BackColor != Color.Black)
        {
          topLeftLabel.Text = ColorDistance(topBackgroundPanel.BackColor, leftBackgroundPanel.BackColor).ToString("F1");
        }
        if (bottomBackgroundPanel.BackColor != Color.Black)
        {
          topMiddleLabel.Text = ColorDistance(topBackgroundPanel.BackColor, bottomBackgroundPanel.BackColor).ToString("F1");
        }
        if (rightBackgroundPanel.BackColor != Color.Black)
        {
          topRightLabel.Text = ColorDistance(topBackgroundPanel.BackColor, rightBackgroundPanel.BackColor).ToString("F1");
        }
      }

      if (bottomBackgroundPanel.BackColor != Color.Black)
      { 
        if (leftBackgroundPanel.BackColor != Color.Black)
        {
          bottomLeftLabel.Text = ColorDistance(bottomBackgroundPanel.BackColor, leftBackgroundPanel.BackColor).ToString("F1");
        }
        if (topBackgroundPanel.BackColor != Color.Black)
        {
          bottomMiddleLabel.Text = ColorDistance(leftBackgroundPanel.BackColor, rightBackgroundPanel.BackColor).ToString("F1");
        }
        if (rightBackgroundPanel.BackColor != Color.Black)
        {
          bottomRightLabel.Text = ColorDistance(bottomBackgroundPanel.BackColor, rightBackgroundPanel.BackColor).ToString("F1");
        }
      }
    }


    double ColorDistance(Color a, Color b) => Math.Sqrt(Math.Pow((a.R - b.R), 2) + Math.Pow((a.G - b.G), 2) + Math.Pow((a.B - b.B), 2));

    void ExitMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    void OpenMenuItem_Click(object sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        autoCrop.LoadFile(openFileDialog.FileName);
      }
    }

    Autocrop autoCrop = new Autocrop();

    async void DetectButton_Click(object sender, EventArgs e)
    {
      // filter the background
      filterPictureBox.Image = await Task.Run(() => autoCrop.FilterBackGround(autoCrop.ImageData as Bitmap));

      // detect the edges of the cropping area.
      var rectangle = autoCrop.DetectEdges(filterPictureBox.Image as Bitmap);

      // show the result if we have one
      if (!rectangle.IsEmpty)
      {
        resultPictureBox.Image = autoCrop.TryCrop(autoCrop.ImageData as Bitmap, rectangle);
        saveMenuItem.Enabled = true;
      }

      infoLabel.Text = $"{rectangle.Width} x {rectangle.Height}";
    }

    void AutoCropForm_Load(object sender, EventArgs e)
    {
      Width = 1600;
      Height = 800;
      infoLabel.Text = string.Empty;
    }

    void TopBackgroundPanel_Click(object sender, EventArgs e) =>
      SetSide(sender as Panel, (SidesEnum.Bottom | SidesEnum.Right | SidesEnum.Left), SidesEnum.Top, ref savedTopColor);

    void RightBackgroundPanel_Click(object sender, EventArgs e) =>
      SetSide(sender as Panel, (SidesEnum.Bottom | SidesEnum.Left | SidesEnum.Top), SidesEnum.Right, ref savedRightColor);

    void LeftBackgroundPanel_Click(object sender, EventArgs e) =>
      SetSide(sender as Panel, (SidesEnum.Bottom | SidesEnum.Right | SidesEnum.Top), SidesEnum.Left, ref savedLeftColor);

    void BottomBackgroundPanel_Click(object sender, EventArgs e) =>
      SetSide(sender as Panel, (SidesEnum.Top | SidesEnum.Right | SidesEnum.Left), SidesEnum.Bottom, ref savedBottomColor);

    void SetSide(Panel panel, SidesEnum currentSides, SidesEnum side, ref Color savedColor)
    {
      if (panel.BackColor != Color.Black)
      {
        autoCrop.Sides &= currentSides;
        savedColor = panel.BackColor;
        panel.BackColor = Color.Black;
      }
      else
      {
        autoCrop.Sides |= side;
        panel.BackColor = savedColor;
      }
    }

    Color savedRightColor;
    Color savedTopColor;
    Color savedLeftColor;
    Color savedBottomColor;

    void SaveMenuItem_Click(object sender, EventArgs e)
    {
      saveFileDialog.ShowDialog();
    }

    void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
    {
      
    }

    void SaveFileDialog_FileOk(object sender, CancelEventArgs e)
    {
      var dialog = sender as SaveFileDialog;
      var image = resultPictureBox.Image;
      image.Save(dialog.FileName, ImageFormat.Jpeg);
    }
  }
}
