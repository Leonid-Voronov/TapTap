using System;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class AppStarter : MonoBehaviour, IAppStarter
    {
        public event EventHandler AppStarted;

        private void Start()
        {
            AppStarted?.Invoke(this, EventArgs.Empty);
        }
    }
}