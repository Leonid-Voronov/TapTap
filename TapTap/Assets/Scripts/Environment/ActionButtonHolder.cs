using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class ActionButtonHolder : MonoBehaviour, INextButtonGetter
    {
        [SerializeField] private List<ActionButton> _actionButtons = new List<ActionButton>();
        private int _currentIndex = 0;

        public ActionButtonTag GetNextTag()
        {
            _currentIndex++;

            if (_currentIndex - 1 >= _actionButtons.Count)
                return ActionButtonTag.None;

            return _actionButtons[_currentIndex - 1].ButtonTag;
        }
    }
}

