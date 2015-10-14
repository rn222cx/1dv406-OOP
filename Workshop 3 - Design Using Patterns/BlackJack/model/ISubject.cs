using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface ISubject
    {
            void Subscribe(IBlackJackObserver observer);
            //void Unsubscribe(IBlackJackObserver observer);
            void Notify();
    }
}
