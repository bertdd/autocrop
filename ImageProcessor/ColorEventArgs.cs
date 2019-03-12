using System;
using System.Drawing;

namespace DDigit.ImageProcessor
{
  public class ColorEventArgs : EventArgs
  {
    public ColorEventArgs(Color color)
    {
      C = color;
    }

    public Color C;
  }
}
