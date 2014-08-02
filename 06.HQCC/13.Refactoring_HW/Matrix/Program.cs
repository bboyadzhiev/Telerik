using Matrix.Models;
using Matrix.View;
namespace Matrix
{
    public class WalkInMatrica
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine( "Enter a positive number " );
            //string input = Console.ReadLine(  );
            //int n = 0;
            //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            //{
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            //}
            int n = 6;

            SquareMatrix squareMatrix = new SquareMatrix(n);
            Position p = new Position();

            p = squareMatrix.TestLocalPositions(p);

            p = squareMatrix.FindFreeCell(p);

            if (p.X != 0 && p.Y != 0)
            {
                p.X = 1; p.Y = 1;
                p = squareMatrix.TestLocalPositions(p);
            }
            
            SquareMatrixExtensions.Print(squareMatrix);
        }
    }
}