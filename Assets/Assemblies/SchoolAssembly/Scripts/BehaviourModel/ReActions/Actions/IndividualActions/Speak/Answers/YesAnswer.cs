using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class YesAnswer : AnswerBase
    {

        public YesAnswer(SpeakAction subjectOfResponse):base(subjectOfResponse)
        {
        }

        public override IEnumerator Speak<TInitiator, TResponder>(DialogProcess<TInitiator, TResponder> dialog)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}
