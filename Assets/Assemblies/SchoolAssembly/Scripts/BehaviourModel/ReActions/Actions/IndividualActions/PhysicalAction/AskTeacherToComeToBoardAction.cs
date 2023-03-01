using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class AskTeacherToComeToBoardAction : MotivationSpeech,IStructuredSpeech, ICompletedAction
    {
        public override IEnumerator TryPerformAction()
        {
            var cast = (PupilAgent)ActionActor;
            if (cast.CurrentEvent is LessonEvent && ReactionSource is TeacherAgent teacher)
            {
                cast.SetState<IndividualSpeechState<PupilAgent, TeacherAgent>>();
                ((IndividualSpeechState<PupilAgent, TeacherAgent>)cast.CurrentState).Initiate(cast, teacher, this);
                yield return cast.CurrentState.StartState();
            }
            cast.SetDefaultState();
        }

        public DialogNode CreateSpeechStructure()
        {
            var cast = (PupilAgent)ActionActor;
            //var cast2 = (TeacherAgent)ReactionSource;

            var builder = new DialogStructureBuilder();
            var startSpeech = this;
            var structure = builder.AddReplicaResponseAwaitNode(startSpeech)
                .AddResponseReactionOptionToCurrentNode(new YesAnswer(startSpeech), new GoToBoardAction(cast))
                .AddResponseReactionOptionToCurrentNode(new NoAnswer(startSpeech), new ReactionToRejectionAction(cast))
                .GetDialog();
            return structure;
        }
        public override IEnumerator Speak<TInitiator, TResponder>(DialogProcess<TInitiator, TResponder> dialog)
        {
            //просьба выйти к доске
            DialogNode startNode = CreateSpeechStructure();
            yield return dialog.StartDialog(startNode);
            //какое-то текстовое отображение спича?
        }
    }
}
