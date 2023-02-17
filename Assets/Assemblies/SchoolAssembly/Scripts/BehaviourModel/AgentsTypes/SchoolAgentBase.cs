using BuildingModule;
using Common;
using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SchoolAgentBase<TAgent>: 
        AgentBase<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>,
        IUIViewedObject, ICurrentRoomHandler, IMovementTarget<TAgent>, IReactionSource
        where TAgent : SchoolAgentBase<TAgent>
    {
        #region main

        #region components

        [SerializeField] private CircleCollider2D agentCollider;
        [SerializeField] private SpriteRenderer agentRenderer;
        [SerializeField] private Rigidbody2D agentRigidbody;
        [SerializeField] private Sprite previewSprite;

        #endregion components

        [Space]
        #region base params
        [SerializeField] private ushort agentAge;
        [SerializeField] private string agentDescription;
        [SerializeField] private ushort agentHeight;
        [SerializeField] private string agentName;
        [SerializeField] private SexBase agentSex;
        [SerializeField] private float agentValue;
        [SerializeField] private ushort agentWeight;

        [Space]
        #endregion base params
        [SerializeField] private Room currentRoom;
        //[SerializeField] private EnvironmentInfoSource envirInfo;
        [SerializeField] private IMovementTarget<TAgent> movementTarget;
        [SerializeField] private ChairInterier seatChair;
        public IMovementTarget<TAgent> MovementTarget { get => movementTarget; set => movementTarget = value; }

        #endregion main

        [Space]
        [SerializeField] private MovementComponent<TAgent> movementComponent;

        [Space]
        #region states

        [SerializeField] private FindFreeChairState<TAgent> findFreeChairState;
        [SerializeField] private IdleAgentState<TAgent> idleAgentState;
        [SerializeField] private MoveToTargetState<TAgent> moveToTargetState;

        #endregion states
        internal abstract void OnGlobalEventChangedCallback(ExperimentProcessHandler.CurrentEventChangedEventArgs args);
        public IEnumerator RotateRoutine(Vector3 directionVector)
        {
            yield return movementComponent.RotateToFaceDirection(directionVector);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Entrance ent))
            {
                CurrentRoom = ent.CurrentRoom;
            }
        }
      

        public Collider2D AgentCollider => agentCollider;
        public Rigidbody2D AgentRigidbody => agentRigidbody;
        public ChairInterier Chair { get => seatChair; set => seatChair = value; }
        public Room CurrentRoom { get => currentRoom; set => currentRoom = value; }
        //public EnvironmentInfoSource EnvironmentInfo { get => envirInfo; private set => envirInfo = value; }
        public string Name => agentName;
        public string ObjDescription => agentDescription;
        public float PhenomenonPower { get => agentValue; set => agentValue = value; }
        public Sprite PreviewSprite => previewSprite;

        public void AddEmotion(ReactionBase newEmotion) =>
            Brain.AddReaction(newEmotion);

        public void ClearEmotions() =>
            Brain.TemporaryReactions.Clear();

        public ChairInterier FindFreeChairToSeat(List<ChairInterier> chairs)
        {
            foreach (var ch in chairs)
            {
                if (ch.ThisAgent == null)
                    return ch;
            }
            return default;
        }


        //public GlobalEvent CurrentEvent { get=> EnvironmentInfo.CurrentGlobalEvent; }
        public virtual void Initiate<TLowAnx, TMidAnx, THighAnx,
            TLowSoc, TMidSoc, THighSoc,
            TLowStab, TMidStab, THighStab,
            TLowNonc, TMidNonc, THighNonc,
            TLowNorm, TMidNorm, THighNorm,
            TLowRad, TMidRad, THighRad,
            TLowSelf, TMidSelf, THighSelf,
            TLowSens, TMidSens, THighSens,
            TLowSusp, TMidSusp, THighSusp,
            TLowTens, TMidTens, THighTens,
            TLowExpre, TMidExpre, THighExpre,
            TLowInt, TMidInt, THighInt,
            TLowDrea, TMidDrea, THighDrea,
            TLowDom, TMidDom, THighDom,
            TLowDipl, TMidDipl, THighDipl,
            TLowCour, TMidCour, THighCour>
            (HumanRawData data)
             where TLowAnx : LowAnxiety<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidAnx : MiddleAnxiety<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighAnx : HighAnxiety<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowSoc : LowClosenessSociability<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidSoc : MiddleClosenessSociability<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighSoc : HighClosenessSociability<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowStab : LowEmotionalStability<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidStab : MiddleEmotionalStability<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighStab : HighEmotionalStability<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowNonc : LowNonconformism<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidNonc : MiddleNonconformism<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighNonc : HighNonconformism<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowNorm : LowNormativityOfBehaviour<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidNorm : MiddleNormativityOfBehaviour<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighNorm : HighNormativityOfBehaviour<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowRad : LowRadicalism<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidRad : MiddleRadicalism<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighRad : HighRadicalism<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowSelf : LowSelfcontrol<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidSelf : MiddleSelfcontrol<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighSelf : HighSelfcontrol<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowSens : LowSensetivity<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidSens : MiddleSensetivity<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighSens : HighSensetivity<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowSusp : LowSuspicion<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidSusp : MiddleSuspicion<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighSusp : HighSuspicion<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowTens : LowTension<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidTens : MiddleTension<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighTens : HighTension<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowExpre : LowExpressiveness<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidExpre : MiddleExpressiveness<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighExpre : HighExpressiveness<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowInt : LowIntelligence<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidInt : MiddleIntelligence<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighInt : HighIntelligence<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowDrea : LowDreaminess<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidDrea : MiddleDreaminess<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighDrea : HighDreaminess<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowDom : LowDomination<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidDom : MiddleDomination<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighDom : HighDomination<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowDipl : LowDiplomacy<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidDipl : MiddleDiplomacy<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighDipl : HighDiplomacy<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

            where TLowCour : LowCourage<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where TMidCour : MiddleCourage<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
            where THighCour : HighCourage<TAgent, ReactionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        {
            base.Initiate<TLowAnx, TMidAnx, THighAnx,
            TLowSoc, TMidSoc, THighSoc,
            TLowStab, TMidStab, THighStab,
            TLowNonc, TMidNonc, THighNonc,
            TLowNorm, TMidNorm, THighNorm,
            TLowRad, TMidRad, THighRad,
            TLowSelf, TMidSelf, THighSelf,
            TLowSens, TMidSens, THighSens,
            TLowSusp, TMidSusp, THighSusp,
            TLowTens, TMidTens, THighTens,
            TLowExpre, TMidExpre, THighExpre,
            TLowInt, TMidInt, THighInt,
            TLowDrea, TMidDrea, THighDrea,
            TLowDom, TMidDom, THighDom,
            TLowDipl, TMidDipl, THighDipl,
            TLowCour, TMidCour, THighCour
            > (data);
            //TODO доделать инициализацию
            //previewSprite =
            agentName = data.AgentName;
            agentSex = data.Sex;
            agentAge = data.age;
            agentWeight = data.Weight;
            agentHeight = data.Height;

            PhenomenonPower = 5;
            //NervousSystem.Initiate(data);
            
        }

        //public void Initiate<TLowAnx, TMidAnx, THighAnx,
        //    TLowSoc, TMidSoc, THighSoc,
        //    TLowStab, TMidStab, THighStab,
        //    TLowNonc, TMidNonc, THighNonc,
        //    TLowNorm, TMidNorm, THighNorm,
        //    TLowRad, TMidRad, THighRad,
        //    TLowSelf, TMidSelf, THighSelf,
        //    TLowSens, TMidSens, THighSens,
        //    TLowSusp, TMidSusp, THighSusp,
        //    TLowTens, TMidTens, THighTens,
        //    TLowExpre, TMidExpre, THighExpre,
        //    TLowInt, TMidInt, THighInt,
        //    TLowDrea, TMidDrea, THighDrea,
        //    TLowDom, TMidDom, THighDom,
        //    TLowDipl, TMidDipl, THighDipl,
        //    TLowCour, TMidCour, THighCour
        //    >(HumanRawData data)
        //    where TLowAnx : LowAnxiety<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidAnx : MiddleAnxiety<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighAnx : HighAnxiety<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowSoc : LowClosenessSociability<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidSoc : MiddleClosenessSociability<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighSoc : HighClosenessSociability<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowStab : LowEmotionalStability<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidStab : MiddleEmotionalStability<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighStab : HighEmotionalStability<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowNonc : LowNonconformism<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidNonc : MiddleNonconformism<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighNonc : HighNonconformism<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowNorm : LowNormativityOfBehaviour<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidNorm : MiddleNormativityOfBehaviour<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighNorm : HighNormativityOfBehaviour<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowRad : LowRadicalism<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidRad : MiddleRadicalism<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighRad : HighRadicalism<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowSelf : LowSelfcontrol<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidSelf : MiddleSelfcontrol<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighSelf : HighSelfcontrol<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowSens : LowSensetivity<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidSens : MiddleSensetivity<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighSens : HighSensetivity<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowSusp : LowSuspicion<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidSusp : MiddleSuspicion<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighSusp : HighSuspicion<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowTens : LowTension<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidTens : MiddleTension<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighTens : HighTension<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowExpre : LowExpressiveness<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidExpre : MiddleExpressiveness<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighExpre : HighExpressiveness<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowInt : LowIntelligence<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidInt : MiddleIntelligence<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighInt : HighIntelligence<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowDrea : LowDreaminess<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidDrea : MiddleDreaminess<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighDrea : HighDreaminess<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowDom : LowDomination<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidDom : MiddleDomination<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighDom : HighDomination<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowDipl : LowDiplomacy<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidDipl : MiddleDiplomacy<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighDipl : HighDiplomacy<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>

        //    where TLowCour : LowCourage<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where TMidCour : MiddleCourage<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //    where THighCour : HighCourage<TAgent, EmotionBase,FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        //{
        //    Initiate<TLowAnx, TMidAnx, THighAnx,
        //    TLowSoc, TMidSoc, THighSoc,
        //    TLowStab, TMidStab, THighStab,
        //    TLowNonc, TMidNonc, THighNonc,
        //    TLowNorm, TMidNorm, THighNorm,
        //    TLowRad, TMidRad, THighRad,
        //    TLowSelf, TMidSelf, THighSelf,
        //    TLowSens, TMidSens, THighSens,
        //    TLowSusp, TMidSusp, THighSusp,
        //    TLowTens, TMidTens, THighTens,
        //    TLowExpre, TMidExpre, THighExpre,
        //    TLowInt, TMidInt, THighInt,
        //    TLowDrea, TMidDrea, THighDrea,
        //    TLowDom, TMidDom, THighDom,
        //    TLowDipl, TMidDipl, THighDipl,
        //    TLowCour, TMidCour, THighCour
        //    >(data);
        //    //EnvironmentInfo = envirInfoSource;
        //}


        public IEnumerator OnTargetReached(TAgent moveAgent)
        {
            yield break;
        }

        public override void SetState<S2>()
        {
            if (moveToTargetState is S2)
                CurrentState = moveToTargetState;
            else if (idleAgentState is S2)
                CurrentState = idleAgentState;
            else if (findFreeChairState is S2)
                CurrentState = findFreeChairState;
            else throw new NotImplementedException($"Unexpected state {typeof(S2)}");
        }

        public abstract List<IReaction> GetReactionsOnPhenomenon();
    }
}