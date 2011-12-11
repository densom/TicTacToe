using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TicTacToe";
            var players = new IPlayer[] { new HumanConsolePlayer(), new AlphaBetaMinimaxPlayer() };
            int current = 0;
            var alternante = 0;

            Grid g = Grid.Empty;
            while (true)
            {
                g = players[current].MakeMove(g);
                current = (current + 1) % 2;

                if (g.IsFinished)
                {
                    ConsoleGridRenderer.Render(g);
                    if (!g.IsDraw)
                        Console.WriteLine("{0} win!", g.CurrentIsO ? "X" : "O");
                    else
                        Console.WriteLine("Draw!");
                    current = (++alternante % 2);
                    g = Grid.Empty;
                }
                Console.WriteLine("\n");
            }
        }
    }
}
