using UI.Windows.Common;
using UnityEngine;

namespace UI.Windows
{
    public class WindowBase : MonoBehaviour, IWindowEvents
    {
        [SerializeField]
        private WindowType windowType;

        public WindowType WindowType => windowType;

        /// <summary>
        /// Set Active State
        /// </summary>
        /// <param name="isActive"></param>
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}