//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace BehaviourModel
//{
//    public class TeacherAnsweringToRequestState<TSpeaker> : SchoolAgentStateBase<TeacherAgent>
//            where TSpeaker : SchoolAgentBase<TSpeaker>
//    {
//        TSpeaker speakerAgent;
//        IPhenomenon answerPhenom;
//        float answeringTime;
//        public override IEnumerator StartState()
//        {
//            yield return new WaitForSeconds(answeringTime);
//            if (answerPhenom is AskGoToBoardSpeech gtba)
//                thisAgent.LastAnswer = new YesAnswer(gtba);
//            else
//                thisAgent.LastAnswer = new NoAnswer(answerPhenom);
//        }

//        public void Initiate(TeacherAgent teacherAgent, TSpeaker speaker, IPhenomenon phenomToAnswer)
//        {
//            base.Initiate(teacherAgent);
//            speakerAgent = speaker;
//            answerPhenom = phenomToAnswer;
//            answeringTime = 3.5f;
//        }
//    }
//}
