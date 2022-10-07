using Modules.Storage;
using Main.Common;
using UnityEngine;
using Main.Models;

namespace Main
{
    public class MainModel : MonoBehaviour, IMainData<ModelMain>
    {
        /// <summary>
        /// Get Main Data
        /// </summary>
        /// <returns></returns>
        public ModelMain GetData()
        {
            return StorageData<ModelMain>.Data;
        }

        /// <summary>
        /// Set Main Data
        /// </summary>
        /// <returns></returns>
        public void SetData(ModelMain data)
        {
            StorageData<ModelMain>.Data = data;
        }
    }
}