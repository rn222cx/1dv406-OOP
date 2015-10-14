using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            model.Game game = new model.Game();
            view.IView view = new view.SimpleView(); // new view.SwedishView();
            game.SubscribeToNewCard(view);
            controller.PlayGame ctrl = new controller.PlayGame();

            while (ctrl.Play(game, view));
        }
    }
}
