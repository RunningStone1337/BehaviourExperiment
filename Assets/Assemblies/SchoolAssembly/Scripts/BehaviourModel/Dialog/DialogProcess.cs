using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Class handles dialog process in time
    /// </summary>
    /// <typeparam name="TInitiator"></typeparam>
    /// <typeparam name="TResponder"></typeparam>
    public class DialogProcess<TInitiator, TResponder>
        where TInitiator: SchoolAgentBase<TInitiator>
        where TResponder : SchoolAgentBase<TResponder>
    {
        private TInitiator speechInitiator;
        private TResponder speechResponder;
        public TResponder SpeechResponder=> speechResponder;
        public TInitiator SpeechInitiator => speechInitiator;
        private RelationshipBase<TInitiator, IAgent, SchoolAgentStateBase<TInitiator>> relations;
        public SpeakAction<TResponder, TInitiator> SpeechResponse { get; set; }
        //ReactionBase dialogResult;
        //public ReactionBase DialogResult { get => dialogResult; set => dialogResult = value; }

        public DialogProcess(TInitiator initiator, TResponder responder)
        {
            speechInitiator = initiator;
            speechResponder = responder;
            relations = speechInitiator.RelationsSystem.GetCurrentRelationTo(speechResponder);
        }

        
        public IEnumerator StartDialog(SpeakAction<TInitiator, TResponder> speech)
        {
            speechInitiator.StartActionVisual(speech);
            //Debug.Log($"—пич инициатора, врем€ {speech.BarShowingTime}");
            yield return new WaitForSeconds(speech.BarShowingTime);

            //после спича получаем ответ ответчика
            SpeechResponse = SpeechResponder.GetResponseAtSpeech(speech, speechInitiator);
            SpeechResponder.StartActionVisual(SpeechResponse);
            //воспроизводим его
            yield return SpeechResponse.ReactAtSpeech(speech);
            //Debug.Log($"—пич ответчика, врем€ {SpeechResponse.BarShowingTime}");
            yield return new WaitForSeconds(SpeechResponse.BarShowingTime);
            //в зависимости от ответа измен€ютс€ отношени€ агентов или совершаютс€ действи€
            yield return speech.ReactAtSpeech(SpeechResponse);
        }

        private TimingAttentionToAgentState<TResponder, TInitiator> SetState(float speechTime)
        {
            var attState = speechResponder.SetState<TimingAttentionToAgentState<TResponder, TInitiator>>();
            attState.Initiate(speechResponder, SpeechInitiator, speechTime );
            return attState;
        }       

        //List<SpeakAction> GetAllAvailableSpeeches(CharacterToPhenomReactionsLists table, string tableDimensionName)
        //{
        //    var colName = relations != null ? relations.ToString() : "NonFamiliar";

        //    return table.GetTableValuesFor<TInitiator, ReactionBase, FeatureBase, SchoolAgentStateBase<TInitiator>, Sensor>
        //        (speechInitiator, tableDimensionName, colName)
        //        .SelectMany(x => x.GetReactions()).Where(x => x is SpeakAction).Cast<SpeakAction>().ToList();
        //}
    }
}
