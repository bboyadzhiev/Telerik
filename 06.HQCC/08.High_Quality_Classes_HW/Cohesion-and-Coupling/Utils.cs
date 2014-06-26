using System;

namespace CohesionAndCoupling
{
    public static class Geometry2DUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }
         
        public static double CalcDiagonalXY(double width, double height)
        {
            double distance = CalcDistance2D(0, 0, width, height);
            return distance;
        }

        public static double CalcDiagonalXZ(double width, double depth)
        {
            double distance = CalcDistance2D(0, 0, width, depth);
            return distance;
        }

        public static double CalcDiagonalYZ(double height, double depth)
        {
            double distance = CalcDistance2D(0, 0, height, depth);
            return distance;
        }
    }
    static class Geometry3DUtils
    {
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcVolume(double width, double height, double depth)
        {
            if (width <= 0 || height <= 0 || depth <= 0)
            {
                throw new ArgumentOutOfRangeException("Volume dimension can have only positive value!");
            }

            double volume = width * height * depth;
            return volume;
        }

         public static double CalcDiagonalXYZ(double width, double height, double depth)
        {
            double distance = CalcDistance3D(0, 0, 0, width, height, depth);
            return distance;
        }
    }

    static class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("File has no extension!");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("File has no extension!");
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }

    }
}
