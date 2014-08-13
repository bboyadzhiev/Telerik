using Matrix.Contracts;

namespace Matrix.Models
{
    public class SquareMatrix
    {
        private int[,] matrixPositions;

        public int[,] MatrixPositions
        {
            get { return matrixPositions; }
            set { matrixPositions = value; }
        }

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
            : this(size, new Direction(1, 1), new Position())
        {
        }

        public SquareMatrix(int size, Direction direction, Position position)
        {
            this.Size = size;
            this.Direction = direction;
            this.Position = position;
            this.matrixPositions = new int[size, size];
            this.Step = 1;
        }

        public bool TestPosition(Position p)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (p.X + dirX[i] >= this.Size || p.X + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }
                if (p.Y + dirY[i] >= this.Size || p.Y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (MatrixPositions[p.X + dirX[i], p.Y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public Position TestLocalPositions(Position p)
        {
            this.MatrixPositions[p.X, p.Y] = Step;

            while (this.TestPosition(p))
            {
                while (this.HasAvailableDirection(p))
                {
                    this.Direction.Change();
                }

                p.X += this.Direction.X;
                p.Y += this.Direction.Y;
                Step++;
                this.MatrixPositions[p.X, p.Y] = Step;
            }
            return p;
        }

        public bool HasAvailableDirection(Position p)
        {
            return (p.X + this.Direction.X >= this.Size
                || p.X + this.Direction.X < 0
                || p.Y + this.Direction.Y >= this.Size
                || p.Y + this.Direction.Y < 0
                || MatrixPositions[p.X + this.Direction.X, p.Y + this.Direction.Y] != 0);
        }

        public Position FindFreeCell(Position p)
        {
            p.X = 0;
            p.Y = 0;
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (this.MatrixPositions[i, j] == 0)
                    {
                        p.X = i;
                        p.Y = j;
                    }
                }
            }
            return p;
        }
    }
}