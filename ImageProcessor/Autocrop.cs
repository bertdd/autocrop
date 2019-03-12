using System;
using System.Collections.Generic;
using System.Drawing;

namespace DDigit.ImageProcessor
{
  public class Autocrop : Cropper, IDisposable
  {
    public Rectangle DetectEdges(Bitmap source)
    {
      var fastSource = new FastBitmap(source);
      fastSource.LockImage();

      var (X, Width) = DetectVerticalLines(fastSource);
      var (Y, Height) = DetectHorizontalLines(fastSource);

      fastSource.UnlockImage();

      if (Width > 0 && Height > 0)
      {
        Width -= 8;
        X += 4;
        Height -= 8;
        Y += 4;
        var rectangle = new Rectangle(X, Y, Width, Height);
        RectangleDetected?.Invoke(this, new RectangleEventArgs(rectangle));
        return rectangle;
      }
      return Rectangle.Empty;
    }

    void DrawSquare(FastBitmap source, int x, int y, int width, int height)
    {
      for (int py = 0; py < height; py++)
      {
        for (int px = 0; px < width; px++)
        {
          source.SetPixel(x + px, y + py, Color.Blue);
        }
      }
    }

    (int X, int Width) DetectVerticalLines(FastBitmap source)
    {
      bool line = false;
      int thickness = 0;
      int startX = 0;
      int X = 0;
      int Width = 0;
      for (int x = 0; x < source.Width; x++)
      {
        if (DetectVerticalLine(source, x))
        {
          if (!line)
          {
            startX = x;
          }
          thickness++;
          line = true;
        }
        else
        {
          if (line && thickness > Width)
          {
            (X, Width) = (startX, thickness);
          }
          (line, thickness) = (false, 0);
        }
      }
      if (line & thickness > Width)
      {
        (X, Width) = (startX, thickness);
      }
      return (X, Width);
    }

    (int Y, int Height) DetectHorizontalLines(FastBitmap source)
    {
      bool line = false;
      int thickness = 0;
      int startY = 0;
      int Y = 0;
      int Height = 0;
      for (int y = 0; y < source.Height; y++)
      {
        if (DetectHorizontalLine(source, y))
        {
          if (!line)
          {
            startY = y;
          }
          thickness++;
          line = true;
        }
        else
        {
          if (line && thickness > Height)
          {
            (Y, Height) = (startY, thickness);

          }
          (line, thickness) = (false, 0);
        }
      }
      if (line & thickness > Height)
      {
        (Y, Height) = (startY, thickness);
      }
      return (Y, Height);
    }

    bool IsLine(int pixels, int count) => (double)count / pixels > LinePercentage;

    bool DetectHorizontalLine(FastBitmap source, int y)
    {
      int count = 0;

      for (int x = 0; x < source.Width; x++)
      {
        if (!Compare(source.GetPixel(x, y), Color.Green))
        {
          count++;
        }
      }
      return IsLine(source.Width, count);
    }

    bool DetectVerticalLine(FastBitmap source, int x)
    {
      int count = 0;

      for (int y = 0; y < source.Height; y++)
      {
        if (!Compare(source.GetPixel(x, y), Color.Green))
        {
          count++;
        }
      }
      return IsLine(source.Height, count);
    }

    double ColorDistance(Color a, Color b) => Math.Sqrt(Math.Pow((a.R - b.R), 2) + Math.Pow((a.G - b.G), 2) + Math.Pow((a.B - b.B), 2));

    (Color minColor, Color maxColor) DetermineBackground(FastBitmap bitmap)
    {
      var samples = new List<Color>();

      if (Sides.HasFlag(SidesEnum.Top))
      {
        samples.Add(DetermineTopBackgroundColor(bitmap));
      }
      if (Sides.HasFlag(SidesEnum.Bottom))
      {
        samples.Add(DetermineBottomBackgroundColor(bitmap));
      }
      if (Sides.HasFlag(SidesEnum.Left))
      {
        samples.Add(DetermineLeftBackgroundColor(bitmap));
      }
      if (Sides.HasFlag(SidesEnum.Right))
      {
        samples.Add(DetermineRightBackgroundColor(bitmap));
      }

      foreach (var i in CheckColorDistances(samples))
      {
        samples.Remove(i);
      }

      return (MinColor(samples), MaxColor(samples));
    }

    public List<Color> CheckColorDistances(List<Color> samples)
    {
      var removables = new List<Color>();
      var ignoredSamples = new List<int>();
      double average;
      for (int index = 0; index < samples.Count; index++)
      {
        average = 0.0;
        foreach (var sample in samples)
        {
          average += removables.Contains(sample) ? 0 : ColorDistance(samples[index], sample);
        }
        if (average / (samples.Count - 1) > 5)
        {
          removables.Add(samples[index]);
          ignoredSamples.Add(index);
        }
      }

      BackGroundDetected?.Invoke(this, new SidesIgnoreEventArgs(ignoredSamples));
      return removables;
    }

    public Bitmap FilterBackGround(Bitmap source)
    {
      if (source == null)
      {
        throw new ArgumentNullException("source");
      }

      // create a fast bitmap based on the original and lock it
      var image = new FastBitmap(source);
      image.LockImage();

      // create result image and the fast version, lock the fast version
      var resultImage = new Bitmap(source.Width, source.Height);
      var fastFilteredImage = new FastBitmap(resultImage);
      fastFilteredImage.LockImage();

      // determine the backgorund color of the image
      (Color minColor, Color maxColor) = DetermineBackground(image);

      for (int y = 0; y < source.Height; y++)
      {
        for (int x = 0; x < source.Width; x++)
        {
          fastFilteredImage.SetPixel(x, y, IsBackGroundColor(image.GetPixel(x, y), minColor, maxColor) ? Color.Green : Color.White);
        }
      }

      image.UnlockImage();
      fastFilteredImage.UnlockImage();

      return resultImage;
    }

    (List<byte> r, List<byte> g, List<byte> b) SplitChannels(IEnumerable<Color> colors)
    {
      var red = new List<byte>();
      var green = new List<byte>();
      var blue = new List<byte>();
      foreach (Color c in colors)
      {
        red.Add(c.R);
        green.Add(c.G);
        blue.Add(c.B);
      }
      return (red, green, blue);
    }

    Color MinColor(IEnumerable<Color> colors)
    {
      var (red, green, blue) = SplitChannels(colors);

      var R = Math.Max(0, MinValue(red) - 10);
      var G = Math.Max(0, MinValue(green) - 10);
      var B = Math.Max(0, MinValue(blue) - 10);

      return Color.FromArgb(R, G, B);
    }

    Color MaxColor(IEnumerable<Color> colors)
    {
      var (red, green, blue) = SplitChannels(colors);

      var R = Math.Min(255, MaxValue(red) + 10);
      var G = Math.Min(255, MaxValue(green) + 10);
      var B = Math.Min(255, MaxValue(blue) + 10);

      return Color.FromArgb(R, G, B);
    }

    byte MinValue(IEnumerable<byte> v)
    {
      var result = byte.MaxValue;
      foreach (var i in v)
      {
        if (i < result)
        {
          result = i;
        }
      }
      return result;
    }

    byte MaxValue(IEnumerable<byte> v)
    {
      var result = byte.MinValue;
      foreach (var i in v)
      {
        if (i > result)
        {
          result = i;
        }
      }
      return result;
    }

    public Color DetermineTopBackgroundColor(FastBitmap bitmap)
    {
      long red = 0, green = 0, blue = 0;

      int samples = 0;
      for (int y = 0; y < 8 && y < bitmap.Height; y++)
      {
        for (int x = 0; x < bitmap.Width; x++)
        {
          var pixel = bitmap.GetPixel(x, y);
          if (!(IgnoreBlackAndWhiteBackground && (IsBlack(pixel) || IsWhite(pixel))))
          {
            samples++;
            red += pixel.R;
            green += pixel.G;
            blue += pixel.B;
          }
        }
      }
      var c = AverageColor(red, green, blue, samples);
      TopBackgroundDetected?.Invoke(this, new ColorEventArgs(c));
      return c;
    }

    public Color DetermineBottomBackgroundColor(FastBitmap bitmap)
    {
      long red = 0, green = 0, blue = 0;

      int samples = 0;
      for (int y = bitmap.Height - 8 - 1; y >= 0 && y < bitmap.Height; y++)
      {
        for (int x = 0; x < bitmap.Width; x++)
        {
          var pixel = bitmap.GetPixel(x, y);
          if (!(IgnoreBlackAndWhiteBackground && (IsBlack(pixel) || IsWhite(pixel))))
          {
            samples++;
            red += pixel.R;
            green += pixel.G;
            blue += pixel.B;
          }
        }
      }
      var c = AverageColor(red, green, blue, samples);
      BottomBackgroundDetected?.Invoke(this, new ColorEventArgs(c));
      return c;
    }

    public Color DetermineLeftBackgroundColor(FastBitmap bitmap)
    {
      long red = 0, green = 0, blue = 0;

      int samples = 0;
      for (int y = 0; y < bitmap.Height; y++)
      {
        for (int x = 0; x < 8 && x < bitmap.Width; x++)
        {
          var pixel = bitmap.GetPixel(x, y);
          if (!(IgnoreBlackAndWhiteBackground && (IsBlack(pixel) || IsWhite(pixel))))
          {
            samples++;
            red += pixel.R;
            green += pixel.G;
            blue += pixel.B;
          }
        }
      }
      var c = AverageColor(red, green, blue, samples);
      LeftBackgroundDetected?.Invoke(this, new ColorEventArgs(c));
      return c;
    }

    public Color DetermineRightBackgroundColor(FastBitmap bitmap)
    {
      long red = 0, green = 0, Blue = 0;

      int samples = 0;
      for (int y = 0; y < bitmap.Height; y++)
      {
        for (int x = bitmap.Width - 8 - 1; x >= 0 && x < bitmap.Width; x++)
        {
          var pixel = bitmap.GetPixel(x, y);
          if (!(IgnoreBlackAndWhiteBackground && (IsBlack(pixel) || IsWhite(pixel))))
          {
            samples++;
            red += pixel.R;
            green += pixel.G;
            Blue += pixel.B;
          }
        }
      }
      var c = AverageColor(red, green, Blue, samples);
      RightBackgroundDetected?.Invoke(this, new ColorEventArgs(c));
      return c;
    }

    Color AverageColor(long r, long g, long b, int samples) => samples > 0 ? Color.FromArgb((int)(r / samples), (int)(g / samples), (int)(b / samples)) : Color.Black;
    bool IsBackGroundColor(Color pixel, Color minColor, Color maxColor) =>
    pixel.R >= minColor.R && pixel.R <= maxColor.R && pixel.G >= minColor.G && pixel.G <= maxColor.G && pixel.B >= minColor.B && pixel.B <= maxColor.B;



    public void Dispose()
    {

    }

    public event EventHandler<ColorEventArgs> TopBackgroundDetected;
    public event EventHandler<ColorEventArgs> BottomBackgroundDetected;
    public event EventHandler<ColorEventArgs> LeftBackgroundDetected;
    public event EventHandler<ColorEventArgs> RightBackgroundDetected;
    public event EventHandler<SidesIgnoreEventArgs> BackGroundDetected;

    public event EventHandler<RectangleEventArgs> RectangleDetected;
    public bool IgnoreBlackAndWhiteBackground;

    public SidesEnum Sides { get; set; } = SidesEnum.Bottom | SidesEnum.Left | SidesEnum.Right | SidesEnum.Top;
    public double LinePercentage { get; set; } = 0.25;
  }
}
