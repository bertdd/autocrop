namespace autoCrop
{
  partial class AutoCropForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.fileNameStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.sizeLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.detectButton = new System.Windows.Forms.Button();
      this.resultPictureBox = new System.Windows.Forms.PictureBox();
      this.filterPictureBox = new System.Windows.Forms.PictureBox();
      this.infoLabel = new System.Windows.Forms.Label();
      this.backgroundPanel = new System.Windows.Forms.Panel();
      this.rightBackgroundPanel = new System.Windows.Forms.Panel();
      this.leftBackgroundPanel = new System.Windows.Forms.Panel();
      this.bottomBackgroundPanel = new System.Windows.Forms.Panel();
      this.bottomMiddleLabel = new System.Windows.Forms.Label();
      this.bottomRightLabel = new System.Windows.Forms.Label();
      this.bottomLeftLabel = new System.Windows.Forms.Label();
      this.topBackgroundPanel = new System.Windows.Forms.Panel();
      this.topRightLabel = new System.Windows.Forms.Label();
      this.topMiddleLabel = new System.Windows.Forms.Label();
      this.topLeftLabel = new System.Windows.Forms.Label();
      this.OriginalImageLabel = new System.Windows.Forms.Label();
      this.detectedBackgroundLabel = new System.Windows.Forms.Label();
      this.ResultImageLabel = new System.Windows.Forms.Label();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.menuStrip1.SuspendLayout();
      this.statusStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.filterPictureBox)).BeginInit();
      this.backgroundPanel.SuspendLayout();
      this.bottomBackgroundPanel.SuspendLayout();
      this.topBackgroundPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(2160, 33);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.saveMenuItem,
            this.ExitMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // openMenuItem
      // 
      this.openMenuItem.Name = "openMenuItem";
      this.openMenuItem.Size = new System.Drawing.Size(140, 30);
      this.openMenuItem.Text = "&Open";
      this.openMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
      // 
      // saveMenuItem
      // 
      this.saveMenuItem.Enabled = false;
      this.saveMenuItem.Name = "saveMenuItem";
      this.saveMenuItem.Size = new System.Drawing.Size(140, 30);
      this.saveMenuItem.Text = "&Save";
      this.saveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
      // 
      // ExitMenuItem
      // 
      this.ExitMenuItem.Name = "ExitMenuItem";
      this.ExitMenuItem.Size = new System.Drawing.Size(140, 30);
      this.ExitMenuItem.Text = "E&xit";
      this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.Filter = "Tif files | *.tif";
      this.openFileDialog.Title = "Open image file";
      this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
      // 
      // statusStrip
      // 
      this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNameStatusLabel,
            this.sizeLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 1079);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(2160, 22);
      this.statusStrip.TabIndex = 1;
      this.statusStrip.Text = "statusStrip1";
      // 
      // fileNameStatusLabel
      // 
      this.fileNameStatusLabel.Name = "fileNameStatusLabel";
      this.fileNameStatusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // sizeLabel
      // 
      this.sizeLabel.Name = "sizeLabel";
      this.sizeLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // pictureBox
      // 
      this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox.Location = new System.Drawing.Point(33, 58);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(690, 625);
      this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox.TabIndex = 2;
      this.pictureBox.TabStop = false;
      // 
      // detectButton
      // 
      this.detectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.detectButton.Enabled = false;
      this.detectButton.Location = new System.Drawing.Point(33, 992);
      this.detectButton.Name = "detectButton";
      this.detectButton.Size = new System.Drawing.Size(87, 50);
      this.detectButton.TabIndex = 3;
      this.detectButton.Text = "Detect";
      this.detectButton.UseVisualStyleBackColor = true;
      this.detectButton.Click += new System.EventHandler(this.DetectButton_Click);
      // 
      // resultPictureBox
      // 
      this.resultPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.resultPictureBox.Location = new System.Drawing.Point(1455, 58);
      this.resultPictureBox.Name = "resultPictureBox";
      this.resultPictureBox.Size = new System.Drawing.Size(690, 625);
      this.resultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.resultPictureBox.TabIndex = 4;
      this.resultPictureBox.TabStop = false;
      // 
      // filterPictureBox
      // 
      this.filterPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.filterPictureBox.Location = new System.Drawing.Point(744, 58);
      this.filterPictureBox.Name = "filterPictureBox";
      this.filterPictureBox.Size = new System.Drawing.Size(690, 625);
      this.filterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.filterPictureBox.TabIndex = 6;
      this.filterPictureBox.TabStop = false;
      // 
      // infoLabel
      // 
      this.infoLabel.AutoSize = true;
      this.infoLabel.Location = new System.Drawing.Point(1451, 697);
      this.infoLabel.Name = "infoLabel";
      this.infoLabel.Size = new System.Drawing.Size(51, 20);
      this.infoLabel.TabIndex = 7;
      this.infoLabel.Text = "label1";
      // 
      // backgroundPanel
      // 
      this.backgroundPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.backgroundPanel.Controls.Add(this.rightBackgroundPanel);
      this.backgroundPanel.Controls.Add(this.leftBackgroundPanel);
      this.backgroundPanel.Controls.Add(this.bottomBackgroundPanel);
      this.backgroundPanel.Controls.Add(this.topBackgroundPanel);
      this.backgroundPanel.Location = new System.Drawing.Point(228, 742);
      this.backgroundPanel.Name = "backgroundPanel";
      this.backgroundPanel.Size = new System.Drawing.Size(300, 300);
      this.backgroundPanel.TabIndex = 8;
      // 
      // rightBackgroundPanel
      // 
      this.rightBackgroundPanel.Dock = System.Windows.Forms.DockStyle.Right;
      this.rightBackgroundPanel.Location = new System.Drawing.Point(248, 50);
      this.rightBackgroundPanel.Name = "rightBackgroundPanel";
      this.rightBackgroundPanel.Size = new System.Drawing.Size(50, 198);
      this.rightBackgroundPanel.TabIndex = 3;
      this.rightBackgroundPanel.Click += new System.EventHandler(this.RightBackgroundPanel_Click);
      // 
      // leftBackgroundPanel
      // 
      this.leftBackgroundPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.leftBackgroundPanel.Location = new System.Drawing.Point(0, 50);
      this.leftBackgroundPanel.Name = "leftBackgroundPanel";
      this.leftBackgroundPanel.Size = new System.Drawing.Size(50, 198);
      this.leftBackgroundPanel.TabIndex = 2;
      this.leftBackgroundPanel.Click += new System.EventHandler(this.LeftBackgroundPanel_Click);
      // 
      // bottomBackgroundPanel
      // 
      this.bottomBackgroundPanel.Controls.Add(this.bottomMiddleLabel);
      this.bottomBackgroundPanel.Controls.Add(this.bottomRightLabel);
      this.bottomBackgroundPanel.Controls.Add(this.bottomLeftLabel);
      this.bottomBackgroundPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.bottomBackgroundPanel.Location = new System.Drawing.Point(0, 248);
      this.bottomBackgroundPanel.Name = "bottomBackgroundPanel";
      this.bottomBackgroundPanel.Size = new System.Drawing.Size(298, 50);
      this.bottomBackgroundPanel.TabIndex = 1;
      this.bottomBackgroundPanel.Click += new System.EventHandler(this.BottomBackgroundPanel_Click);
      // 
      // bottomMiddleLabel
      // 
      this.bottomMiddleLabel.AutoSize = true;
      this.bottomMiddleLabel.Location = new System.Drawing.Point(125, 8);
      this.bottomMiddleLabel.Name = "bottomMiddleLabel";
      this.bottomMiddleLabel.Size = new System.Drawing.Size(31, 20);
      this.bottomMiddleLabel.TabIndex = 4;
      this.bottomMiddleLabel.Text = "0.0";
      // 
      // bottomRightLabel
      // 
      this.bottomRightLabel.AutoSize = true;
      this.bottomRightLabel.Location = new System.Drawing.Point(246, 8);
      this.bottomRightLabel.Name = "bottomRightLabel";
      this.bottomRightLabel.Size = new System.Drawing.Size(31, 20);
      this.bottomRightLabel.TabIndex = 1;
      this.bottomRightLabel.Text = "0.0";
      // 
      // bottomLeftLabel
      // 
      this.bottomLeftLabel.AutoSize = true;
      this.bottomLeftLabel.Location = new System.Drawing.Point(3, 8);
      this.bottomLeftLabel.Name = "bottomLeftLabel";
      this.bottomLeftLabel.Size = new System.Drawing.Size(31, 20);
      this.bottomLeftLabel.TabIndex = 0;
      this.bottomLeftLabel.Text = "0.0";
      // 
      // topBackgroundPanel
      // 
      this.topBackgroundPanel.Controls.Add(this.topRightLabel);
      this.topBackgroundPanel.Controls.Add(this.topMiddleLabel);
      this.topBackgroundPanel.Controls.Add(this.topLeftLabel);
      this.topBackgroundPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topBackgroundPanel.Location = new System.Drawing.Point(0, 0);
      this.topBackgroundPanel.Name = "topBackgroundPanel";
      this.topBackgroundPanel.Size = new System.Drawing.Size(298, 50);
      this.topBackgroundPanel.TabIndex = 0;
      this.topBackgroundPanel.Click += new System.EventHandler(this.TopBackgroundPanel_Click);
      // 
      // topRightLabel
      // 
      this.topRightLabel.AutoSize = true;
      this.topRightLabel.Location = new System.Drawing.Point(246, 15);
      this.topRightLabel.Name = "topRightLabel";
      this.topRightLabel.Size = new System.Drawing.Size(31, 20);
      this.topRightLabel.TabIndex = 11;
      this.topRightLabel.Text = "0.0";
      this.topRightLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // topMiddleLabel
      // 
      this.topMiddleLabel.AutoSize = true;
      this.topMiddleLabel.Location = new System.Drawing.Point(125, 15);
      this.topMiddleLabel.Name = "topMiddleLabel";
      this.topMiddleLabel.Size = new System.Drawing.Size(31, 20);
      this.topMiddleLabel.TabIndex = 10;
      this.topMiddleLabel.Text = "0.0";
      this.topMiddleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // topLeftLabel
      // 
      this.topLeftLabel.AutoSize = true;
      this.topLeftLabel.Location = new System.Drawing.Point(3, 15);
      this.topLeftLabel.Name = "topLeftLabel";
      this.topLeftLabel.Size = new System.Drawing.Size(31, 20);
      this.topLeftLabel.TabIndex = 9;
      this.topLeftLabel.Text = "0.0";
      // 
      // OriginalImageLabel
      // 
      this.OriginalImageLabel.AutoSize = true;
      this.OriginalImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.OriginalImageLabel.Location = new System.Drawing.Point(286, 697);
      this.OriginalImageLabel.Name = "OriginalImageLabel";
      this.OriginalImageLabel.Size = new System.Drawing.Size(185, 29);
      this.OriginalImageLabel.TabIndex = 9;
      this.OriginalImageLabel.Text = "Original image";
      // 
      // detectedBackgroundLabel
      // 
      this.detectedBackgroundLabel.AutoSize = true;
      this.detectedBackgroundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.detectedBackgroundLabel.Location = new System.Drawing.Point(958, 697);
      this.detectedBackgroundLabel.Name = "detectedBackgroundLabel";
      this.detectedBackgroundLabel.Size = new System.Drawing.Size(262, 29);
      this.detectedBackgroundLabel.TabIndex = 10;
      this.detectedBackgroundLabel.Text = "Detected background";
      // 
      // ResultImageLabel
      // 
      this.ResultImageLabel.AutoSize = true;
      this.ResultImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ResultImageLabel.Location = new System.Drawing.Point(1757, 697);
      this.ResultImageLabel.Name = "ResultImageLabel";
      this.ResultImageLabel.Size = new System.Drawing.Size(87, 29);
      this.ResultImageLabel.TabIndex = 11;
      this.ResultImageLabel.Text = "Result";
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.DefaultExt = "jpg";
      this.saveFileDialog.Filter = "Jpeg files|*.jpg";
      this.saveFileDialog.Title = "Save file";
      this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog_FileOk);
      // 
      // AutoCropForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(2160, 1101);
      this.Controls.Add(this.ResultImageLabel);
      this.Controls.Add(this.detectedBackgroundLabel);
      this.Controls.Add(this.OriginalImageLabel);
      this.Controls.Add(this.backgroundPanel);
      this.Controls.Add(this.infoLabel);
      this.Controls.Add(this.filterPictureBox);
      this.Controls.Add(this.resultPictureBox);
      this.Controls.Add(this.detectButton);
      this.Controls.Add(this.pictureBox);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "AutoCropForm";
      this.Text = "Auto crop";
      this.Load += new System.EventHandler(this.AutoCropForm_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.filterPictureBox)).EndInit();
      this.backgroundPanel.ResumeLayout(false);
      this.bottomBackgroundPanel.ResumeLayout(false);
      this.bottomBackgroundPanel.PerformLayout();
      this.topBackgroundPanel.ResumeLayout(false);
      this.topBackgroundPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel fileNameStatusLabel;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.ToolStripStatusLabel sizeLabel;
    private System.Windows.Forms.Button detectButton;
    private System.Windows.Forms.PictureBox resultPictureBox;
    private System.Windows.Forms.PictureBox filterPictureBox;
    private System.Windows.Forms.Label infoLabel;
    private System.Windows.Forms.Panel backgroundPanel;
    private System.Windows.Forms.Panel topBackgroundPanel;
    private System.Windows.Forms.Panel bottomBackgroundPanel;
    private System.Windows.Forms.Panel leftBackgroundPanel;
    private System.Windows.Forms.Panel rightBackgroundPanel;
    private System.Windows.Forms.Label topLeftLabel;
    private System.Windows.Forms.Label topMiddleLabel;
    private System.Windows.Forms.Label topRightLabel;
    private System.Windows.Forms.Label bottomMiddleLabel;
    private System.Windows.Forms.Label bottomRightLabel;
    private System.Windows.Forms.Label bottomLeftLabel;
    private System.Windows.Forms.Label OriginalImageLabel;
    private System.Windows.Forms.Label detectedBackgroundLabel;
    private System.Windows.Forms.Label ResultImageLabel;
    private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
  }
}

