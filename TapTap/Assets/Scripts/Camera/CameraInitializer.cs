using Cinemachine;
using Zenject;
using UnityEngine;
using Infrastructure;
using System;

namespace Camera
{
    public class CameraInitializer : IDisposable
    {
        private CinemachineVirtualCamera _camera;
        private Transform _playerTransform;
        private IGameplayStarter _gameplayStarter;

        [Inject]
        public CameraInitializer(PlayerTag playerTag, CinemachineVirtualCamera cinemachineVirtualCamera, IGameplayStarter gameplayStarter)
        {
            _camera = cinemachineVirtualCamera;
            _playerTransform = playerTag.transform;
            _gameplayStarter = gameplayStarter;

            _gameplayStarter.SceneStarted += InitializeCamera;
        }

        private void InitializeCamera(object sender, EventArgs e)
        {
            _camera.Follow = _playerTransform;
        }

        public void Dispose()
        {
            _gameplayStarter.SceneStarted -= InitializeCamera;
        }
    }
}

