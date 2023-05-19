using System.Collections;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SpeakAction<TSpeaker, TSpeechTarget> : IndividualAction,
        IActionCallbackReciever<SpeakAction<TSpeechTarget, TSpeaker>>,
        IRelationsInfluenceHandler<TSpeechTarget>
        where TSpeaker : SchoolAgentBase<TSpeaker>
        where TSpeechTarget : SchoolAgentBase<TSpeechTarget>
    {
        protected SpeakAction() : base()
        {
        }
        public override void Initiate(IPhenomenon reactSource, IAgent reactionActor)
        {
            base.Initiate(reactSource, reactionActor);
            BarShowingTime = ((TSpeaker)reactionActor).CharacterSystem.ClosenessSociability.RawCharacterValue;
        }
        public virtual IEnumerator ReactAtAction(SpeakAction<TSpeechTarget, TSpeaker> speechToReact)
        {
            var thisAgent = (TSpeaker)ActionActor;
            var speechOwner = (TSpeechTarget)ReactionSource;
            thisAgent.AddRelationsChangesToAction(speechToReact, speechOwner);
            yield return null;
        }
        public float GetRelationshipInfluence(TSpeechTarget speechInfluenceTarget)
        {
            var table = speechInfluenceTarget.TablesHandler.AgentToSpeechRelationsInfluenceTable;
            var speechType = GetType().Name;
            //16 векторов для данного набора характера
            var thisAgentCharVectors = table.GetTableValuesFor<TSpeechTarget, ActionBase, FeatureBase, Sensor>
                (speechInfluenceTarget, 0);
            //реакции на speechToCalculate для данных векторов
            var selected = thisAgentCharVectors.Where(x => x.SpeechToReact.Equals(speechType));
            var totalInfluence = selected.Sum(x => x.ProbablyReactionInfluence);
            return totalInfluence;
        }
        public override IEnumerator TryPerformAction()
        {
            var actorCast = (TSpeaker)ActionActor;
            var secondCast = (TSpeechTarget)ReactionSource;
            var state = actorCast.SetState<IndividualSpeechState<TSpeaker, TSpeechTarget,
                //стейт привлечения внимания TSpeaker для TCompanion
                TryAttractTimingAttentionState<TSpeaker, TSpeechTarget>>>();
            state.Initiate(actorCast, secondCast, this,
                //делегат установки стейта вривлечения внимания и инициализации
                (cast, sec) => {
                    var res = cast.SetState<TryAttractTimingAttentionState<TSpeaker, TSpeechTarget>>();
                    res.Initiate(cast, sec);
                    return res;
                });
            yield return state.StartState();
            WasPerformed = true;
            actorCast.SetDefaultState();
        }
    }
}