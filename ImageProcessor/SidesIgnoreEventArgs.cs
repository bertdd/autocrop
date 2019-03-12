using System;
using System.Collections.Generic;

namespace DDigit.ImageProcessor
{
  public class SidesIgnoreEventArgs : EventArgs
  {
    public SidesIgnoreEventArgs(List<int> ignored)
    {
      I = ignored;
    }

    public List<int> I;
  }
}