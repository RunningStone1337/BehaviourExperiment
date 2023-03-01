//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace BehaviourModel
//{
//    public class RequestForYesNoAnswer<TThisAgent, TAskTarget> : SchoolAgentStateBase<TThisAgent>
//        where TThisAgent : SchoolAgentBase<TThisAgent>
//        where TAskTarget : SchoolAgentBase<TAskTarget>
//    {
//        IPhenomenon targetAction;
//        public IPhenomenon TargetAction => targetAction;
//        TAskTarget askTarget;
//        float speechTime;

//        public override IEnumerator StartState()
//        {
//            yield return new WaitForSeconds(speechTime);
//            yield return askTarget.AnswerToReqestRoutine(thisAgent, targetAction);
//        }

//        public void Initiate(TThisAgent thisAgent, TAskTarget actionAskTarget, ActionBase actionToDo)
//        {
//            base.Initiate(thisAgent);
//            targetAction = actionToDo;
//            askTarget = actionAskTarget;
//            speechTime = 4f - thisAgent.CharacterSystem.TimidityCourage.RawCharacterValue/5f;
//        }
//    }
//}
