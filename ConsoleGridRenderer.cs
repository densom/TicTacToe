using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    static class ConsoleGridRenderer
    {
        public static void Render(Grid grid)
        {
            Console.WriteLine(" {0} | {1} | {2} ", grid.GetCell(GridCells.TL), grid.GetCell(GridCells.TC), grid.GetCell(GridCells.TR));
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", grid.GetCell(GridCells.ML), grid.GetCell(GridCells.MC), grid.GetCell(GridCells.MR));
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", grid.GetCell(GridCells.BL), grid.GetCell(GridCells.BC), grid.GetCell(GridCells.BR));

        }

        static string GetCell(this Grid grid, GridCells target)
        {
            if ((grid.Current & target) != GridCells.None)
                return (grid.CurrentIsO ? "O" : "X");

            if ((grid.Opponent & target) != GridCells.None)
                return (grid.CurrentIsO ? "X" : "O");

            return " ";
        }
    }
}
