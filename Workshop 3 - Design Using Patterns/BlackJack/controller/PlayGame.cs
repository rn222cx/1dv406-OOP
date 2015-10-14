using BlackJack.model;
using BlackJack.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : IBlackJackObserver
    {
        Game a_game = new Game();
        view.IView a_view;
        public PlayGame(Game a_game, view.IView a_view)
        {
            this.a_game = a_game;
            this.a_view = a_view;
        }
        public void HasNewCard()
        {
            Play();
            a_view.PauseGame();
        }

        public bool Play()
        {
            a_game.SubscribeToNewCard(this);

            a_view.DisplayWelcomeMessage();

            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            var input = a_view.GetInput();

            if (input == MenuValue.Start)
            {
                a_game.NewGame();
            input = MenuValue.None;
            }
            else if (input == MenuValue.Hit)
            {
                a_game.Hit();
                input = MenuValue.None;
            }
            else if (input == MenuValue.Stand)
            {
                a_game.Stand();
                input = MenuValue.None;
            }

            return input != MenuValue.Quit;
        }
    }
}
