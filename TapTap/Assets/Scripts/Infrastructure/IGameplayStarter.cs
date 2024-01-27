using System;

namespace Infrastructure
{
    public interface IGameplayStarter
    {
        event EventHandler SceneStarted;
    }
}