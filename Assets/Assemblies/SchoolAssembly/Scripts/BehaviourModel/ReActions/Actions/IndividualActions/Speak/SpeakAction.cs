using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SpeakAction : IndividualAction
    {
        /// <summary>
        /// As a result of speak action must be <paramref name="dialog"/> last answer property
        /// </summary>
        /// <typeparam name="TInitiator"></typeparam>
        /// <typeparam name="TResponder"></typeparam>
        /// <param name="dialog"></param>
        /// <returns></returns>
        public abstract IEnumerator Speak<TInitiator, TResponder>(DialogProcess<TInitiator, TResponder> dialog)
            where TInitiator : SchoolAgentBase<TInitiator>
            where TResponder : SchoolAgentBase<TResponder>;

        protected SpeakAction():base()
        {
        }
    }
}