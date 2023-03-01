using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class NoAnswer : AnswerBase
    {
        public NoAnswer(IPhenomenon subjectOfResponse) : base(subjectOfResponse)
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
