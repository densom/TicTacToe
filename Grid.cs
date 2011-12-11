using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{

    [Flags]
    enum GridCells
    {
        None = 0,
        TL = 1, TC = 2, TR = 4,
        ML = 8, MC = 16, MR = 32,
        BL = 64, BC = 128, BR = 256,
        TopRow = TL | TC | TR,
        MiddleRow = ML | MC | MR,
        BottomRow = BL | BC | BR,
        LeftColumn = TL | ML | BL,
        CenterColumn = TC | MC | BC,
        RightColumn = TR | MR | BR,
        Diagonal1 = TL | MC | BR,
        Diagonal2 = TR | MC | BL,
        All = TopRow | MiddleRow | BottomRow
    }

    struct Grid
    {
        public readonly GridCells Current;
        public readonly GridCells Opponent;
        public readonly bool CurrentIsO;

        public Grid(GridCells current, GridCells opponent, bool isO = false)
            : this()
        {
            this.Current = current;
            this.Opponent = opponent;
            this.CurrentIsO = isO;
        }

        public Grid MakeMove(GridCells target)
        {
            if (!this.CanMove(target))
                throw new InvalidOperationException();

            return new Grid(this.Opponent, this.Current | target, !this.CurrentIsO);
        }

        public bool CanMove(GridCells target)
        {
            if (this.Check(this.Current, target))
                return false;

            if (this.Check(this.Opponent, target))
                return false;

            return true;
        }

        bool Check(GridCells state, GridCells target)
        {
            return (state & target) == target;
        }


        public bool IsFinished
        {
            get
            {
                return IsDraw || CurrentIsWinner || CurrentIsLoser;
            }
        }

        public bool IsDraw
        {
            get
            {
                if (!this.Check(this.Opponent | this.Current, GridCells.All))
                    return false;

                return !this.CurrentIsWinner && !this.CurrentIsLoser;
            }
        }

        public bool CurrentIsWinner
        {
            get
            {
                return CheckWin(this.Current);
            }
        }

        public bool CurrentIsLoser
        {
            get
            {
                return CheckWin(this.Opponent);
            }
        }

        bool CheckWin(GridCells target)
        {
            if (this.Check(target, GridCells.TopRow))
                return true;

            if (this.Check(target, GridCells.MiddleRow))
                return true;

            if (this.Check(target, GridCells.BottomRow))
                return true;

            if (this.Check(target, GridCells.LeftColumn))
                return true;

            if (this.Check(target, GridCells.CenterColumn))
                return true;

            if (this.Check(target, GridCells.RightColumn))
                return true;

            if (this.Check(target, GridCells.Diagonal1))
                return true;

            if (this.Check(target, GridCells.Diagonal2))
                return true;

            return false;
        }

        public static Grid Empty
        {
            get
            {
                return new Grid();
            }
        }

        public IEnumerable<GridCells> GetMoves()
        {
            if (this.CurrentIsWinner || this.CurrentIsLoser)
                yield break;

            var occupation = this.Current | this.Opponent;
            for (int i = 0; i < 9; i++)
            {
                var move = (GridCells)(1 << i);
                if (!this.Check(occupation, move))
                    yield return move;
            }
        }
    }
}
