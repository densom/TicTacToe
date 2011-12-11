using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class MinimaxPlayer : IPlayer
    {
        public Grid MakeMove(Grid g)
        {
            GridCells move;
            Minimax(g, out move);
            return g.MakeMove(move);
        }

        public int Minimax(Grid g, out GridCells best)
        {
            best = GridCells.None;
            var bestResult = -10;
            GridCells garbage;
            if (g.IsDraw)
                return 0;

            if (g.CurrentIsWinner)
                return 1;

            if (g.CurrentIsLoser)
                return -1;

            foreach (var move in g.GetMoves())
            {
                var other = g.MakeMove(move);
                var result = -Minimax(other, out garbage);

                if (result > bestResult)
                {
                    best = move;
                    bestResult = result;
                }
            }
            return bestResult;
        }
    }
}
