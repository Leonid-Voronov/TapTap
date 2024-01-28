using Config;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Jumper : MonoBehaviour, IJumper
    {
        private GameConfigSO _gameConfig;
        private float _jumpTimer;
        private bool _jumping = false;
        
        [Inject]
        public void Construct(GameConfigSO gameConfig)
        {
            _gameConfig = gameConfig;
        }

        private void FixedUpdate()
        {
            if(_jumping)
            {
                _jumpTimer += Time.fixedDeltaTime;

                if (_jumpTimer > _gameConfig.JumpTime ) 
                {
                    _jumping = false;
                    _jumpTimer = 0;
                }
            }
        }

        public float GetJumpOffset()
        {
            return _jumping ? _gameConfig.JumpCurve.Evaluate(_jumpTimer / _gameConfig.JumpTime) * _gameConfig.JumpHeight : 0f;
        }

        public void StartJump()
        {
            _jumping = true;
        }
    }
}

