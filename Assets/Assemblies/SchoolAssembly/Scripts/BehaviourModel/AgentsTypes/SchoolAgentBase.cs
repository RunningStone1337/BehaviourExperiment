using BuildingModule;
using Common;
using Core;
using Events;
using Pathfinding;
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
        IUIViewedObject, IReactionSource, IMovementTarget
        where TAgent : SchoolAgentBase<TAgent>
    {
        [Space]
        #region main

        #region components

        [SerializeField] private CircleCollider2D agentCollider;
        [SerializeField] private SpriteRenderer agentRenderer;
        [SerializeField] private Rigidbody2D agentRigidbody;
        [SerializeField] private Sprite previewSprite;
        [SerializeField] private AgentStatusBar statusBar;
        [SerializeField] AgentsSkin skin;
        [SerializeField] AIDestinationSetter setter;      


        #endregion components

        [Space]
        #region base params
        [SerializeField] private int agentAge;
        [SerializeField] private string agentDescription;

       

        [SerializeField] private int agentHeight;
        [SerializeField] private string agentName;
        [SerializeField] private SexBase agentSex;


        [SerializeField] private float agentPhenomPower;
        [SerializeField] private int agentWeight;

        [Space]
        #endregion base params
        [SerializeField] SchoolRelationsTableHandler tablesHandler;
        public SchoolRelationsTableHandler TablesHandler => tablesHandler;
        [SerializeField] AgentEnvironment agentEnvironment;
        public AgentEnvironment AgentEnvironment => agentEnvironment;
        public Transform MovementTarget
        {
            get => setter.target; 
            set
            {
                if (value != null)
                    setter.target = TryRedirectMovementTarget(value);
                else
                    setter.target = value;
#if DEBUG
                if (setter.target != null)
                    Debug.Log($"Target set is {setter.target}");
                else
                    Debug.Log($"Target set is null");
#endif
            }
        }
     
        public abstract GlobalEvent CurrentEvent { get; }

        #endregion main

        public IEnumerator RotateRoutine(Vector3 directionVector)
        {
            var rotattor = new RotationHandler();
            yield return rotattor.RotateToFaceDirection(directionVector, AgentRigidbody, RotationHandler.MiddleRotation);
        }

        public CircleCollider2D AgentCollider => agentCollider;
        public Rigidbody2D AgentRigidbody => agentRigidbody;
       
        public string Name => agentName;
        public string ObjDescription => agentDescription;
        public float PhenomenonPower { get => agentPhenomPower; set => agentPhenomPower = value; }
        public Sprite PreviewSprite => previewSprite;

        public bool IsHidedVisual { get=>skin.IsHided;  }

        public bool MoveToTargetCondition() 
        {
            if (MovementTarget != null)
            {
                if (MovementTarget.TryGetComponent(out ChairMovePoint ch))
                {
                    var chair = ch.GetComponentInParent<ChairInterier>();
                    return chair.ChairInfo.ThisAgent == null;
                }
                return true;
            }
            else
                return false;
        }

        private Transform TryRedirectMovementTarget(Transform value)
        {
            if (value.TryGetComponent(out BoardInterier board))
            {
                if (!board.RightPlace.IsOccuped)
                    return board.RightPlace.transform;
                else if (!board.LeftPlace.IsOccuped)
                    return board.LeftPlace.transform;
            }
            else if (value.TryGetComponent(out ChairInterier chair))
            {
                if (!chair.RightPlace.IsOccuped)
                    return chair.RightPlace.transform;
                else if (!chair.LeftPlace.IsOccuped)
                    return chair.LeftPlace.transform;
            }
            return value;
        }
        public void AddRelationsChangesToSpeech<TSpeechAgent>(SpeakAction<TSpeechAgent, TAgent> speechToRespond, TSpeechAgent speechAgent)
            where TSpeechAgent : SchoolAgentBase<TSpeechAgent>
        {
            var relations = RelationsSystem.GetCurrentRelationTo(speechAgent);
            if (relations == null)
            {
                relations = RelationsSystem.CreateNew(
                    new FamiliarRelationship<TAgent, IAgent, SchoolAgentStateBase<TAgent>>
                    ((TAgent)this, speechAgent));
            }
            var influence = CalculateRelationshipInfluenceForSpeech(speechToRespond);
            RelationsSystem.AddInfluenceForRelations(relations, influence);
        }
        private float CalculateRelationshipInfluenceForSpeech<TSpeechAgent>(SpeakAction<TSpeechAgent, TAgent> speechToCalculate)
            where TSpeechAgent : SchoolAgentBase<TSpeechAgent>
        {
            var table = TablesHandler.AgentToSpeechRelationsInfluenceTable;
            var speechType = speechToCalculate.GetType().Name;
            //16 векторов для данного набора характера
            var thisAgentCharVectors = table.GetTableValuesFor<TAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
                ((TAgent)this, 0);
            //реакции на speechToCalculate для данных векторов
            var selected = thisAgentCharVectors.Where(x => x.SpeechToReact.Equals(speechType));
            var totalInfluence = selected.Sum(x => x.ProbablyReactionInfluence);
            return totalInfluence;
        }

        /// <summary>
        /// Реакция на <paramref name="speechToReact"/>. 
        /// Возвращает ответную реплику и меняет взаимоотношения в зависимости от реплики.
        /// </summary>
        /// <param name="speechToReact"></param>
        /// <returns></returns>
        public SpeakAction<TAgent,TInitiator> GetResponseAtSpeech<TInitiator>(SpeakAction<TInitiator, TAgent> speechToReact, TInitiator speaker)
            where TInitiator: SchoolAgentBase<TInitiator>
        {
            var table = TablesHandler.AgentToSpeechResponsesTable;
            var speechType = speechToReact.GetType().Name;
            //16 векторов для данного набора характера
            var thisAgentCharVectors = table.GetTableValuesFor<TAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
                ((TAgent)this, 0);
            //ответы на speechToRespond для данных векторов
            var selected = thisAgentCharVectors.Where(x => x.SpeechToReact.Equals(speechType));
            var selectedProbReactions = selected.SelectMany(x => x.ProbablyReactions.ProbReactions);
            var tuples = selectedProbReactions.Select(x => (x, x.ReactionWeight)).ToList();
            var (Key, Value) = tuples.SelectRandom();
            if (Key != null)//ответ есть
                return Key.GetReaction((TAgent)this, speaker);
            else
            {
                //throw new System.Exception($"Для спича {speechToReact} не было ответного спича у агента {this}");
                var res = new KeepSilentAnswer<TAgent, TInitiator>();
                res.Initiate(speaker, this);
                return res;
            }
        }
        public override TNewState SetState<TNewState>()
        {
            var state = new TNewState();
            state.Initiate((TAgent)this);
            CurrentState = state;
            return state;
        }
        public void StartActionVisual(IStatusBarDataSource source)
        {
            //TODO вызов коорутины видуализации диалога
            statusBar.Initiate(source);
            statusBar.Show();
        }

        public void StartAppearing()
        {
            StartCoroutine(AppearingRoutine());
        }

        private IEnumerator AppearingRoutine()
        {
            while (!skin.IsFullShowed)
            {
                skin.IncreaseVisibility();
                yield return null;
            }
        }

        public void StartDisappearing()
        {
            StartCoroutine(DisappearRoutine());
        }

        private IEnumerator DisappearRoutine()
        {
            while (!skin.IsHided)
            {
                skin.DecreaseVisibility();
                yield return null;
            }
        }

        public void EndActionVisualForce()
        {
            statusBar.Hide();
        }
        public TState SetState<TState>(TState state)
           where TState : SchoolAgentStateBase<TAgent>
        {
            CurrentState = state;
            return state;
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
            
        }
        public IEnumerator OnBeforeStartMovement()
        {
            if (AgentEnvironment.ChairInfo != null//на стуле
                 && NewTargetNotCurrentChair())//и цель - не тот же стул
            {
                yield return OnLeaveChair();
            }
        }
        
        private bool NewTargetNotCurrentChair()
        {
            return MovementTarget.gameObject.GetComponentInParent<ChairInterier>() != AgentEnvironment.ChairInfo.ThisInterier;
            //return (MonoBehaviour)MovementTarget != AgentEnvironment.ChairInfo.ThisInterier;
        }
        public IEnumerator OnLeaveChair()
        {
            AgentEnvironment.ChairInfo.ThisAgent = null;
            var leavedChair = AgentEnvironment.ChairInfo.ThisInterier;
            AgentEnvironment.ChairInfo = null;
            AgentEnvironment.TableInfo.RemoveAgent(this);
            AgentEnvironment.TableInfo = null;

            var point = leavedChair.GetFreeChairPoint();
            if (point != null)
            {
                transform.position = point.transform.position;
                //AgentRigidbody.pos(point.transform.position);
                yield return null;
            }
            else throw new Exception();
            AgentRigidbody.bodyType = RigidbodyType2D.Dynamic;
            leavedChair.Collider2D.isTrigger = false;
            
        }

        public IEnumerator OnTargetReachedRoutine(Transform target)
        {
            if (target.TryGetComponent(out ChairMovePoint chairMP))
            {
                var chair = chairMP.GetComponentInParent<ChairInterier>();
                if (AgentEnvironment.ChairInfo == chair.ChairInfo)
                {//в колбеке AIPath стул был определен как текущий
                    AgentRigidbody.bodyType = RigidbodyType2D.Kinematic;
                    AgentRigidbody.MovePosition(chair.transform.position);
                    yield return RotateRoutine(chair.transform.up);
                    //Debug.Log("After rotate on chair routine");
                }
            }
            else if (target.TryGetComponent(out ChairInterier chairTarget))
            {
                if (AgentEnvironment.ChairInfo == chairTarget.ChairInfo)
                {
                    AgentRigidbody.bodyType = RigidbodyType2D.Kinematic;
                    AgentRigidbody.MovePosition(chairTarget.transform.position);
                    yield return RotateRoutine(chairTarget.transform.up);
                    //Debug.Log("After rotate on chair routine");
                }
            }
        }

       
    }
}