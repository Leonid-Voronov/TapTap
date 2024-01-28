using Player;
using UnityEngine;

public class PlayerTag : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;
    public Jumper Jumper => _jumper;
}
