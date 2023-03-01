using BuildingModule;
using Core;
using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilAgent : SchoolAgentBase<PupilAgent>
        
    {
        public override GlobalEvent CurrentEvent => ((SchoolObservationsSystem<PupilAgent>)ObservationsSystem).EventsSensor.CurrentEvent;

        protected override void Awake()
        {
            if (currentState == null)
            {
                SetState<PupilChooseActionState>();
            }
        }

        //internal float CalculateAttentionForRelation<TOther>(
        //    RelationshipBase<PupilAgent, IAgent, SchoolAgentStateBase<PupilAgent>> rel)
        //    where TOther: SchoolAgentBase<TOther>
        //{
        //    float result = default;
        //    CharacterToPhenomFloatRelationsMatrix table = SelectTable();

        //    var system = (SchoolObservationsSystem<PupilAgent>)ObservationsSystem;
        //    var curEventName = system.EventsSensor.CurrentEvent.GetType().Name;
        //    string relationKey = GetRelationName(rel);

        //    foreach (var trait in CharacterSystem)
        //    {
        //        result += table.GetTableValueFor(curEventName, trait.ThisConcreteCharType, relationKey)
        //        * trait.SpecializedCharacterValue * table.TableScallingValue;
        //    }
        //    return result;

        //    CharacterToPhenomFloatRelationsMatrix SelectTable()
        //    {
        //        CharacterToPhenomFloatRelationsMatrix table;
        //        if (typeof(TOther).IsEquivalentTo(typeof(PupilAgent)))
        //            table = TablesHandler.CharacterToPupilAttentionTable;
        //        else
        //            table = TablesHandler.CharacterToTeacherAttentionTable;
        //        return table;
        //    }
        //}

       

        //internal float CalculateAttentionForInterier(PlacedInterier phenom)
        //{
        //    var system = (SchoolObservationsSystem<PupilAgent>)ObservationsSystem;
        //    float result = default;
        //    foreach (var trait in CharacterSystem)
        //    {
        //        result += TablesHandler.CalculateAttentionForInterier(phenom, trait, system.EventsSensor.CurrentEvent)
        //            * phenom.PhenomenonPower;
        //    }
        //    return result;
        //}

        //internal float CalculateAttentionForPhenomenon(GlobalEvent curEvent)
        //{
        //    throw new NotImplementedException();
        //}

      

        //internal List<ReactionBase> GetReactionsOnEvent<T>(T reason)
        //    where T: GlobalEvent
        //{
        //    var result = new List<ReactionBase>();
        //    var table = TablesHandler.CharacterToEventsReactionsTable;
        //    var curEventName = reason.Name;
        //    foreach (var trait in CharacterSystem)
        //    {
        //        result.AddRange(GetReactionsForTrait(this,reason,table, curEventName, 0, trait));
        //    }
        //    return result;
        //}
        //internal List<ReactionBase> GetReactionsOnInterier(PlacedInterier reason)
        //{
        //    var result = new List<ReactionBase>();
        //    var table = TablesHandler.CharacterToInterierReactionsTable;

        //    //var reactSource = (T)relations.SecondAgent;
        //    foreach (var trait in CharacterSystem)
        //    {
        //        result.AddRange(
        //            GetReactionsForTrait(this, reason, table, 0, 0, trait));
        //    }
        //    return result;
        //}
      

        //private static List<ReactionBase> GetReactionsForTrait
        //    (PupilAgent thisAgent, IReactionSource reactSource, CharacterToPhenomReactionsLists table, string tablePageName, string columnName, CharacterTraitBase<PupilAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<PupilAgent>, Sensor> trait)
        //{
        //    var selector = table.GetTableValueFor(tablePageName, trait.ThisConcreteCharType, columnName);
        //    var reactions = selector.GetReactions();
        //    foreach (var r in reactions)
        //    {
        //        r.ActionActor = thisAgent;
        //        r.ReactionSource = reactSource;
        //    }
        //    return reactions.ToList();
        //}
        //private static List<ReactionBase> GetReactionsForTrait
        //    (PupilAgent thisAgent, IReactionSource reactSource, CharacterToPhenomReactionsLists table, string tablePageName, int columnIndex, CharacterTraitBase<PupilAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<PupilAgent>, Sensor> trait)
        //{
        //    var selector = table.GetTableValueFor(tablePageName, trait.ThisConcreteCharType, columnIndex);
        //    var reactions = selector.GetReactions();
        //    foreach (var r in reactions)
        //    {
        //        r.ActionActor = thisAgent;
        //        r.ReactionSource = reactSource;
        //    }
        //    return reactions.ToList();
        //}

       

        //private static List<ReactionBase> GetReactionsForTrait
        //    (PupilAgent thisAgent, IReactionSource reactSource, CharacterToPhenomReactionsLists table, int tablePageIndex, int columnIndex, CharacterTraitBase<PupilAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<PupilAgent>, Sensor> trait)
        //{
        //    var selector = table.GetTableValueFor(tablePageIndex, trait.ThisConcreteCharType, columnIndex);
        //    var reactions = selector.GetReactions();
        //    foreach (var r in reactions)
        //    {
        //        r.ActionActor = thisAgent;
        //        r.ReactionSource = reactSource;
        //    }
        //    return reactions.ToList();
        //}

        public override void SetDefaultState()
        {
            SetState<IdleState<PupilAgent>>();
        }
    }
}