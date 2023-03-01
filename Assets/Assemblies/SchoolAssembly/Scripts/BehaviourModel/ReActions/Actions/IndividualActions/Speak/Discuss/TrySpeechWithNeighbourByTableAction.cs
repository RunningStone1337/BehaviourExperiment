using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class TrySpeechWithNeighbourByTableAction : DiscussThingSpeech, IStructuredSpeech, ICompletedAction
    {
        public override IEnumerator TryPerformAction()
        {
            var actorCast = (PupilAgent)ActionActor;
            if (actorCast.CurrentEvent is LessonEvent le)
            {
                var secondCast = ReactionSource as PupilAgent;
                if (secondCast != null)
                {
                    //TODO оба сидят - но нет гарантии, что рядом, нужна проверка парты
                    var table1 = actorCast.AgentEnvironment.TableInfo;
                    var table2 = secondCast.AgentEnvironment.TableInfo;
                    var oneTable = table1 == table2;
                    if (actorCast.AgentEnvironment.ChairInfo != null && secondCast.AgentEnvironment.ChairInfo != null && oneTable)
                    {
                        actorCast.SetState<IndividualSpeechState<PupilAgent, PupilAgent>>();
                        ((IndividualSpeechState<PupilAgent, PupilAgent>)actorCast.CurrentState).Initiate(actorCast, secondCast, this);
                        yield return actorCast.CurrentState.StartState();
                        WasPerformed = true;
                    }
                }
            }
            actorCast.SetDefaultState();
        }

        public override IEnumerator Speak<TInitiator, TResponder>(DialogProcess<TInitiator, TResponder> dialog)
        {
            DialogNode startNode = CreateSpeechStructure();
            yield return dialog.StartDialog(startNode);
            //var speechActionsTable = dialog.SpeechInitiator.TablesHandler.CharacterToPupilReactionsTable;
            //yield return dialog.TryStartRandomDialog(speechActionsTable, dialog.SpeechInitiator.CurrentEvent.Name);
            //изменения состояний по результатам диалога?
        }

        public DialogNode CreateSpeechStructure()
        {
            var builder = new DialogStructureBuilder();
            var options = new List<SpeakAction>() {
                new DiscussGamesSpeech(ActionActor, ReactionSource),
                new DiscussLessonSpeech(ActionActor, ReactionSource),
                new DiscussSomethingElse(ActionActor, ReactionSource),
            };
            var startSpeech = options.Random();
            var firstContactOption1 = (new YesAnswer(startSpeech), new PositiveDiscussingSpeech(ActionActor, ReactionSource));
            var firstContactOption2 = (new NoAnswer(startSpeech), new ReactionToRejectionAction((PupilAgent)ActionActor));
            var node = builder.AddReplicaResponseAwaitNode(startSpeech)
                .AddResponseReactionOptionToCurrentNode(firstContactOption1.Item1, firstContactOption1.Item2)
                .AddResponseReactionOptionToCurrentNode(firstContactOption2.Item1, firstContactOption2.Item2)
                .GetDialog();
            return node;
        }

        public TrySpeechWithNeighbourByTableAction():base()
        {

        }
    }
}
