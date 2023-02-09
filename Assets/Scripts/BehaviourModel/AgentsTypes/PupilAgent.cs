using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilAgent : SchoolAgentBase,
        ICanReactOnPhenomenon<PupilAgent, EmotionBase>,
        ICanReactOnPhenomenon<TeacherAgent, EmotionBase>,
        ICanReactOnPhenomenon<PlacedInterier, EmotionBase>
    {
        #region tables
        [Space]
        [SerializeField] private CharacterToPhenomFloatRelationsTable characterToNonFamiliarAttentionTable;
        [SerializeField] private CharacterEmotions characterToTeacherReactionsTable;
        [SerializeField] private CharacterEmotions characterToFamiliarReactionsTable;
        [SerializeField] private CharacterEmotions characterToFellowReactionsTable;
        [SerializeField] private CharacterEmotions characterToComradeReactionsTable;
        [SerializeField] private CharacterEmotions characterToFriendReactionsTable;
        [SerializeField] private CharacterEmotions characterToFoeReactionsTable;
        [SerializeField] private CharacterEmotions characterToEnemyReactionsTable;
        [SerializeField] private CharacterRelationsConditionsActionTable characterToFamiliarConditionsTable;
        [SerializeField] private CharacterRelationsConditionsActionTable characterToFellowConditionsTable;
        //[SerializeField] private CharacterRelationsConditionsActionTable characterToComradeConditionsTable;
        [SerializeField] private CharacterRelationsConditionsActionTable characterToFriendConditionsTable;
        [SerializeField] private CharacterRelationsConditionsActionTable characterToFoeConditionsTable;
        [SerializeField] private CharacterRelationsConditionsActionTable characterToEnemyConditionsTable;

        public CharacterRelationsConditionsActionTable CharacterToFamiliarConditionsTable => characterToFamiliarConditionsTable;
        public CharacterRelationsConditionsActionTable CharacterToFellowConditionsTable => characterToFellowConditionsTable;
        public CharacterRelationsConditionsActionTable CharacterToFriendConditionsTable => characterToFriendConditionsTable;
        public CharacterRelationsConditionsActionTable CharacterToFoeConditionsTable => characterToFoeConditionsTable;
        public CharacterRelationsConditionsActionTable CharacterToEnemyConditionsTable => characterToEnemyConditionsTable;
        public CharacterToPhenomFloatRelationsTable CharacterToNonFamiliarAttentionTable => characterToNonFamiliarAttentionTable;
        public CharacterEmotions CharacterToTeacherReactionsTable => characterToTeacherReactionsTable;
        public CharacterEmotions CharacterToFamiliarReactionsTable => characterToFamiliarReactionsTable;
        public CharacterEmotions CharacterToFellowReactionsTable => characterToFellowReactionsTable;
        public CharacterEmotions CharacterToComradeReactionsTable => characterToComradeReactionsTable;
        public CharacterEmotions CharacterToFriendReactionsTable => characterToFriendReactionsTable;
        public CharacterEmotions CharacterToFoeReactionsTable => characterToFoeReactionsTable;
        public CharacterEmotions CharacterToEnemyReactionsTable => characterToEnemyReactionsTable;

        [SerializeField] private List<Emotions> characterToTeacherReactions;
        [SerializeField] private List<Emotions> characterToFamiliarReactions;
        [SerializeField] private List<Emotions> characterToFellowReactions;
        [SerializeField] private List<Emotions> characterToFriendReactions;
        [SerializeField] private List<Emotions> characterToFoeReactions;
        [SerializeField] private List<Emotions> characterToEnemyReactions;
        public List<Emotions> CharacterToTeacherReactions
        {
            get => characterToTeacherReactions;
            private set => characterToTeacherReactions = value;
        }
        public List<Emotions> CharacterToFamiliarReactions
        {
            get => characterToFamiliarReactions;
            private set => characterToFamiliarReactions = value;
        }
        public List<Emotions> CharacterToFellowReactions
        {
            get => characterToFellowReactions;
            private set => characterToFellowReactions = value;
        }
        public List<Emotions> CharacterToFriendReactions
        {
            get => characterToFriendReactions;
            private set => characterToFriendReactions = value;
        }
        public List<Emotions> CharacterToFoeReactions
        {
            get => characterToFoeReactions;
            private set => characterToFoeReactions = value;
        }
        public List<Emotions> CharacterToEnemyReactions
        {
            get => characterToEnemyReactions;
            private set => characterToEnemyReactions = value;
        }
       

        /// <summary>
        /// –еакци€ на учител€ зависит от личных качеств.
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="reaction"></param>
        /// <returns></returns>
        public bool HasReactionOn(TeacherAgent reason, out List<EmotionBase> reaction)
        {
            if (characterToTeacherReactions != null)
            {
                //reaction = characterToTeacherReactions.ToEmotions(reason);
                //return true;
            }
            reaction = null;
            return default;
        }

        /// <summary>
        /// –еакци€ на интерьер зависит от личных качеств.
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="reaction"></param>
        /// <returns></returns>
        public virtual bool HasReactionOn(PlacedInterier reason, out List<EmotionBase> reaction) { reaction = default; return default; }//abstract после компил€ции
        /// <summary>
        /// –еакци€ на ученика зависит от отношений.
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="reaction"></param>
        /// <returns></returns>
        public bool HasReactionOn(PupilAgent reason, out List<EmotionBase> reaction)
        {
            if (characterToTeacherReactions != null)
            {
                //reaction = characterToTeacherReactions.ToEmotions(reason);
                //return true;
            }
            reaction = null;
            return default;
        }
        

        //public override void Initiate(CharacterTraitBase<TReaction, TFeature, TState> thisTrait)
        //{
        //    base.Initiate(thisTrait);
        //characterToTeacherReactions = GetListFromTable(ThisTraitAgent.CharacterToTeacherReactionsTable);
        //characterToFamiliarReactions = GetListFromTable(CharacterToFamiliarReactionsTable);
        //characterToFellowReactions = GetListFromTable(CharacterToFellowReactionsTable);
        ////characterToComradeReactions = GetListFromTable(CharacterToComradeReactionsTable);
        //characterToFriendReactions = GetListFromTable(CharacterToFriendReactionsTable);
        //characterToFoeReactions = GetListFromTable(CharacterToFoeReactionsTable);
        //characterToEnemyReactions = GetListFromTable(CharacterToEnemyReactionsTable);
        //}
        protected List<T> GetListFromTable<T>(CharacterListTableBase<T> table)
        {
            return null;
        }

        public int AttentionToNonFamiliarCoef { get; internal set; }

        public override List<IReaction> GetReactionsOnPhenomenon()
        {
            throw new NotImplementedException();
        }      

        #endregion tables
    }
}