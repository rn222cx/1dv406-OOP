using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        // Soft 17 means that the dealer has 17 but in a combination of Ace and 6 (for example Ess, tvåa, tvåa, tvåa). 
        // This means that the Dealer can get another card valued at 10 but still have 17 as the value of the ace is reduced to 1.

        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            //Console.WriteLine((int)Card.Value.Ace);
            var hand = a_dealer.GetHand();
            int score = a_dealer.CalcScore();

            // Loops through the dealers cards.
            foreach (var card in hand)
            {
                Console.Write(card.GetValue());
                // If the dealer has 17.
                if (score == g_hitLimit)
                {
                    // But in a comibination of Ace and 6.
                    if (card.GetValue() == Card.Value.Ace && score - 11 == 6)
                    {
                        // The dealer can get another card valued 10 but still have 17.
                        score -= 10;
                    }
                }
            }

            return score < g_hitLimit;
        }
    }
}
