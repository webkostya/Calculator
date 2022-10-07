using UI.Common.Buttons;
using Handlers;
using Common;

namespace UI.Windows
{
    public class WindowButtonQuit : ButtonBase
    {
        private static GameHandler GameHandler => GameHandler.Instance;

        /// <summary>
        /// Invoke Click Action
        /// </summary>
        protected override void InvokeAction()
        {
            GameHandler.SetState(GameState.Quit);
        }
    }
}