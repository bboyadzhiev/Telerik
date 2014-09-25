namespace TicTacToe.GameLogic
{
    using System;
    using System.Text;
    using System.Collections;
    using System.Linq;
    public class GameResultValidator : IGameResultValidator
    {
        private const string ValidCharacters = "XO-";
        // O-X  
        // O-X
        // --X
        public GameResult GetResult(string board)
        {
            CheckBoardIntegrity(board);
            var result = CheckRows(board);

            if (result == GameResult.NotFinished || result == GameResult.Draw)
            {
                result = CheckCols(board);
            }

            if (result == GameResult.NotFinished || result == GameResult.Draw)
            {
                result = CheckDiagonals(board);
            }

            return result;
        }

        public void CheckBoardIntegrity(string board)
        {
            if (!board.All(c => ValidCharacters.Contains(c)) || board.Length != 9)
            {
                throw new ArgumentException("Invalid board description!");
            }

            int xes = board.Count(c => c == 'X');
            int oes = board.Count(c => c == 'O');
            if (xes>oes && xes-oes > 1)
            {
                throw new ArgumentException("Invalid board!");
            }
            if (oes > xes && oes - xes > 1)
            {
                throw new ArgumentException("Invalid board!");
            }
        }

        private static GameResult CheckRows(string board)
        {
            // if no '-' found and no winner has been defined ad the end => Draw for CheckRows(board)
            var result = GameResult.Draw;
            char lastChar;

            for (int row = 0; row < 3; row++)
            {
                lastChar = board[row * 3];
                if (lastChar == '-')
                {
                    // empty position found => setting to 'NotFinished' (so far)
                    result = GameResult.NotFinished;
                }
                else if (board[3 * row + 1] == lastChar && board[3 * row + 2] == lastChar)
                {
                    if (lastChar == 'O')
                    {
                        return GameResult.WonByO;
                    }
                    else
                    {
                        return GameResult.WonByX;
                    }
                }
            }

            return result;
        }

        private static GameResult CheckCols(string board)
        {
            var result = GameResult.Draw;
            char lastChar;

            for (int col = 0; col < 3; col++)
            {
                lastChar = board[col];
                if (lastChar == '-')
                {
                    result = GameResult.NotFinished;
                }
                else if (board[col + 3] == lastChar && board[col + 6] == lastChar)
                {
                    if (lastChar == 'O')
                    {
                        return GameResult.WonByO;
                    }
                    else
                    {
                        return GameResult.WonByX;
                    }

                }
            }

            return result;
        }

        private static GameResult CheckDiagonals(string board)
        {
            var result = GameResult.Draw;
            char center = board[4]; // the center
            if (center == '-')
            {
                result = GameResult.NotFinished;
                return result; // no need to check any further
            }

            if (board[0] == center && board[8] == center)
            {
                if (center == 'O')
                {
                    return GameResult.WonByO;
                }
                else
                {
                    return GameResult.WonByX;
                }
            }

            if (board[2] == center && board[6] == center)
            {
                if (center == 'O')
                {
                    return GameResult.WonByO;
                }
                else
                {
                    return GameResult.WonByX;
                }
            }

            return result;
        }
    }
}
