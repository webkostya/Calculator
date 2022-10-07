using UnityEngine.UI;
using UnityEngine;

namespace UI.Common.Buttons
{
    public abstract class ButtonBase : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        protected virtual void Start()
        {
            _button.onClick.AddListener(InvokeAction);
        }

        /// <summary>
        /// Invoke Click Action
        /// </summary>
        protected abstract void InvokeAction();

        protected virtual void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}