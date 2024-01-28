using System;

namespace Infrastructure
{
    public interface IAppStarter 
    {
        event EventHandler AppStarted;
    }
}