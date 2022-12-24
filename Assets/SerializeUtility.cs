using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UI;
using UnityEngine;

namespace SerializationModule
{
    public class SerializeUtility
    {
        string agentsDirectory = $"{Application.dataPath}/Agents";
        public List<(AgentRawData agent, string path)> LoadAgents()
        {
            var res = new List<(AgentRawData agent, string path)>();
            if (Directory.Exists(agentsDirectory))
            {
                var agentsPaths = Directory.GetFiles(agentsDirectory, ".json");
                foreach (var ap in agentsPaths)
                {
                    var json = File.ReadAllText(ap);
                    var rawData = JsonUtility.FromJson<AgentRawData>(json);
                    res.Add((rawData,ap));
                }
            }
            return res;
        }

        public void RemoveAgent(string path)
        {
            if (File.Exists(path)) {
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Extension.Equals("json"))
                {
                    File.Delete(path);
                }
            }
        }

        public string SaveAgent(AgentRawData agent)
        {            
            string json = JsonUtility.ToJson(agent, true);
            if (!Directory.Exists(agentsDirectory))
                Directory.CreateDirectory(agentsDirectory);
            var translator = new Translator();
            var path = $"{agentsDirectory}/{translator.ToEnglish(agent.AgentName)}.json";
            if (!File.Exists(path))
                File.WriteAllText(path, json);
            return path;
        }
    }
}