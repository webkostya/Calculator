using System.Globalization;
using UI.Windows.Common;
using System.Data;
using Main.Common;
using Main.Models;
using UnityEngine;
using UI.Windows;
using Handlers;
using System;
using Common;

namespace Main
{
    public class MainPresent : MonoBehaviour
    {
        private IMainData<ModelMain> _model;
        private IMainData<string> _view;

        private static WindowBehaviour WindowBehaviour => WindowBehaviour.Instance;
        private static GameHandler GameHandler => GameHandler.Instance;

        private void Awake()
        {
            _model = GetComponent<MainModel>();
            _view = GetComponent<MainView>();
        }

        private void Start()
        {
            GameHandler.OnUpdateState += OnUpdateGameState;

            var modelData = _model.GetData();

            _view.SetData(modelData.main);
        }

        /// <summary>
        /// Update Game State Event
        /// </summary>
        /// <param name="state"></param>
        private void OnUpdateGameState(GameState state)
        {
            _view.SetData(string.Empty);
            _model.SetData(null);
        }

        /// <summary>
        /// Evaluate Expression
        /// </summary>
        public void InvokeResultAction()
        {
            var expression = _view.GetData();

            try
            {
                var evaluate = Evaluate(expression);

                if (!float.IsNaN(evaluate) && !float.IsInfinity(evaluate))
                {
                    _view.SetData(evaluate.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    WindowBehaviour.FadeWindow(WindowType.Error, true);

                    _view.SetData(string.Empty);
                }
            }
            catch (Exception)
            {
                WindowBehaviour.FadeWindow(WindowType.Error, true);

                _view.SetData(string.Empty);
            }
        }

        /// <summary>
        /// Evaluate expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static float Evaluate(string expression)
        {
            var data = new DataTable();

            var output = data.Compute(expression, null);

            return float.Parse(output.ToString());
        }

        /// <summary>
        /// Save Data To Storage
        /// </summary>
        private void SaveDataToStorage()
        {
            var modelData = _model.GetData();
            var viewData = _view.GetData();

            modelData.main = viewData;

            _model.SetData(modelData);
        }

        private void OnDestroy()
        {
            GameHandler.OnUpdateState -= OnUpdateGameState;
        }

        private void OnApplicationFocus(bool isFocus)
        {
            if (!isFocus)
            {
                SaveDataToStorage();
            }
        }

        private void OnApplicationPause(bool isPause)
        {
            if (isPause)
            {
                SaveDataToStorage();
            }
        }

        private void OnApplicationQuit()
        {
            SaveDataToStorage();
        }
    }
}