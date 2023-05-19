using System.Collections;
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
        private RelationshipBase<TInitiator, IAgent> relations;
        public SpeakAction<TResponder, TInitiator> SpeechResponse { get; set; }

        public DialogProcess(TInitiator initiator, TResponder responder)
        {
            speechInitiator = initiator;
            speechResponder = responder;
            relations = speechInitiator.RelationsSystem.GetCurrentRelationTo(speechResponder);
        }

        
        public IEnumerator StartDialog(SpeakAction<TInitiator, TResponder> initiatorSpeech)
        {
            speechInitiator.StartActionVisual(initiatorSpeech);
            yield return new WaitForSeconds(initiatorSpeech.BarShowingTime );

            //после спича получаем ответ ответчика
            SpeechResponse = SpeechResponder.GetReactionAtSpeech(initiatorSpeech, speechInitiator);
            //виузал ответчика, он должен быть в стейте внимания к агенту
            SpeechResponder.StartActionVisual(SpeechResponse);
            //воспроизводим его
            yield return SpeechResponse.ReactAtAction(initiatorSpeech);
            yield return new WaitForSeconds(SpeechResponse.BarShowingTime);
            //в зависимости от ответа изменяются отношения агентов или совершаются действия
            yield return initiatorSpeech.ReactAtAction(SpeechResponse);
        }

        private TimingAttentionToAgentState<TResponder, TInitiator> SetState(float speechTime)
        {
            var attState = speechResponder.SetState<TimingAttentionToAgentState<TResponder, TInitiator>>();
            attState.Initiate(speechResponder, SpeechInitiator, speechTime );
            return attState;
        }       
    }
}
