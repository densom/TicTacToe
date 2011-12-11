using System;
namespace TicTacToe
{
    interface IPlayer
    {
        Grid MakeMove(Grid g);
    }
}
