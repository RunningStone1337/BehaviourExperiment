using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class DialogNode 
    {
        protected DialogNode next;
        public DialogNode Next { get=> next; set=> next = value; }

        //public abstract IEnumerator Speak<TInitiator, TResponder>(DialogProcess<TInitiator, TResponder> dialogProcess)
        //    where TInitiator : SchoolAgentBase<TInitiator>
        //    where TResponder : SchoolAgentBase<TResponder>;

        //public static DialogNode CreateStructureFor<TInitiator>(SpeakAction selectedAction, RelationshipBase<TInitiator, IAgent, SchoolAgentStateBase<TInitiator>> relations)
        //where TInitiator: SchoolAgentBase<TInitiator>
        //{
        //    if (selectedAction is ContactSpeech contact)
        //    {
        //        if (relations == null)
        //        {

        //        }
        //        else
        //        {

        //        }
        //        return default;
        //    }
        //    else if (selectedAction is CoordinationSpeech coordinationsp)
        //    {
        //        return default;
        //    }
        //    else if (selectedAction is DiscussThingSpeech discuss)
        //    {
        //        return default;

        //    }
        //    else if (selectedAction is EmotionalSpeech emotion)
        //    {
        //        return default;

        //    }
        //    else if (selectedAction is MotivationSpeech motiv)
        //    {
        //        return default;

        //    }
        //    else throw new Exception($"Undefined speech type {selectedAction}");
        //}

       
        //NodeType thisNodeType;
        //public NodeType ThisNodeType=> thisNodeType;

        //private List<DialogNode> probablyAnswersAndReactions;
        //Dictionary<SpeakAction, DialogNode> answersAndTransitions;

        //public Dictionary<SpeakAction, DialogNode> AnswersAndTransitions => answersAndTransitions;
    }
}
