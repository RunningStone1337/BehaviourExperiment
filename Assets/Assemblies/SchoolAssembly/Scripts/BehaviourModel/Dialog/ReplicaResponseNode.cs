//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//namespace BehaviourModel
//{
//    public class ReplicaResponseNode : DialogNode
//    {

//        private SpeakAction nodeSpeech;
//        public SpeakAction ThisNodeSpeech => nodeSpeech;
//        Dictionary<SpeakAction, ReactionBase> answersAndReactions;
//        public Dictionary<SpeakAction, ReactionBase> AnswersAndReactions => answersAndReactions;
//        Dictionary<SpeakAction, DialogNode> answersAndTransitions;
//        public Dictionary<SpeakAction, DialogNode> AnswersAndTransitions => answersAndTransitions;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="speakAction">Speak replica</param>
//        /// <param name="probForks">List of probably transitions from this <paramref name="speakAction"/></param>
//        //public ReplicaResponseNode(SpeakAction speakAction, List<ResponseReactionNode> probForks)
//        //{
//        //    nodeSpeech = speakAction;
//        //    answersAndReactions = new Dictionary<SpeakAction, ReactionBase>();
//        //    foreach (var node in probForks)
//        //    {
//        //        answersAndReactions.Add(node.Response, node.ThisNodeReaction);
//        //    }
//        //}

//        public ReplicaResponseNode(SpeakAction speakAction)
//        {
//            nodeSpeech = speakAction;
//            answersAndReactions = new Dictionary<SpeakAction, ReactionBase>();
//            answersAndTransitions = new Dictionary<SpeakAction, DialogNode>();
//        }

//        //public override IEnumerator Speak<TInitiator, TResponder>(DialogProcess<TInitiator, TResponder> dialogProcess)
//        //{
//        //    yield return null;
//        //    //yield return ThisNodeSpeech.Speak(dialogProcess);
//        //    //получить ответ ответчика из перечня ожидаемых
//        //    //yield return dialogProcess.SpeechResponder.ResponseToSpeechFromOptions(ThisNodeSpeech, dialogProcess, AnswersAndReactions.Keys.ToList());
//        //    if (dialogProcess.SpeechResponse == null)
//        //        throw new Exception("Answer to dialog action must not be null");
//        //    //должно выполняться не в диалоге, а после него
//        //    dialogProcess.DialogResult = AnswersAndReactions[dialogProcess.SpeechResponse];
//        //    Next = null;
//        //}
//    }
//}
