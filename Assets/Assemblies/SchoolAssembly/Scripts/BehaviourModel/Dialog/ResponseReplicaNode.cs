using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class ResponseReplicaNode : DialogNode
    {
        DialogNode nextNode;
        SpeakAction replicaAction;
        public ResponseReplicaNode(SpeakAction speakAction, DialogNode reactionNode)
        {
            replicaAction = speakAction;
            nextNode = reactionNode;
            //thisNodeType = NodeType.NodeToNodeNode;
            //nodeSpeech = speakAction;
            ////probablyAnswersAndReactions = probForks;
            //answersAndTransitions = new Dictionary<SpeakAction, DialogNode>();
            //if (reactionNode.thisNodeType == NodeType.NodeToReaction)
            //    answersAndTransitions.Add(reactionNode.nodeSpeech, reactionNode.thisNodeReaction);
        }

        public override IEnumerator Speak<TInitiator, TResponder>(DialogProcess<TInitiator, TResponder> dialogProcess)
        {
            throw new System.NotImplementedException();
        }
    }
}
