using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Dealer a_dealer, Player a_player)
        {
            /* Kan köras för att testa Soft17Strategy genom att ge rätt kort till dealern. Ändra Car.m_isHidden till false. Ta bort innan inlämning :) */
            //Card card1 = new Card(Card.Color.Clubs, Card.Value.Three);
            //Card card2 = new Card(Card.Color.Hearts, Card.Value.Three);
            //Card card3 = new Card(Card.Color.Hearts, Card.Value.Ace);
            //a_dealer.DealCard(card1);
            //a_dealer.DealCard(card2);
            //a_dealer.DealCard(card3);

            a_dealer.DealCard(true, a_player);

            a_dealer.DealCard(true, a_dealer);

            a_dealer.DealCard(true, a_player);

            //Card c;

            //c = a_deck.GetCard();
            //c.Show(true);
            //a_player.DealCard(c);

            //c = a_deck.GetCard();
            //c.Show(true);
            //a_dealer.DealCard(c);

            //c = a_deck.GetCard();
            //c.Show(true);
            //a_player.DealCard(c);

            return true;
        }
    }
}
