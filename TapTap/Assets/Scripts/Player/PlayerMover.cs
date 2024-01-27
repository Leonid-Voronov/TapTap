using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        private IOffsetCalculator _offsetCalculator;

        [Inject]
        public void Construct(IOffsetCalculator offsetCalculator)
        {
            _offsetCalculator = offsetCalculator;
        }

        private void FixedUpdate()
        {
            Vector3 offset = _offsetCalculator.CalculateOffset();
            transform.position = transform.position + offset * Time.fixedDeltaTime;
        }
    }
}

