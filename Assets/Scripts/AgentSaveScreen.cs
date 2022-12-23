using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class AgentSaveScreen : UIScreenBase
    {
        [SerializeField] List<AgentCardPreview> existAgents;
        public override void InitiateState()
        {
            base.InitiateState();
        }
        void Save()
        {
            //string json;
            //if (CurrentData != null)
            //{
            //    CurrentData.Initiate(this);
            //    json = JsonUtility.ToJson(CurrentData);
            //}
            //else
            //{
            //    AgentRawData rawData = gameObject.AddComponent<AgentRawData>();
            //    rawData.Initiate(this);
            //    json = JsonUtility.ToJson(rawData);
            //}
        }
    }
}