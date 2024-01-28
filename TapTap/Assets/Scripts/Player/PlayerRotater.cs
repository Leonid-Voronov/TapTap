using Input;
using Player;
using System;
using UnityEngine;
using Zenject;

public class PlayerRotater : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private IPlayerDirection _playerDirection;
    private ITapReceiver _tapReceiver;

    private Quaternion _rightRotation = Quaternion.Euler(0, 90, 0);
    private Quaternion _leftRotation = Quaternion.Euler(0, -90, 0);

    [Inject]
    public void Construct(ITapReceiver tapReceiver, IPlayerDirection playerDirection)
    {
        _tapReceiver = tapReceiver;
        _playerDirection = playerDirection;
    }

    private void OnEnable()
    {
        _tapReceiver.TapPressed += RotatePlayer;
    }

    private void RotatePlayer(object sender, EventArgs e)
    {
        //_playerDirection.SetDirection(_leftRotation);
    }

    private void OnDisable()
    {
        _tapReceiver.TapPressed -= RotatePlayer;
    }
}
