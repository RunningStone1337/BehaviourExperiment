using BuildingModule;
using Core;
using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilAgent : SchoolAgentBase<PupilAgent>
        
    {
        [SerializeField] PupilRelationsTableHandler tablesHandler;
        private void Awake()
        {
            if (currentState == null)
            {
                SetState<IdlePupilState>();
            }
        }
        public PupilRelationsTableHandler TablesHandler => tablesHandler;

        internal float CalculateAttentionForRelation<TOther>(
            RelationshipBase<PupilAgent, IAgent, SchoolAgentStateBase<PupilAgent>> rel)
            where TOther: SchoolAgentBase<TOther>
        {
            float result = default;
            CharacterToPhenomFloatRelationsLists table = SelectTable();

            var system = (PupilObservationsSystem)ObservationsSystem;
            var curEventName = system.EventsSensor.CurrentEvent.GetType().Name;
            string relationKey = GetRelationName(rel);

            foreach (var trait in CharacterSystem)
            {
                result += table.GetTableValueFor(curEventName, trait.ThisConcreteCharType, relationKey)
                * trait.SpecializedCharacterValue * table.TableScallingValue;
            }
            return result;

            CharacterToPhenomFloatRelationsLists SelectTable()
            {
                CharacterToPhenomFloatRelationsLists table;
                if (typeof(TOther).IsEquivalentTo(typeof(PupilAgent)))
                    table = TablesHandler.CharacterToPupilAttentionTable;
                else
                    table = TablesHandler.CharacterToTeacherAttentionTable;
                return table;
            }
        }

        private static string GetRelationName(RelationshipBase<PupilAgent, IAgent, SchoolAgentStateBase<PupilAgent>> rel)
        {
            string relationKey;
            if (rel == null)
                relationKey = "NonFamiliar";
            else
                relationKey = rel.ToString();
            return relationKey;
        }


        public override List<IReaction> GetReactionsOnPhenomenon()
        {
            throw new NotImplementedException();
        }

        internal float CalculateAttentionForInterier(PlacedInterier phenom)
        {
            var system = (PupilObservationsSystem)ObservationsSystem;
            float result = default;
            foreach (var trait in CharacterSystem)
            {
                result += TablesHandler.CalculateAttentionForInterier(phenom, trait, system.EventsSensor.CurrentEvent)
                    * phenom.PhenomenonPower;
            }
            return result;
        }

        internal float CalculateAttentionForPhenomenon(GlobalEvent curEvent)
        {
            throw new NotImplementedException();
        }

        internal override void OnGlobalEventChangedCallback(ExperimentProcessHandler.CurrentEventChangedEventArgs args)
        {
            var sys = (PupilObservationsSystem)ObservationsSystem;
            sys.EventsSensor.CurrentEvent = args.newEvent;
        }

        internal List<ReactionBase> GetReactionsOnPhenom<T>(RelationshipBase<PupilAgent, IAgent, SchoolAgentStateBase<PupilAgent>> relations)
            where T: SchoolAgentBase<T>
        {
            var result = new List<ReactionBase>();
            //новый тип таблицы
            //CharacterToPhenomReactionsTable table = SelectTable();

            var system = (PupilObservationsSystem)ObservationsSystem;
            var curEventName = system.EventsSensor.CurrentEvent.GetType().Name;
            string relationKey = GetRelationName(relations);

            foreach (var trait in CharacterSystem)
            {
                //var selector = table.GetTableValueFor(curEventName, trait.ThisConcreteCharType, relationKey);
                //stuck here
                //result.AddRange(selector.GetReactions());
            }
            return result;
            //новый тип таблицы
            //CharacterToPhenomReactionsTable SelectTable()
            //{
            //    if (typeof(T).IsEquivalentTo(typeof(PupilAgent)))
            //        return TablesHandler.CharacterToPupilReactionsTable;
            //    else
            //        return TablesHandler.CharacterToTeacherReactionsTable;
            //}
        }

        
    }
}