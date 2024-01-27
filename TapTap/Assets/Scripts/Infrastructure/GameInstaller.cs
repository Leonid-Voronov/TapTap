using UnityEngine;
using Zenject;
using Cinemachine;
using Infrastructure;
using Camera;

namespace Ifrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [Header ("Prefabs")] 
        [SerializeField] private GameObject _playerPrefab;

        [Header ("Scene dependencies")]
        [SerializeField] private GameplayStarter _gameplayStarter;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private CinemachineVirtualCamera _playerVirtualCamera;
        public override void InstallBindings()
        {
            InstallInfrastructureBindings();
            InstallCameraBindings();
            InstallPlayerBindings();
        }

        private void InstallInfrastructureBindings()
        {
            Container.Bind<IGameplayStarter>()
                .FromInstance(_gameplayStarter)
                .AsSingle();
        }

        private void InstallPlayerBindings()
        {
            PlayerTag playerTag = Container.InstantiatePrefabForComponent<PlayerTag>(_playerPrefab, _playerStartPoint.position, Quaternion.identity, null);

            Container.Bind<PlayerTag>()
                .FromInstance(playerTag)
                .AsSingle();
        }

        private void InstallCameraBindings()
        {
            Container.Bind<CinemachineVirtualCamera>()
                .FromInstance(_playerVirtualCamera)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CameraInitializer>()
                .AsSingle();
        }
    }
}

