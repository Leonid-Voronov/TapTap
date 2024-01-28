using UnityEngine;

namespace Environment
{
    public class ActionButton : MonoBehaviour
    {
        [SerializeField] private ActionButtonTag _buttonTag;
        public ActionButtonTag ButtonTag => _buttonTag;
    }

    public enum ActionButtonTag
    {
        Left = 0,
        Right = 1,
        Up = 2,
        None = 3,
    }
}

