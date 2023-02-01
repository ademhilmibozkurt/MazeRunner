using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Controller
    {
        public void IsFinished(int[] position, int point)
        {
            if ((position[0] == 0 && position[1] == 2) || (position[0] == 0 && position[1] == 5) || (position[0] == 0 && position[1] == 9))
            {
                Console.WriteLine($" Kazandınız ! Labirentten Çıktınız ! Puan : {point}"); Thread.Sleep(2000); Environment.Exit(0);
            }
        }

        public void IsOnTheBomb(int[] position, int point)
        {
            if ((position[0] == 3 && position[1] == 5) || (position[0] == 1 && position[1] == 3))
            {
                Console.WriteLine($" BooM! Maalesef Bombaya Bastınız. Puan : {point} ");
                Thread.Sleep(2000); Environment.Exit(0);
            }
        }

        public int IsOnTheMaze(int[] position)
        {
            if (position[1] == 9)
            {
                return 1;
            }
            else if(position[0] == 9)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
