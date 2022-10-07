using System.Collections.Generic;
using UI.Windows.Common;
using UnityEngine;
using System.Linq;

namespace UI.Windows
{
    public class WindowBehaviour : MonoBehaviour
    {
        public static WindowBehaviour Instance { get; private set; }

        private Dictionary<WindowType, WindowBase> _windows;

        private void Awake()
        {
            Instance = this;

            _windows = FindNestedWindows();
        }

        /// <summary>
        /// Get All Nested Windows
        /// </summary>
        /// <returns></returns>
        private Dictionary<WindowType, WindowBase> FindNestedWindows()
        {
            var windows = GetComponentsInChildren<WindowBase>(true);

            return windows.ToDictionary(window => ((IWindowEvents)window).WindowType, window => window);
        }

        /// <summary>
        /// Get Window By Type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="window"></param>
        /// <returns></returns>
        private bool GetWindow(WindowType type, out WindowBase window)
        {
            return (bool)(_windows.ContainsKey(type) ? window = _windows[type] : window = null);
        }

        /// <summary>
        /// Show/Hide Window
        /// </summary>
        /// <param name="type"></param>
        /// <param name="isActive"></param>
        public void FadeWindow(WindowType type, bool isActive)
        {
            if (GetWindow(type, out var window))
            {
                window.SetActive(isActive);
            }
        }
    }
}