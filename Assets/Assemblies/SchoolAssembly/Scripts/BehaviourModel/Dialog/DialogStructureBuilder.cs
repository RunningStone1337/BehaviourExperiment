using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class DialogStructureBuilder
    {
        DialogNode startNode, currentNode;
        public DialogStructureBuilder AddReplicaResponseAwaitNode(SpeakAction nodeSpeech)
        {
            if (currentNode != null)
            {
                currentNode.Next = new ReplicaResponseNode(nodeSpeech);
                currentNode = currentNode.Next;
            }
            else
            {
                currentNode = new ReplicaResponseNode(nodeSpeech);
            }
            if (startNode == null)
                startNode = currentNode;
            return this;
        }
        public DialogStructureBuilder AddResponseReactionOptionToCurrentNode(SpeakAction responseOption, ReactionBase reactionToResponse)
        {
            if (currentNode is ReplicaResponseNode rrn)
            {
                rrn.AnswersAndReactions.Add(responseOption, reactionToResponse);
            }
            else throw new Exception($"You can't add response ontions to current node {currentNode}");
            return this;
        }


        public DialogNode GetDialog()
        {
            return startNode;
        }
    }
}
