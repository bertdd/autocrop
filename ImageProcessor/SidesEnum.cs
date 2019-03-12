using System;

namespace DDigit.ImageProcessor
{
  [Flags]
  public enum SidesEnum
  {
    Top = 0x01,
    Right = 0x02,
    Bottom = 0x04,
    Left = 0x08
  }
}
