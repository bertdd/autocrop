using System;
using System.Drawing;

namespace DDigit.ImageProcessor
{
  public class RectangleEventArgs : EventArgs
  {
    public RectangleEventArgs(Rectangle rectangle )
    {
      R = rectangle;
    }

    public Rectangle R { get; private set; }
  }
}
