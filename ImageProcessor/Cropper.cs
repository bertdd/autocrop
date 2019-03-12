using System;
using System.Drawing;
using System.IO;

namespace DDigit.ImageProcessor
{
  abstract public class Cropper
  {
    public void LoadFile(string fileName)
    {
      if (ImageData != null)
      {
        ImageData.Dispose();
      }
      FileName = fileName;
      ImageData = Image.FromFile(fileName);
      ImageLoaded?.Invoke(this, EventArgs.Empty);
    }

    public Bitmap TryCrop(Bitmap bitmap, Rectangle rectangle)
    {
      Bitmap result = null;
      if (rectangle.Height > 0 && rectangle.Width > 0)
      {
        result = Crop(bitmap, rectangle);
      }
      return result;
    }

    Bitmap Crop(Bitmap source, Rectangle rectangle)
    {
      var fastSource = new FastBitmap(source);

      var croppedImage = new Bitmap(rectangle.Width, rectangle.Height);
      var fastCroppedImage = new FastBitmap(croppedImage);

      fastCroppedImage.LockImage();
      fastSource.LockImage();

      for (int y = rectangle.Y, startY = rectangle.Y, endY = rectangle.Y + rectangle.Height; y < endY; y++)
      {
        for (int x = rectangle.X, startX = rectangle.X, endX = rectangle.X + rectangle.Width; x < endX; x++)
        {
          var pixel = fastSource.GetPixel(x, y);
          fastCroppedImage.SetPixel(x - startX, y - startY, pixel);
        }
      }

      fastCroppedImage.UnlockImage();
      fastSource.UnlockImage();
      return croppedImage;
    }

    string fileName;
    public string FileName
    {
      get
      {
        return fileName;
      }
      set

      {
        if (value != fileName)
        {
          fileName = value;
          FileNameChanged?.Invoke(this, EventArgs.Empty);
        }
      }
    }

    public string Id
    {
      get
      {
        if (fileName != null)
        {
          var fileInfo = new FileInfo(fileName);
          if (fileInfo.Exists)
          {
            var extension = fileInfo.Extension;
            return fileInfo.Name.Substring(0, fileInfo.Name.Length - extension.Length);
          }
        }
        return null;
      }
    }

    public int ImageWidth => ImageData != null ? ImageData.Width : 0;
    public int ImageHeight => ImageData != null ? ImageData.Height : 0;

    protected int BlackThreshold = 50;
    protected bool IsBlack(Color color) => color.R < BlackThreshold & color.G < BlackThreshold && color.B < BlackThreshold;
    protected bool IsWhite(Color color) => color.R > 250 && color.G > 250 && color.B > 250;
    protected bool Compare(Color color1, Color color2) => color1.R == color2.R && color1.G == color2.G && color1.B == color2.B;

    public Image ImageData { get; set; }
    public event EventHandler<EventArgs> FileNameChanged;
    public event EventHandler<EventArgs> ImageLoaded;
  }
}
