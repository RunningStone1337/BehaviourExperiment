using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Стейт бездействия
    /// </summary>
    public class IdleAgentState<T> : SchoolAgentStateBase<T>, IOptionalToCompleteState
        where T : SchoolAgentBase<T>
    {
        //public override bool StateBreaked { get => stateBreaked; set => stateBreaked = value; }

        public override IEnumerator StartState()
        {
            yield return new WaitForFixedUpdate();
            ///определяемся что делать учитывая обстановку
            ///узнаем текущее событие
            //var curEvent = thisAgent.EnvironmentInfo.CurrentGlobalEvent;
            //var expectedActions = curEvent.GetExpectedActions(thisAgent.EnvironmentInfo, thisAgent);
            //var unexpectedActions = curEvent.GetUnexpectedActions(thisAgent.EnvironmentInfo, thisAgent);
            ///принимаем решение
        }
    }
}