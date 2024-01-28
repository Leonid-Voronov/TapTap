using Config;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerOffsetCalculator : IOffsetCalculator
    {
        private GameConfigSO _gameConfig;
        private IPlayerDirection _playerDirection;

        [Inject]
        public PlayerOffsetCalculator(GameConfigSO gameConfig, IPlayerDirection playerDirection)
        {
            _gameConfig = gameConfig;
            _playerDirection = playerDirection;
        }

        public Vector3 CalculateOffset()
        {
            if (!_gameConfig.MovePlayer)
                return Vector3.zero;

            return _playerDirection.CurrentDirection * _gameConfig.GetPlayerSpeed();
        }
    }
}