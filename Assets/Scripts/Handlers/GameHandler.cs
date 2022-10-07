using UnityEngine;
using Common;
using System;

namespace Handlers
{
    public class GameHandler : MonoBehaviour
    {
        public event Action<GameState> OnUpdateState;

        public static GameHandler Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// Update Game State
        /// </summary>
        /// <param name="state"></param>
        public void SetState(GameState state)
        {
            OnUpdateState?.Invoke(state);

            if (state == GameState.Quit)
            {
                Application.Quit();
            }
        }
    }
}