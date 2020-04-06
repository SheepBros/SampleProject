using System;
using System.IO;
using UnityEngine;
using SB.Async;
using Newtonsoft.Json;

namespace SB.UI
{
    /// <summary>
    /// This has a responsibility to load UI data from local.
    /// </summary>
    public class UIDataIOController : IUIDataIOController
    {
        private const string DataFileName = "UISceneList.json";

        /// <inheritdoc cref="IUIDataIOController.Load"/>
        public IPromise<UISceneList> Load()
        {
            Promise<UISceneList> promise = new Promise<UISceneList>();
            using (StreamReader textReader = new StreamReader($"{Application.dataPath}/Resources/{DataFileName}"))
            {
                string serializedData = textReader.ReadToEnd();
                UISceneList sceneList = JsonConvert.DeserializeObject<UISceneList>(serializedData);
                promise.Resolve(sceneList);
            }

            return promise;
        }

        /// <inheritdoc cref="IUIDataIOController.Save"/>
        public void Save(UISceneList sceneList)
        {
            string serializedData = JsonConvert.SerializeObject(sceneList);
            using (StreamWriter textWriter = new StreamWriter($"{Application.dataPath}/Resources/{DataFileName}", false))
            {
                textWriter.Write(serializedData);
            }
        }
    }
}