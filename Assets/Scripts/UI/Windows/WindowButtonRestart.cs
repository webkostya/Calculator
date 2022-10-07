using UI.Windows.Common;
using UI.Common.Buttons;
using UnityEngine;
using Handlers;
using Common;

namespace UI.Windows
{
    public class WindowButtonRestart : ButtonBase
    {
        [SerializeField]
        private WindowType type;

        private static WindowBehaviour WindowBehaviour => WindowBehaviour.Instance;

        private static GameHandler GameHandler => GameHandler.Instance;

        /// <summary>
        /// Invoke Click Action
        /// </summary>
        protected override void InvokeAction()
        {
            WindowBehaviour.FadeWindow(type, false);

            GameHandler.SetState(GameState.Restart);
        }
    }
}