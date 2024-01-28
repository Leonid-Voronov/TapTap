using Config;
using Input;
using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Jumper : MonoBehaviour, IJumper
    {
        private GameConfigSO _gameConfig;
        private ITapReceiver _tapReceiver;
        private float _jumpTimer;
        private bool _jumping = false;
        
        [Inject]
        public void Construct(ITapReceiver tapReceiver, GameConfigSO gameConfig)
        {
            _tapReceiver = tapReceiver;
            _gameConfig = gameConfig;
        }

        private void OnEnable()
        {
            _tapReceiver.TapPressed += StartJump;
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

        private void StartJump(object sender, EventArgs e)
        {
            _jumping = true;
        }

        private void OnDisable()
        {
            _tapReceiver.TapPressed -= StartJump;
        }
    }
}

