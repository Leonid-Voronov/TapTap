using UnityEngine;
using Zenject;
using Cinemachine;
using Infrastructure;
using Camera;
using Player;
using Config;
using UIInitialization;
using UI;
using Input;
using Environment;

namespace Ifrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Scriptable objects")]
        [SerializeField] private GameConfigSO _gameConfigSO;
        [SerializeField] private GameplayCanvasPrefabsSO _canvasPrefabs;

        [Header ("Prefabs")] 
        [SerializeField] private GameObject _playerPrefab;

        [Header ("Scene dependencies")]
        [SerializeField] private ActionButtonHolder _actionButtonHolder;
        [SerializeField] private AppStarter _appStarter;
        [SerializeField] private GameplayStarter _gameplayStarter;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private CinemachineVirtualCamera _playerVirtualCamera;
        public override void InstallBindings()
        {
            InstallConfigBindings();
            InstallInfrastructureBindings();
            InstallEnvironmentBindings();
            InstallCameraBindings();
            InstallUIBindings();
            InstallPlayerBindings();
            InstallGameStateBindings();
        }

        private void InstallInfrastructureBindings()
        {
            Container.Bind<IAppStarter>()
                .FromInstance(_appStarter)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<GameplayStarter>()
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

            Container.Bind<IJumper>()
                .FromInstance(playerTag.Jumper)
                .AsSingle();

            Container.Bind<IDeathEventSender>()
                .FromInstance(playerTag.GroundChecker)
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

        private void InstallUIBindings()
        {
            GameObject canvasPrefab = Screen.width >= Screen.height ? _canvasPrefabs.PCCanvasPrefab : _canvasPrefabs.MobileCanvasPrefab;
            GameplayCanvas gameplayCanvas = Container.InstantiatePrefabForComponent<GameplayCanvas>(canvasPrefab);

            Container.Bind<ITapReceiver>()
                .FromInstance(gameplayCanvas.TapReceiver)
                .AsSingle();
        }

        private void InstallEnvironmentBindings()
        {
            Container.Bind<INextButtonGetter>()
                .FromInstance(_actionButtonHolder)
                .AsSingle();
        }

        private void InstallGameStateBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneRestarter>()
                .AsSingle();
        }
    }
}

