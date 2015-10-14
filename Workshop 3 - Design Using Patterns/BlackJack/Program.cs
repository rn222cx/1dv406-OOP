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
            model.Dealer dealer = new model.Dealer(new model.rules.RulesFactory());
            model.Player player = new model.Player();
            model.Game game = new model.Game(dealer, player);
            view.IView view = new view.SimpleView(); // new view.SwedishView();
            game.Subscribe(view);
            controller.PlayGame ctrl = new controller.PlayGame();

            while (ctrl.Play(game, view));
        }
    }
}
