using Player;
using UnityEngine;

public class PlayerTag : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;
    [SerializeField] private PlayerGroundChecker _groundChecker;
    public Jumper Jumper => _jumper;
    public PlayerGroundChecker GroundChecker => _groundChecker;
}
