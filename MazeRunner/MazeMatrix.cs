using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class MazeMatrix
    {
        public int[,] CreateMaze()
        {
            int[,] maze = new int[10, 10];

            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    maze[i, j] = 0;

                    if ((i <= 6 && j == 9) || (i == 6 && j >= 4))
                    {
                        maze[i, j] = 1; 
                    }
                    if (i > 0 && j == 7)
                    {
                        maze[i, j] = 1;
                    }
                    if (i == 3 && (j > 0 && j <= 5))
                    {
                        maze[i, j] = 1;
                    }
                    if ((i != 2 && i != 4 && i != 9) && j == 2)
                    {
                        maze[i, j] = 1;
                    }
                }
            }
            maze[1, 3] = 1; maze[3, 5] = 1;  // Bombs
            maze[9, 1] = 1; maze[9, 4] = 1; maze[9, 8] = 1; // Starting Points
            
            // Roads That No Allowed Alghorithm
            maze[5, 1] = 1; maze[4, 1] = 1; maze[3, 1] = 1;maze[8,1] = 1;
            maze[3,2] = 1; maze[3, 3] = 1; maze[3, 4] = 1;  maze[1, 4] = 1; maze[1, 7] = 1; maze[1, 6] = 1;
            maze[8,4] = 1; maze[7, 4] = 1;  maze[0, 5] = 1; maze[2, 5] = 1; maze[1, 5] = 1;
            return maze;
        }

        public void PrintMaze(int[,] maze , int[] position)
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (i == position[0] && j == position[1])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" K ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" {maze[i, j]} ");
                    }
                }   Console.WriteLine("\n");
            }
        }

        public void PrintBombs(int[,] maze)
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if ((i == 1 && j == 3) || (i == 3 && j == 5))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" B "); // Bombalar B Harfi İle Belirtildi.
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" {maze[i, j]} ");
                    }
                }
                Console.WriteLine("\n");
            }
        }
    }
}
