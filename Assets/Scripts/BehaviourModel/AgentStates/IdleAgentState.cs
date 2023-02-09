using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// ����� �����������
    /// </summary>
    public class IdleAgentState : SchoolAgentStateBase
    {
        public override bool StateBreaked { get => stateBreaked; set => stateBreaked = value; }

        public override IEnumerator StartState()
        {
            yield return new WaitForFixedUpdate();
            ///������������ ��� ������ �������� ����������
            ///������ ������� �������
            //var curEvent = thisAgent.EnvironmentInfo.CurrentGlobalEvent;
            //var expectedActions = curEvent.GetExpectedActions(thisAgent.EnvironmentInfo, thisAgent);
            //var unexpectedActions = curEvent.GetUnexpectedActions(thisAgent.EnvironmentInfo, thisAgent);
            ///��������� �������
        }
    }
}