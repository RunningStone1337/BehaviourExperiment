using BuildingModule;
using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilBrain : BrainBase<PupilAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<PupilAgent>, Sensor>,
        //IAttentionCalculator<PupilAgent>,
        //IAttentionCalculator<TeacherAgent>,
        //IAttentionCalculator<PlacedInterier>,
        //IAttentionCalculator<GlobalEvent>,

        ICanReactOnPhenomenon<PupilAgent, ReactionBase>,
        ICanReactOnPhenomenon<TeacherAgent, ReactionBase>,
        ICanReactOnPhenomenon<PlacedInterier, ReactionBase>,
        ICanReactOnPhenomenon<BreakEvent, ReactionBase>,
        ICanReactOnPhenomenon<LessonEvent, ReactionBase>
    {

        #region fields
        #endregion

        #region attention calculations
        protected override float CalculateAttentionThreshold()
        {
            var cs = ThisAgent.CharacterSystem;
            var self = cs.Selfcontrol.SpecializedCharacterValue;
            var express = cs.RestraintExpressiveness.SpecializedCharacterValue;
            var tension = cs.RelaxationTension.SpecializedCharacterValue;
            var interestThreshold = (self - express - tension);
            return interestThreshold;
        }

        //private bool IsPhenomenonSignificant<T>(T ph, out float calculatedImportance) where T : IPhenomenon
        //{
        //    calculatedImportance = CalculateAttentionForPhenomenon(ph);
        //    float interestThreshold = CalculateAttentionThreshold();
        //    if (calculatedImportance > interestThreshold)
        //        return true;
        //    return false;
        //}

        //protected override IEnumerator FilterNewPhenomenons()
        //{
        //    foreach (var ph in NewPhenomens)
        //    {
        //        if (IsPhenomenonSignificant(ph, out float calculated))
        //        {
        //            if (!PhenomensToReact.ContainsKey(ph))
        //            {
        //                PhenomensToReact.Add(ph, calculated);
        //                Debug.Log($"Interest value {calculated}/{CalculateAttentionThreshold()} for phenom {ph}. Interested, added");
        //            }
        //            else
        //            {
        //                Debug.Log($"Interest value {calculated}/{CalculateAttentionThreshold()} for phenom {ph}. Interested, yet added");
        //            }
        //        }
        //        else
        //            Debug.Log($"Interest value {calculated}/{CalculateAttentionThreshold()} for phenom {ph}. Not interested.");
        //        yield return null;
        //    }
        //    NewPhenomens.Clear();
        //}
        //public float CalculateAttentionForPhenomenon(PupilAgent phenom)
        //{
        //    var rel = ThisAgent.RelationsSystem.GetCurrentRelationTo(phenom);
        //    return ThisAgent.CalculateAttentionForRelation<PupilAgent>(rel);
        //}

        //public float CalculateAttentionForPhenomenon(TeacherAgent phenom)
        //{
        //    var rel = ThisAgent.RelationsSystem.GetCurrentRelationTo(phenom);
        //    return ThisAgent.CalculateAttentionForRelation<TeacherAgent>(rel);
        //}

        //public float CalculateAttentionForPhenomenon(PlacedInterier phenom)
        //{
        //    return ThisAgent.CalculateAttentionForInterier(phenom);
        //}

        //public override float CalculateAttentionForPhenomenon(IPhenomenon phenom)
        //{
        //    if (phenom is PupilAgent p)
        //        return CalculateAttentionForPhenomenon(p);
        //    else if (phenom is TeacherAgent t)
        //        return CalculateAttentionForPhenomenon(t);
        //    else if (phenom is PlacedInterier pi)
        //        return CalculateAttentionForPhenomenon(pi);
        //    else if (phenom is GlobalEvent br)
        //        return CalculateAttentionForPhenomenon(br);
        //    else return default;
        //}

        //public float CalculateAttentionForPhenomenon(GlobalEvent phenom)
        //{
        //    return ThisAgent.CalculateAttentionForPhenomenon(phenom);
        //}

        //protected override bool CanSetNewState()
        //{
        //    if (ThisAgent.CurrentState is IOptionalToCompleteState)
        //        return true;
        //    return default;
        //}

        #endregion

        #region reactions calculations

        public override bool HasReactionsOnPhenom(IPhenomenon reason, out List<ReactionBase> reaction)
        {
            reaction = default;
            if (reason is PupilAgent p)
                return HasReactionsOnPhenom(p, out reaction);
            else if (reason is TeacherAgent t)
                return HasReactionsOnPhenom(t, out reaction);
            else if (reason is PlacedInterier pi)
                return HasReactionsOnPhenom(pi, out reaction);
            else if (reason is BreakEvent be)
                return HasReactionsOnPhenom(be, out reaction);
            else if (reason is LessonEvent le)
                return HasReactionsOnPhenom(le, out reaction);
            else return default;
        }

        /// <summary>
        /// –еакци€ на школ€ра зависит от 
        /// -характера
        /// -взаимоотношений
        /// -текущего событи€
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="reactions"></param>
        /// <returns></returns>
        public bool HasReactionsOnPhenom(PupilAgent reason, out List<ReactionBase> reactions)
        {
            reactions = ReactionsSelector.SelectReactions                
                (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToPupilReactionsTable);
             //ThisAgent.GetReactionsOnPhenom(reason, relations);
            return true;
        }

        public bool HasReactionsOnPhenom(TeacherAgent reason, out List<ReactionBase> reactions)
        {
            reactions = ReactionsSelector.SelectReactions
               (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToPupilReactionsTable);
            return true;
        }

        public bool HasReactionsOnPhenom(PlacedInterier reason, out List<ReactionBase> reactions)
        {
            reactions = ReactionsSelector.SelectReactions
               (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToInterierReactionsTable);
            return true;
        }

        public bool HasReactionsOnPhenom(BreakEvent reason, out List<ReactionBase> reactions)
        {
            reactions = ReactionsSelector.SelectReactions
               (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToEventsReactionsTable);
            return true;
        }

        public bool HasReactionsOnPhenom(LessonEvent reason, out List<ReactionBase> reactions)
        {
            reactions = ReactionsSelector.SelectReactions
               (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToEventsReactionsTable);
            return true;
        }

        protected override ReactionBase SelectReaction(List<ReactionBase> reactions)
        {
            var tuples = reactions.Select(x => (x, x.PhenomenonPower)).ToList();
            var selected = tuples.SelectRandom();
            return selected.Key;
        }

        protected override IPhenomenon SelectPhenomToReact(List<IPhenomenon> phenomensToReact)
        {
            var phenomsWeights = phenomensToReact.Select(x => (x, x.PhenomenonPower)).ToList();
            return phenomsWeights.SelectRandom().Key;
        }
        #endregion
    }
}