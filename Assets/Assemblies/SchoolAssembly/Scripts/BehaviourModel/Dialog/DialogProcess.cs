using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public class DialogProcess<TInitiator, TResponder>
        where TInitiator: SchoolAgentBase<TInitiator>
        where TResponder : SchoolAgentBase<TResponder>
    {
        private TInitiator speechInitiator;
        private TResponder speechResponder;
        public TResponder SpeechResponder=> speechResponder;
        public TInitiator SpeechInitiator => speechInitiator;
        private RelationshipBase<TInitiator, IAgent, SchoolAgentStateBase<TInitiator>> relations;
        public SpeakAction LastAnswer { get; set; }
        DialogNode currentNode;
        public DialogNode CurrentNode => currentNode;
        ReactionBase dialogResult;
        public ReactionBase DialogResult { get => dialogResult; set => dialogResult = value; }

        public DialogProcess(TInitiator initiator, TResponder responder)
        {
            speechInitiator = initiator;
            speechResponder = responder;
            relations = speechInitiator.RelationsSystem.GetCurrentRelationTo(speechResponder);
        }

        public IEnumerator StartDialog(DialogNode structure)
        {
            yield return StartDialogFrom(structure);
        }

        //private IEnumerator StartRandomDialogFrom(SpeakAction selectedAction)
        //{
        //    /////////////////////////////////
        //    ///нужна структура диалога
        //    ///логично будет описать структуру в самом selectedAction
        //    DialogNode structure = DialogNode.CreateStructureFor<TInitiator>(selectedAction, relations);
        //    yield return StartDialogFrom(structure);
        //    /////////////////////////////////
        //}

        private IEnumerator StartDialogFrom(DialogNode structure)
        {
            currentNode = structure;
            while (currentNode != null)
            {
                yield return currentNode.Speak(this);
                currentNode = currentNode.Next;
            }
        }

       

        //public IEnumerator TryStartRandomDialog(CharacterToPhenomReactionsLists speechesSourceTable, string tableDimensionName)
        //{
        //    var selectedAction = GetAllAvailableSpeeches(speechesSourceTable, tableDimensionName).Random();
        //    selectedAction.ActionActor = speechInitiator;
        //    selectedAction.ReactionSource = speechResponder;
        //    yield return StartRandomDialogFrom(selectedAction);
        //}

       

        List<SpeakAction> GetAllAvailableSpeeches(CharacterToPhenomReactionsLists table, string tableDimensionName)
        {
            var colName = relations != null ? relations.ToString() : "NonFamiliar";

            return table.GetTableValuesFor<TInitiator, ReactionBase, FeatureBase, SchoolAgentStateBase<TInitiator>, Sensor>
                (speechInitiator, tableDimensionName, colName)
                .SelectMany(x => x.GetReactions()).Where(x => x is SpeakAction).Cast<SpeakAction>().ToList();
        }
    }
}
