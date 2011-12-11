using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class MinimaxPlayer2 : IPlayer
    {
        int miniMaxCount = 0;
        public Grid MakeMove(Grid g)
        {
            GridCells move;
            miniMaxCount = 0;
            Minimax(g, out move);
            Console.WriteLine("Minimax method calls: {0}", miniMaxCount);
            return g.MakeMove(move);
        }

        public float Minimax(Grid g, out GridCells best, int depth = 1)
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
                var result = -Minimax(other, out garbage, depth + 1);

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
