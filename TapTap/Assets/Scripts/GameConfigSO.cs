using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
    public class GameConfigSO : ScriptableObject
    {
        [SerializeField] private bool _movePlayer;
        [SerializeField] private SpeedMode _speedMode;
        [SerializeField] private float _defaultSpeed;
        [SerializeField] private Vector3 _startDireciton;
        public bool MovePlayer => _movePlayer;
        public Vector3 StartDirection => _startDireciton;
        
        public float GetPlayerSpeed()
        {
            return _defaultSpeed;
        }
    }
}

