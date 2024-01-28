using Config;
using UnityEngine;
using Infrastructure;
using System;
using Zenject;

namespace Player
{
    public class PlayerDirection : IDisposable, IPlayerDirection
    {
        private GameConfigSO _gameConfig;
        private Vector3 _currentDirection;
        private IGameplayStarter _gameplayStarter;

        public Vector3 CurrentDirection => _currentDirection;

        [Inject]
        public PlayerDirection(GameConfigSO gameConfig, IGameplayStarter gameplayStarter)
        {
            _gameConfig = gameConfig;
            _gameplayStarter = gameplayStarter;
            _gameplayStarter.SceneStarted += SetStartDirection;
        }

        private void SetStartDirection(object sender, EventArgs e)
        {
            _currentDirection = _gameConfig.StartDirection;
        }

        public void SetDirection(Quaternion eulerRotation)
        {
            _currentDirection = eulerRotation * _currentDirection;
        }

        public void Dispose()
        {
            _gameplayStarter.SceneStarted -= SetStartDirection;
        }

        
    }
}