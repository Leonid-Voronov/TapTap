using System;

namespace Input
{
    public interface ITapReceiver
    {
        event EventHandler TapPressed;
    }
}