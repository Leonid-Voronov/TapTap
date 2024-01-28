using System;

namespace Player
{
    public interface IDeathEventSender 
    {
        event EventHandler PlayerDied;
    }
}