using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AnswerBase: SpeakAction
    {
        public IPhenomenon SubjectOfResponse { get; private set; }

        protected AnswerBase(IPhenomenon subjectOfResponse):base()
        {
            SubjectOfResponse = subjectOfResponse;
        }
    }
}
