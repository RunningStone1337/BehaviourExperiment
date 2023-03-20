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
//#if DEBUG
//                if (setter.target != null)
//                    Debug.Log($"Target set is {setter.target}");
//                else
//                    Debug.Log($"Target set is null");
//#endif
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

            var placer = new PlaceFinder(()=> EntranceRoot.Root.TeleportPlace.position, .2f, 2f, new ContactFilter2D() { useLayerMask = false });
            while (!placer.TryFindPlace()) { }
                //yield return null;
            transform.position = placer.Place;
        }
        //public void OnGlobalEventChangedCallback(CurrentEventChangedEventArgs args)
        //{
        //    Brain.PhenomensToReact.Clear();
        //    Brain.Clear();
        //}

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
             where TLowAnx : LowAnxiety
            where TMidAnx : MiddleAnxiety 
            where THighAnx : HighAnxiety 

            where TLowSoc : LowClosenessSociability 
            where TMidSoc : MiddleClosenessSociability 
            where THighSoc : HighClosenessSociability 

            where TLowStab : LowEmotionalStability 
            where TMidStab : MiddleEmotionalStability 
            where THighStab : HighEmotionalStability 

            where TLowNonc : LowNonconformism 
            where TMidNonc : MiddleNonconformism 
            where THighNonc : HighNonconformism 

            where TLowNorm : LowNormativityOfBehaviour 
            where TMidNorm : MiddleNormativityOfBehaviour 
            where THighNorm : HighNormativityOfBehaviour 

            where TLowRad : LowRadicalism 
            where TMidRad : MiddleRadicalism 
            where THighRad : HighRadicalism 

            where TLowSelf : LowSelfcontrol 
            where TMidSelf : MiddleSelfcontrol 
            where THighSelf : HighSelfcontrol 

            where TLowSens : LowSensetivity 
            where TMidSens : MiddleSensetivity 
            where THighSens : HighSensetivity 

            where TLowSusp : LowSuspicion 
            where TMidSusp : MiddleSuspicion 
            where THighSusp : HighSuspicion 

            where TLowTens : LowTension 
            where TMidTens : MiddleTension 
            where THighTens : HighTension 

            where TLowExpre : LowExpressiveness 
            where TMidExpre : MiddleExpressiveness 
            where THighExpre : HighExpressiveness 

            where TLowInt : LowIntelligence 
            where TMidInt : MiddleIntelligence 
            where THighInt : HighIntelligence 

            where TLowDrea : LowDreaminess 
            where TMidDrea : MiddleDreaminess 
            where THighDrea : HighDreaminess 

            where TLowDom : LowDomination 
            where TMidDom : MiddleDomination 
            where THighDom : HighDomination 

            where TLowDipl : LowDiplomacy 
            where TMidDipl : MiddleDiplomacy 
            where THighDipl : HighDiplomacy 

            where TLowCour : LowCourage 
            where TMidCour : MiddleCourage 
            where THighCour : HighCourage 

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