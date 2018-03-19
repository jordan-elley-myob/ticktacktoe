﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace TicTacToeMain
{
    public class WinningMoves
    {
        private const int NumberInARowToWin = Board.SizeOfboard;
        private readonly List<Tuple<int, int>> _movesList;
        public WinningMoves(List<Tuple<int, int>> movesList)
        {
            this._movesList = movesList;
        }

        private bool CheckStraight(int amountOfMovesInARow)
        {
            var xMoves = _movesList.OrderBy(i => i.Item1).ToList();
            var yMoves = _movesList.OrderBy(i => i.Item2).ToList();
            var countX = 0;
            var countY = 0;
            for (var i = 1; i < _movesList.Count; i++)
            {
                if (xMoves[i].Item1 == xMoves[i - 1].Item1)
                    countX += 1;
                else
                {
                    countX = 0;
                }
                if (yMoves[i].Item2 == yMoves[i - 1].Item2)
                    countY += 1;
                else
                {
                    countY = 0;
                }
                if (countX == amountOfMovesInARow-1 || countY == amountOfMovesInARow-1)
                    return true;
                
                
            }

            return false;
        }


        private bool CheckDiagonal(int amountOfMovesInARow)
        {
            var moves = _movesList.OrderBy(i => i.Item1).ToList();

            var win1 = new List<Tuple<int, int>> { };
            var win2 = new List<Tuple<int, int>> { };
            for (var i = 1; i <= amountOfMovesInARow; i++)
            {
                win1.Add(new Tuple<int, int>(i, i));
                win2.Add(new Tuple<int, int>(i,amountOfMovesInARow+1-i));
            }

            return ContainsAllItems(moves, win1) || ContainsAllItems(moves, win2);
        }

        public bool CheckWin()
        {
            return CheckDiagonal(NumberInARowToWin) || CheckStraight(NumberInARowToWin);
        }

        private static bool ContainsAllItems<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            return !b.Except(a).Any();
        }

    }
}