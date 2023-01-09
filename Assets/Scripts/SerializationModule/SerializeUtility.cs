using Common;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SerializationModule
{
    public class SerializeUtility
    {
        private string appDirectory = $"{Application.dataPath}/SaveData";

        public List<(T data, string dataPath)> LoadDataList<T>()
        {
            var res = new List<(T agent, string path)>();
            var fullPath = $"{appDirectory}/{typeof(T).Name}";
            if (Directory.Exists(fullPath))
            {
                var agentsPaths = Directory.GetFiles(fullPath);
                foreach (var ap in agentsPaths)
                {
                    var fi = new FileInfo(ap);
                    if (fi.Extension.Equals(".json"))
                    {
                        var json = File.ReadAllText(ap);
                        var rawData = JsonUtility.FromJson<T>(json);
                        res.Add((rawData, ap));
                    }
                }
            }
            return res;
        }

        public void RemoveAgent(string path)
        {
            if (File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Extension.Equals(".json"))
                    File.Delete(path);
            }
        }

        /// <summary>
        /// Возвращает null если для данного имени существует файл
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public string SaveAgent<T>(T agent, string fileName)
        {
            var translator = new Translator();
            var fullPath = $"{appDirectory}/{typeof(T).Name}";
            var filePath = $"{fullPath}/{translator.ToEnglish(fileName)}.json";
            if (File.Exists(filePath))
                return default;
            string json = JsonUtility.ToJson(agent, true);
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
            File.WriteAllText(filePath, json);
            return filePath;
        }
    }
}