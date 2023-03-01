using BuildingModule;
using Common;
using Core;
using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SchoolAgentBase<TAgent>: 
        AgentBase<TAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>,
        IUIViewedObject, IReactionSource
        where TAgent : SchoolAgentBase<TAgent>
    {
        [Space]
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
        [SerializeField] SchoolRelationsTableHandler tablesHandler;
        public SchoolRelationsTableHandler TablesHandler => tablesHandler;
        [SerializeField] AgentEnvironment agentEnvironment;
        public AgentEnvironment AgentEnvironment => agentEnvironment;
        //[SerializeField] private EnvironmentInfoSource envirInfo;
        [SerializeField] private IMovementTarget movementTarget;

        public abstract GlobalEvent CurrentEvent { get; }

        public IMovementTarget MovementTarget { get => movementTarget; set => movementTarget = value; }

        #endregion main

        [Space]
        [SerializeField] private MovementComponent<TAgent> movementComponent;
        public MovementComponent<TAgent> MovementComponent => movementComponent;

        public IEnumerator RotateRoutine(Vector3 directionVector)
        {
            yield return MovementComponent.RotateToFaceDirection(directionVector);
        }

        public Collider2D AgentCollider => agentCollider;
        public Rigidbody2D AgentRigidbody => agentRigidbody;
       
        //public EnvironmentInfoSource EnvironmentInfo { get => envirInfo; private set => envirInfo = value; }
        public string Name => agentName;
        public string ObjDescription => agentDescription;
        public float PhenomenonPower { get => agentValue; set => agentValue = value; }
        public Sprite PreviewSprite => previewSprite;     

        public IEnumerator ResponseToSpeechFromOptions<TInitiator, TResponder>(SpeakAction speechToRespond, DialogProcess<TInitiator, TResponder> dialogProcess,  List<SpeakAction> options)
            where TInitiator : SchoolAgentBase<TInitiator>
            where TResponder : SchoolAgentBase<TResponder>
        {
            SpeakAction response = SelectResponseToSpeechFromOptions(speechToRespond, options);

            yield return response.Speak(dialogProcess);
            dialogProcess.LastAnswer = response;
        }
        private SpeakAction SelectResponseToSpeechFromOptions(SpeakAction speechToRespond, List<SpeakAction> options)
        {
            var table = TablesHandler.AgentToSpeechResponsesTable;
            var speechType = speechToRespond.GetType().Name;
            //16 векторов
            var thisAgentVectors = table.GetTableValuesFor<TAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
                ((TAgent)this, 0);
            //ответы на speechToRespond для данных векторов
            var selected = thisAgentVectors.Where(x => x.SpeechToReact.Equals(speechType));
            var selectedProbReactions = selected.SelectMany(x => x.ProbablyReactions.ProbReactions);
            var optionsWithWeights = new List<(SpeakAction answerOption, int answerWeight)>();
            //сопоставляем доступные варианты с определёнными
            foreach (var option in options)
            {
                var optionTypeName = option.GetType().Name;
                var weights = selectedProbReactions.Where(x => x.SpeechToAnswer.Equals(optionTypeName)).Sum(x => x.ReactionWeight);
                optionsWithWeights.Add((option, weights));
            }
            //выбрать на омновании весов
            var response = optionsWithWeights.SelectRandom().Key;
            return response;
        }
        public override void SetState<TNewState>()
        {
            var state = new TNewState();
            state.Initiate((TAgent)this);
            CurrentState = state;
        }

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

        public IEnumerator OnLeaveChair()
        {
            AgentEnvironment.ChairInfo.ThisAgent = null;
            var leavedChair = AgentEnvironment.ChairInfo.ThisInterier;
            leavedChair.Collider2D.isTrigger = false;
            AgentRigidbody.bodyType = RigidbodyType2D.Dynamic;

            Collider2D[] contacts = new Collider2D[5];
            AgentRigidbody.GetContacts(contacts);
            while (contacts.Contains(leavedChair.Collider2D))
            {
                AgentRigidbody.MovePosition(transform.position + new Vector3(0.05f, 0, 0));
                AgentRigidbody.GetContacts(contacts);
                yield return new WaitForFixedUpdate();
            }
            AgentRigidbody.MovePosition(transform.position + new Vector3(0.05f, 0, 0));
            yield return new WaitForFixedUpdate();

            AgentEnvironment.ChairInfo = null;
            AgentEnvironment.TableInfo.RemoveAgent(this);
            AgentEnvironment.TableInfo = null;
        }

        public IEnumerator OnTargetReached()
        {
            if (movementTarget is ChairInterier chair)
            {
                yield return HandleChair(chair);
                var closestTable = InterierHandler.Handler.Tables
                    .Select(x=>(Vector3.Distance(x.transform.position, chair.transform.position), x))
                    .OrderBy(x=>x.Item1).First().x;

                AgentEnvironment.TableInfo = closestTable.TableInfo;
                AgentEnvironment.TableInfo.AddAgentIfFree(this);
            }

            IEnumerator HandleChair(ChairInterier chair)
            {
                chair.Collider2D.isTrigger = true;
                chair.ChairInfo.ThisAgent = this;
                AgentRigidbody.MovePosition(chair.transform.position);
                yield return RotateRoutine(chair.transform.up);
                AgentEnvironment.ChairInfo = chair.ChairInfo;
                AgentRigidbody.bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
}