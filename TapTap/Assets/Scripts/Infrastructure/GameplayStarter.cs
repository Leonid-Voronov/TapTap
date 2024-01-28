using System;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameplayStarter : MonoBehaviour, IGameplayStarter, IDisposable
    {
        public event EventHandler SceneStarted;
        private IAppStarter _appStarter;

        [Inject]
        public void Construct(IAppStarter appStarter)
        {
            _appStarter = appStarter;
            _appStarter.AppStarted += StartGame;
        }

        private void StartGame(object sender, EventArgs e)
        {
            SceneStarted?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            _appStarter.AppStarted -= StartGame;
        }
    }
}

