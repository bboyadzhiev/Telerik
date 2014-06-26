// 1. Refactor the following code to use proper variable naming and simplified expressions:
using System;
public class Fgure
{

    public class Size
    {
        public double width;
        public double height;
        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
    }

    public static Size GetRotatedSize(
      Size currentSize, double rotationAngle)
    {
        double cosRotationAngle = Math.Abs(Math.Cos(rotationAngle));
        double sinRotationAngle = Math.Abs(Math.Sin(rotationAngle));
        double newWidth = cosRotationAngle * currentSize.width + sinRotationAngle * currentSize.height;
        double newHeight = sinRotationAngle * currentSize.width + cosRotationAngle * currentSize.height;

        Size newSize = new Size(newWidth, newHeight);

        return newSize;
    }
}