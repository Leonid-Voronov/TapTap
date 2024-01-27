using UnityEngine;

namespace Player
{
    public interface IPlayerDirection 
    {
        Vector3 CurrentDirection { get; }
    }
}