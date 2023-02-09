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
    public abstract class SchoolAgentBase: AgentBase<EmotionBase,FeatureBase, SchoolAgentStateBase>,
        IUIViewedObject, ICurrentRoomHandler, IMovementTarget, IEmotionSource
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
        [SerializeField] private int agentValue;
        [SerializeField] private ushort agentWeight;

        [Space]
        #endregion base params
        [SerializeField] private Room currentRoom;
        [SerializeField] private EnvironmentInfoSource envirInfo;
        [SerializeField] private IMovementTarget movementTarget;
        [SerializeField] private ChairInterier seatChair;
        public IMovementTarget MovementTarget { get => movementTarget; set => movementTarget = value; }

        #endregion main

        [Space]
        [SerializeField] private MovementComponent movementComponent;

        [Space]
        #region states

        [SerializeField] private FindFreeChairState findFreeChairState;
        [SerializeField] private IdleAgentState idleAgentState;
        [SerializeField] private MoveToTargetState moveToTargetState;

        #endregion states

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
        public EnvironmentInfoSource EnvironmentInfo { get => envirInfo; private set => envirInfo = value; }
        public string Name => agentName;
        public string ObjDescription => agentDescription;
        public int PhenomenonPower { get => agentValue; set => agentValue = value; }
        public Sprite PreviewSprite => previewSprite;

        public void AddEmotion(EmotionBase newEmotion) =>
            NervousSystem.AddReaction(newEmotion);

        public void ClearEmotions() =>
            NervousSystem.TemporaryReactions.Clear();

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
        public virtual void Initiate(HumanRawData data)
        {
            base.Initiate(data);
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

        public void Initiate(HumanRawData data, EnvironmentInfoSource envirInfoSource)
        {
            Initiate(data);
            EnvironmentInfo = envirInfoSource;
        }


        public IEnumerator OnTargetReached(SchoolAgentBase moveAgent)
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