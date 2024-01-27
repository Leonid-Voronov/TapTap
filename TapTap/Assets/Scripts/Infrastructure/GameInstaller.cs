using UnityEngine;
using Zenject;
using Cinemachine;
using Infrastructure;
using Camera;
using Player;
using Config;

namespace Ifrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Scriptable objects")]
        [SerializeField] private GameConfigSO _gameConfigSO;

        [Header ("Prefabs")] 
        [SerializeField] private GameObject _playerPrefab;

        [Header ("Scene dependencies")]
        [SerializeField] private GameplayStarter _gameplayStarter;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private CinemachineVirtualCamera _playerVirtualCamera;
        public override void InstallBindings()
        {
            InstallConfigBindings();
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
            Container.Bind<IOffsetCalculator>()
                .To<PlayerOffsetCalculator>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerDirection>()
                .AsSingle();

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

        private void InstallConfigBindings()
        {
            Container.Bind<GameConfigSO>()
                .FromInstance(_gameConfigSO)
                .AsSingle();
        }
    }
}

