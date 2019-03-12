using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace DDigit.ImageProcessor
{
  unsafe public class FastBitmap : IDisposable
  {
    public FastBitmap(Bitmap workingBitmap)
    {
      WorkingBitmap = workingBitmap;
    }

    public void LockImage()
    {
      var bounds = new Rectangle(Point.Empty, WorkingBitmap.Size);

      width = bounds.Width * sizeof(PixelData);
      if (width % 4 != 0)
      {
        width = 4 * (width / 4 + 1);
      }

      //Lock Image
      bitmapData = WorkingBitmap.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      pBase = (Byte*)bitmapData.Scan0.ToPointer();
    }

    public void UnlockImage()
    {
      WorkingBitmap.UnlockBits(bitmapData);
      bitmapData = null;
      pBase = null;
    }

    public Color GetPixel(int x, int y)
    {
      var pixelData = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
      return Color.FromArgb(pixelData->alpha, pixelData->red, pixelData->green, pixelData->blue);
    }

    public void SetPixel(int x, int y, Color color)
    {
      PixelData* data = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
      data->alpha = color.A;
      data->red = color.R;
      data->green = color.G;
      data->blue = color.B;
    }

    public Bitmap WorkingBitmap { get; set; }
    public int Width => WorkingBitmap != null ? WorkingBitmap.Width : 0;
    public int Height => WorkingBitmap != null ? WorkingBitmap.Height : 0;

    public void Dispose()
    {

    }

    int width = 0;
    BitmapData bitmapData = null;
    byte* pBase = null;
  }
}
