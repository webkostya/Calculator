using UnityEngine;

namespace Modules.Storage
{
    public static class StorageData<T> where T : new()
    {
        private const string DataKey = "app.data.main";

        /// <summary>
        /// Public Data
        /// </summary>
        public static T Data
        {
            get => GetData(DataKey);
            set => SetData(value, DataKey);
        }

        /// <summary>
        /// Get Data By Type
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T GetData(string key)
        {
            var json = PlayerPrefs.GetString(key);
            var data = JsonUtility.FromJson<T>(json);

            return data ?? new T();
        }

        /// <summary>
        /// Set Data By Type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        private static void SetData(T value, string key)
        {
            var json = JsonUtility.ToJson(value ?? new T());

            PlayerPrefs.SetString(key, json);
        }
    }
}