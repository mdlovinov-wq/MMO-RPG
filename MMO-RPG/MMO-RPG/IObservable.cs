using System;

namespace MMO_RPG
{
    internal interface IObservable
    {

        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify(UnitEvent unitEvent);

    }
}
