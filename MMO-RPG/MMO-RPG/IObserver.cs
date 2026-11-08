using System;


namespace MMO_RPG
{
    internal interface IObserver
    {

        void OnUnitEvent(UnitEvent unitEvent);

    }
}
