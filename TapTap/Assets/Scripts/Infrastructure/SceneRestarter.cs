using Player;
using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure
{
    public class SceneRestarter : ISceneRestarter, IDisposable
    {
        private IDeathEventSender _deathEventSender;
        [Inject]
        public SceneRestarter(IDeathEventSender deathEventSender)
        {
            _deathEventSender = deathEventSender;
            _deathEventSender.PlayerDied += RestartScene;
        }
        public void RestartScene(object sender, EventArgs e)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Dispose()
        {
            _deathEventSender.PlayerDied -= RestartScene;
        }
    }
}

