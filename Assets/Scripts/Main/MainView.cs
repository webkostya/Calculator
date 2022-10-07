using System.Text.RegularExpressions;
using Main.Common;
using UnityEngine;
using System;
using TMPro;

namespace Main
{
    public class MainView : MonoBehaviour, IMainData<string>
    {
        [SerializeField]
        private TMP_InputField input;

        private const string RegexPattern = @"[0-9/]";

        private void Start()
        {
            input.onValidateInput += InvokeValidate;
        }

        /// <summary>
        /// Input Validation
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private static char InvokeValidate(string content, int index, char symbol)
        {
            var regex = new Regex(RegexPattern);

            if (!regex.IsMatch(symbol.ToString()))
            {
                return '\0';
            }

            if (char.IsNumber(symbol))
            {
                return symbol;
            }

            if (content.Length == 0 || index == 0)
            {
                return '\0';
            }

            var prevChar = content[Math.Max(0, index - 1)];
            var nextChar = content[Math.Min(content.Length - 1, index)];

            if (!prevChar.Equals(symbol) && !nextChar.Equals(symbol))
            {
                return symbol;
            }

            return '\0';
        }

        /// <summary>
        /// Get Main Data
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            var output = input.text;

            var content = Regex.Replace(output, RegexPattern, string.Empty);

            return content.Length == 0 ? output : string.Empty;
        }

        /// <summary>
        /// Set Main Data
        /// </summary>
        /// <param name="data"></param>
        public void SetData(string data)
        {
            input.text = data;
        }

        private void OnDestroy()
        {
            input.onValidateInput -= InvokeValidate;
        }
    }
}