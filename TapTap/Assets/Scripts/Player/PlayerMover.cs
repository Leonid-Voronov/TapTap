using Input;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private Jumper _jumper;
        private IOffsetCalculator _offsetCalculator;
        private float _currentJumpOffset = 0f;

        [Inject]
        public void Construct(IOffsetCalculator offsetCalculator)
        {
            _offsetCalculator = offsetCalculator;
        }


        private void FixedUpdate()
        {
            Vector3 offset = _offsetCalculator.CalculateOffset();
            Vector3 jumpOffsetInFrame = new Vector3 (0, _jumper.GetJumpOffset() - _currentJumpOffset, 0);
            _currentJumpOffset = _jumper.GetJumpOffset();

            //Debug.Log(jumpOffsetInFrame.y);

            transform.position = transform.position + ((offset + jumpOffsetInFrame) * Time.fixedDeltaTime);
        }

    }
}

