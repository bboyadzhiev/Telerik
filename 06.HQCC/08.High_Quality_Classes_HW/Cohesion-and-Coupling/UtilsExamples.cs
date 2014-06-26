using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Geometry2DUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Geometry3DUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            double width = 3;
            double height = 4;
            double depth = 5;
            Console.WriteLine("Volume = {0:f2}", Geometry3DUtils.CalcVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry3DUtils.CalcDiagonalXYZ(width, height, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry2DUtils.CalcDiagonalXY(width, height));
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry2DUtils.CalcDiagonalXZ(width, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry2DUtils.CalcDiagonalYZ(height, depth));
        }
    }
}
