using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class AlphaBetaMinimaxPlayer : IPlayer
    {
        int miniMaxCount = 0;
        public Grid MakeMove(Grid g)
        {
            GridCells move;
            miniMaxCount = 0;
            Minimax(g, out move, float.MinValue, float.MaxValue);
            Console.WriteLine("Minimax method calls: {0}", miniMaxCount);
            return g.MakeMove(move);
        }

        public float Minimax(Grid g, out GridCells best, float alpha, float beta, int depth = 1)
        {
            miniMaxCount++;
            best = GridCells.None;
            var bestResult = -10f;
            GridCells garbage;
            if (g.IsDraw)
                return 0f;

            if (g.CurrentIsWinner)
                return 1f / depth;

            if (g.CurrentIsLoser)
                return -1f / depth;

            foreach (var move in g.GetMoves())
            {
                var other = g.MakeMove(move);
                alpha = -Minimax(other, out garbage, -beta, -alpha, depth + 1);

                if (beta <= alpha)
                    return alpha;

                if (alpha > bestResult)
                {
                    best = move;
                    bestResult = alpha;
                }
            }
            return bestResult;
        }
    }
}
