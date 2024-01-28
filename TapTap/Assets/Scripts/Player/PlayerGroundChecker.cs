using System;
using UnityEngine;

namespace Player
{
    public class PlayerGroundChecker : MonoBehaviour, IDeathEventSender
    {
        [SerializeField] private Jumper _jumper;
        RaycastHit[] _raycastHits = new RaycastHit[10]; 
        private const string LayerName = "Ground";
        private int _groundNumber = 1;

        public event EventHandler PlayerDied;

        private void Update()
        {
            _groundNumber = Physics.RaycastNonAlloc(transform.position, Vector3.down, _raycastHits, 10f, LayerMask.GetMask(LayerName));

            if (!(IsOnGround() || _jumper.IsJumping))
                PlayerDied?.Invoke(this, EventArgs.Empty);
        }

        public bool IsOnGround() => _groundNumber > 0;
    }
}

