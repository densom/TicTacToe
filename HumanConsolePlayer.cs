using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class HumanConsolePlayer : IPlayer
    {
        public Grid MakeMove(Grid g)
        {
            GridCells move;
            while (true)
            {
                ConsoleGridRenderer.Render(g);
                Console.WriteLine("\nEnter {0} move: ", g.CurrentIsO ? "O" : "X");
                if (Enum.TryParse<GridCells>(Console.ReadLine().ToUpper(), out move) && g.CanMove(move))
                    return g.MakeMove(move);
                else
                    Console.WriteLine("Invalid Move!");
            }
        }
    }
}
