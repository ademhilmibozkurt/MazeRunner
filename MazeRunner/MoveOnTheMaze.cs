using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeRunner
{
    class MoveOnTheMaze
    {
        int point = 0; 
        int[] position = new int[2] { 0, 0 }; 
        MazeMatrix maze = new MazeMatrix(); 
        Controller control = new Controller();
        public void StartPositionChooser()
        {
            Console.WriteLine(" 1. Rota (10,2) Konumundan Başlar.\n 2. Rota (10,5) Konumundan Başlar.\n 3. Rota (10,9) Konumundan Başlar.\n --------------------------------- \n"); 
            Console.WriteLine("Rota İçin Yol Seçin => ");
            int choise = int.Parse(Console.ReadLine());
            for (int i = 0; i < 1; i++)
            {
                if (choise == 1)
                {
                    position[0] = 9; position[1] = 1;
                }
                else if (choise == 2)
                {
                    position[0] = 9; position[1] = 4;
                }
                else if (choise == 3)
                {
                    position[0] = 9; position[1] = 8;
                }
                else
                {
                    Console.WriteLine("Hatalı Rota Seçimi , Rotayı Tekrar Seçin!\n");
                    i--;
                } 
            }Console.Clear();
        }

        public void MoveOnTheRoad()
        {
            int[,] mazeHolder = maze.CreateMaze();
            maze.PrintMaze(mazeHolder, position);
            Console.WriteLine(" Labirentte İken 'w,a,s,d' Tuşlarıyla Konumunuzu Değiştirebilirsiniz.\n");

            for (int i = 0; i < 1; i++)
            {
                ConsoleKeyInfo consoleKey; consoleKey = Console.ReadKey();
                switch (consoleKey.KeyChar)
                {
                    case 'w': Console.Clear();
                        if (mazeHolder[position[0] - 1, position[1]] == 1)
                        {
                            position[0] -= 1; i--; point++; maze.PrintMaze(mazeHolder, position);
                        }
                        else { Console.WriteLine("Hata Duvara Geldiniz ! Başka Yöne Gidin !"); i--; point--; maze.PrintMaze(mazeHolder, position);}  
                        break;
                    case 'a': Console.Clear();
                        if (mazeHolder[position[0], position[1] -1] == 1)
                        {
                            position[1] -= 1; i--; point++; maze.PrintMaze(mazeHolder, position); 
                        }
                        else { Console.WriteLine("Hata Duvara Geldiniz ! Başka Yöne Gidin !"); i--; point--; maze.PrintMaze(mazeHolder, position);}  
                        break;
                    case 's': Console.Clear();
                        if (control.IsOnTheMaze(position) == 2)
                        {
                            i--; point--; maze.PrintMaze(mazeHolder, position); position[0] -= 1; Console.Clear();
                        }
                        if (mazeHolder[position[0] + 1, position[1]] == 1)
                        {
                            position[0] += 1; i--; point++; maze.PrintMaze(mazeHolder, position); 
                        }
                        else { Console.WriteLine("Hata Duvara Geldiniz ! Başka Yöne Gidin !"); i--; point--; maze.PrintMaze(mazeHolder, position);} 
                        break;
                    case 'd': Console.Clear(); 
                        if (control.IsOnTheMaze(position) == 1)
                        {
                            Console.WriteLine("Hata Duvara Geldiniz ! Başka Yöne Gidin !"); Thread.Sleep(1000);
                            i--; point--; maze.PrintMaze(mazeHolder, position); position[1] -= 1; Console.Clear();
                        }
                        if (mazeHolder[position[0], position[1] + 1] == 1)
                        {
                            position[1] += 1; i--; point++; maze.PrintMaze(mazeHolder, position); 
                        }
                        else { Console.WriteLine("Hata Duvara Geldiniz ! Başka Yöne Gidin !"); i--; point--; maze.PrintMaze(mazeHolder, position);} 
                        break;
                    case 'g': Console.Clear();  i--; maze.PrintBombs(mazeHolder); 
                        break;
                    default: Console.Clear(); Console.WriteLine("\nHatalı Giriş! Tekrar Edin => "); i--;  maze.PrintMaze(mazeHolder, position);
                        break;
                }
                if (consoleKey.KeyChar == 'g')
                {
                    consoleKey = Console.ReadKey();
                    if (consoleKey.KeyChar == 'g')
                    {
                        Console.Clear(); maze.PrintMaze(mazeHolder, position);
                    }
                    else { continue; }
                }

                if ((position[0] == 9 && position[1] == 1) || (position[0] == 9 && position[1] == 4) || (position[0] == 9 && position[1] == 8))
                {
                   Console.Clear(); Console.WriteLine(" Başlangıç Noktasındasınız! Tekrar Rota Seçin. ");  StartPositionChooser(); maze.PrintMaze(mazeHolder, position); i--;
                }
                control.IsFinished(position, point);
                control.IsOnTheBomb(position, point);
            }
        }
    }
}
