using Matrix.Contracts;
using Matrix.Models;
using System;

namespace Matrix.View
{
    public static class SquareMatrixExtensions
    {
        public static void Print(this SquareMatrix squareMatrix)
        {
            for (int i = 0; i < squareMatrix.Size; i++)
            {
                for (int j = 0; j < squareMatrix.Size; j++)
                {
                    Console.Write("{0,3}", squareMatrix.MatrixPositions[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}