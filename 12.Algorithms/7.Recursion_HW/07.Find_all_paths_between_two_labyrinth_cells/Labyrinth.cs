using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Find_all_paths_between_two_labyrinth_cells
{
    class Labyrinth
    {
        static char[,] lab = 
    {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', 't', ' '},
        {' ', '*', '*', '*', '*', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
    };

        static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindPathToTarget(int row, int col)
        {
            if (!InRange(row, col))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }

            // Check if we have found the exit
            if (lab[row, col] == 't')
            {
                PrintPath(row, col);
            }

            if (lab[row, col] != ' ')
            {
                // The current cell is not free -> can't find a path
                return;
            }

            // Temporary mark the current cell as visited to avoid cycles
            lab[row, col] = 's';
            path.Add(new Tuple<int, int>(row, col));

            // Invoke recursion the explore all possible directions
            FindPathToTarget(row, col - 1); // left
            FindPathToTarget(row - 1, col); // up
            FindPathToTarget(row, col + 1); // right
            FindPathToTarget(row + 1, col); // down

            // Mark back the current cell as free
            // Comment the below line to visit each cell at most once
            lab[row, col] = ' ';
            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath(int finalRow, int finalCol)
        {
            Console.Write("Found path: ");
            Console.WriteLine();
            PrintLabyrinth(lab, path);
            foreach (var cell in path)
            {
                Console.Write("({0},{1}) -> ", cell.Item1, cell.Item2);
            }
            Console.WriteLine("({0},{1})", finalRow, finalCol);
            Console.WriteLine();
        }

        private static void PrintLabyrinth(char[,] labyrinth,  List<Tuple<int, int>> path)
        {
            for (int r = -1; r <= labyrinth.GetLength(0); r++)
            {
                for (int c = -1; c <= labyrinth.GetLength(1); c++)
                {
                    if (r == -1 || r == labyrinth.GetLength(0))
                    {
                        Console.Write("#");

                    }
                    else if (c == -1 || c == labyrinth.GetLength(1))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        var inPath = false;
                        foreach (var cell in path)
                        {
                            if (cell.Item1 == r && cell.Item2 == c)
                            {
                                Console.Write(".");
                                inPath = true;
                            }
                        }
                        if (!inPath)
                        {
                            Console.Write(labyrinth[r,c]);
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            // Uncomment the code below to create larger labirinth
            // Test with size = 10 and size = 100

            //int size = 10;
            //lab = new char[size, size];
            //for (int row = 0; row < size; row++)
            //{
            //    for (int col = 0; col < size; col++)
            //    {
            //        lab[row, col] = ' ';
            //    }
            //}
            //lab[size - 1, size - 1] = 'e';
            Console.WriteLine("The Labyrinth:");
            PrintLabyrinth(lab, new List<Tuple<int, int>>());
            Console.WriteLine();
            FindPathToTarget(0, 0);
        }
    }
}
