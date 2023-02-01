using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            // değişkenlerde ve sınıf çağırırken camelCase standartını kullanıyorum.
            // sınıf ve metot isimlerinde ise PascalCase standardını kullanıyorum.
            MoveOnTheMaze move = new MoveOnTheMaze();
            Console.Title = "MazeRunner"; 
            move.StartPositionChooser();
            move.MoveOnTheRoad();

            Console.ReadKey();
        }
    }
}
