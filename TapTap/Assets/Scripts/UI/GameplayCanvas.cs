using Input;
using UnityEngine;

namespace UI
{
    public class GameplayCanvas : MonoBehaviour
    {
        [SerializeField] private TapReceiver _tapReceiver;
        public TapReceiver TapReceiver => _tapReceiver;
    }
}