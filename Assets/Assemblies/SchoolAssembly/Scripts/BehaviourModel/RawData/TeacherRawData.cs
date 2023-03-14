using System;
using UI;

namespace BehaviourModel
{
    [Serializable]
    public class TeacherRawData : HumanRawData
    {
        public BehaviourPatternBase behModel;

        public override void Initiate(AgentCreationScreen acs)
        {
            base.Initiate(acs);
            //behModel = acs.PrefferedBehaviourRect.SelectedModel;
        }
    }
}