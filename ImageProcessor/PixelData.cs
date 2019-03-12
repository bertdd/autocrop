namespace DDigit.ImageProcessor
{
  public struct PixelData
  {
    public byte blue;
    public byte green;
    public byte red;
    public byte alpha;

    public override string ToString() => $"({alpha}, {red}, {green}, {blue})";
  }
}


