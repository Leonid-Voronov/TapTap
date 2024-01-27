using System;
using UnityEngine;

namespace Infrastructure
{
    public class GameplayStarter : MonoBehaviour, IGameplayStarter
    {
        public event EventHandler SceneStarted;
        private void Start()
        {
            SceneStarted?.Invoke(this, EventArgs.Empty);
        }
    }
}

