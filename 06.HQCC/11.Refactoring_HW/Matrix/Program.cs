using System;

namespace Task3
{

    class Position
    {
        private int x;
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public Position()
        {
            this.X = 0;
            this.Y = 0;
        }

    }
    class Direction : Position
    {

        public void Change()
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int cd = 0;

            for (int count = 0; count < 8; count++)
                if (dirX[count] == this.X && dirY[count] == this.Y) { cd = count; break; }

            if (cd == 7) { this.X = dirX[0]; this.Y = dirY[0]; return; }
          
            this.X = dirX[cd + 1];
            this.Y = dirY[cd + 1];
        }

        public Direction(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }


    }

    class SquareMatrix
    {
        public int[,] matrixPositions;

        private Direction direction;

        private int step;

        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        

        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        private Position position;

        public Position Position
        {
            get { return position; }
            set { position = value; }
        }


        private int size;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        
        

        public SquareMatrix(int size)
        {
            this.Size = size;
            this.matrixPositions = new int[size, size];
            this.Direction = new Direction(1, 1);
            this.Position = new Position();
            this.Step = 1;

        }

        public bool TestPosition(Position p)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (p.X + dirX[i] >= this.Size || p.X + dirX[i] < 0) dirX[i] = 0;
                if (p.Y + dirY[i] >= this.Size || p.Y + dirY[i] < 0) dirY[i] = 0;
            }
            for (int i = 0; i < 8; i++)
                if (matrixPositions[p.X + dirX[i], p.Y + dirY[i]] == 0) return true;

            return false;
        }

        public Position TestLocalPositions(Position p)
        {

            this.matrixPositions[p.X, p.Y] = Step;

            while (this.TestPosition(p))
            {
               while (this.HasAvailableDirection(p))
               {
                   this.Direction.Change();

               }
          
               p.X += this.Direction.X;
               p.Y += this.Direction.Y;
               Step++;
               this.matrixPositions[p.X, p.Y] = Step;
           }
            return p;
        }

        public bool HasAvailableDirection(Position p)
        {
            return (p.X + this.Direction.X >= this.Size 
                || p.X + this.Direction.X < 0 
                || p.Y + this.Direction.Y >= this.Size 
                || p.Y + this.Direction.Y < 0 
                || matrixPositions[p.X + this.Direction.X, p.Y + this.Direction.Y] != 0);
        }

        public Position FindFreeCell(Position p)
        {
            p.X = 0;
            p.Y = 0;
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (this.matrixPositions[i, j] == 0)
                    {
                        p.X = i;
                        p.Y = j;
                    }
                }
            }
            return p;
        }

        public void Print()
        {
            for (int i = 0; i < this.Size; i++)
            {
                
                for (int j = 0; j < this.Size; j++)
                {
                    Console.Write("{0,3}", matrixPositions[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
    class WalkInMatrica
    {
        static void Main(string[] args)
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

            SquareMatrix sq = new SquareMatrix(n);
            Position p = new Position();

            p = sq.TestLocalPositions(p);
           
           
            p = sq.FindFreeCell(p);
           
            if (p.X != 0 && p.Y != 0)
            {
                p.X = 1; p.Y = 1;
                 p = sq.TestLocalPositions(p);
            }
            sq.Print();
        }
    }
}
