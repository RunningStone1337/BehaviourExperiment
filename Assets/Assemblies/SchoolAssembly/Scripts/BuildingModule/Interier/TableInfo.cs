using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class TableInfo : InterierInfoBase<TableInterier>
    {
        protected IAgent[] thisAgents;
        public IAgent[] TableAgents { get => thisAgents; set => thisAgents = value; }
        private void Awake()
        {
            thisAgents = new IAgent[2];
        }

        public void AddAgentIfFree<TAgent>(TAgent schoolAgentBase) 
            where TAgent : IAgent
        {
            if (TableAgents[0] == null)
                TableAgents[0] = schoolAgentBase;
            else if (TableAgents[1] == null)
                TableAgents[1] = schoolAgentBase;
        }

        public void RemoveAgent<TAgent>(SchoolAgentBase<TAgent> schoolAgentBase)
            where TAgent : SchoolAgentBase<TAgent>
        {
            if (TableAgents[0] == schoolAgentBase)
                TableAgents[0] = null;
            else if (TableAgents[1] == schoolAgentBase)
                TableAgents[1] = null;
        }
    }
}
