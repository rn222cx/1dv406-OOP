﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class WinnerOriginal : IWinner
    {
        private const int maxScore = 21;

        public int GetMaxScore()
        {
            return maxScore;
        }
        /// <summary>
        /// Returns true if the dealer wins. On equal score the dealer wins.
        /// </summary>
        /// <param name="a_dealer"></param>
        /// <param name="a_player"></param>
        /// <returns></returns>
        public bool IsDealerWinner(Dealer a_dealer, Player a_player)
        {
            if (a_player.CalcScore() > maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > maxScore)
            {
                return false;
            }
            return a_dealer.CalcScore() >= a_player.CalcScore();
        }
    }
}
