using Matrix.Contracts;

namespace Matrix.Models
{
    public class Direction : Position, IDirection
    {
        public void Change()
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int changeDirection = 0;

            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == this.X && dirY[count] == this.Y)
                {
                    changeDirection = count;
                    break;
                }
            }

            if (changeDirection == 7)
            {
                this.X = dirX[0];
                this.Y = dirY[0];
                return;
            }

            this.X = dirX[changeDirection + 1];
            this.Y = dirY[changeDirection + 1];
        }

        public Direction(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}