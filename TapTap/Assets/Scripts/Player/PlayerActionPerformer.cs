using Environment;
using Input;
using Player;
using System;
using UnityEngine;
using Zenject;

public class PlayerActionPerformer : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private IPlayerDirection _playerDirection;
    [SerializeField] private Jumper _jumper;
    private ITapReceiver _tapReceiver;
    private INextButtonGetter _nextButtonGetter;

    private Quaternion _rightRotation = Quaternion.Euler(0, 90, 0);
    private Quaternion _leftRotation = Quaternion.Euler(0, -90, 0);

    [Inject]
    public void Construct(ITapReceiver tapReceiver, IPlayerDirection playerDirection, INextButtonGetter nextButtonGetter)
    {
        _tapReceiver = tapReceiver;
        _playerDirection = playerDirection;
        _nextButtonGetter = nextButtonGetter;
    }

    private void OnEnable()
    {
        _tapReceiver.TapPressed += PerformAction;
    }

    private void PerformAction(object sender, EventArgs e)
    {
        ActionButtonTag tag = _nextButtonGetter.GetNextTag();

        switch (tag)
        {
            case ActionButtonTag.Left:
                _playerDirection.SetDirection(_leftRotation);
                break;

            case ActionButtonTag.Right:
                _playerDirection.SetDirection(_rightRotation);
                break;

            case ActionButtonTag.Up:
                _jumper.StartJump();
                break;

            default:
                break;
        }
    }

    private void OnDisable()
    {
        _tapReceiver.TapPressed -= PerformAction;
    }
}
