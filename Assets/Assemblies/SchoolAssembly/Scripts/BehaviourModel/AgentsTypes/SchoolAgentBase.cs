using BuildingModule;
using Common;
using Events;
using Pathfinding;
using System;
using System.Collections;
using System.Linq;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SchoolAgentBase<TAgent>: 
        AgentBase<TAgent, ActionBase, FeatureBase, Sensor>,
        IUIViewedObject,
        IPhenomenon,
        IMovementTarget,
        ICurrentStateHandler<SchoolAgentStateBase<TAgent>, TAgent>
        where TAgent : SchoolAgentBase<TAgent>
    {
        #region main

        #region components

        [Space, SerializeField] private CircleCollider2D agentCollider;
        [SerializeField] private SpriteRenderer agentRenderer;
        [SerializeField] private SchoolAIPath pathfinder;
        [SerializeField] private Sprite previewSprite;
        [SerializeField] private AgentStatusBar statusBar;
        [SerializeField] AgentsSkin skin;
        [SerializeField] AIDestinationSetter setter;      


        #endregion components

        #region base params
        [Space, SerializeField] private string agentDescription;
        [SerializeField] private string agentName;
        [SerializeField] private float agentPhenomPower;
        #endregion base params
        [Space, SerializeField] SchoolRelationsTableHandler tablesHandler;
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
            }
        }
     
        public abstract GlobalEvent CurrentEvent { get; }

        #endregion main
        [SerializeField] protected SchoolAgentStateBase<TAgent> currentState;
        public SchoolAgentStateBase<TAgent> CurrentState { get => currentState; set => currentState = value; }

        public IEnumerator RotateRoutine(Vector3 directionVector)
        {
            var rotattor = new RotationHandler();
            yield return rotattor.RotateToFaceDirection(directionVector, transform, RotationHandler.MiddleRotation);
        }

        public CircleCollider2D AgentCollider => agentCollider;
       
        public string Name => agentName;
        public string ObjDescription => agentDescription;
        public float PhenomValue { get => agentPhenomPower; set => agentPhenomPower = value; }
        public Sprite PreviewSprite => previewSprite;

        public bool IsHidedVisual { get=>skin.IsHided;  }

        public bool MoveToTargetCondition() 
        {
            if (MovementTarget != null)
            {
                if (MovementTarget.TryGetComponent(out ChairMovePoint ch))
                {
                    var chair = ch.GetComponentInParent<ChairInterier>();
                    return chair.ChairInfo.CurrentAgent == null;
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
        public void AddRelationsChangesToAction<TSpeechAgent>(IRelationsInfluenceHandler<TAgent> influenceSource, TSpeechAgent speechAgent)
            where TSpeechAgent : SchoolAgentBase<TSpeechAgent>
        {
            var relations = RelationsSystem.GetCurrentRelationTo(speechAgent);
            if (relations == null)
            {
                relations = new FamiliarRelationship<TAgent, IAgent>
                    ((TAgent)this, speechAgent);
               RelationsSystem.AddIfNotContains(relations);
            }
            var influence = influenceSource.GetRelationshipInfluence((TAgent)this);
            RelationsSystem.AddInfluenceForRelations(relations, influence);
        }
       

        /// <summary>
        /// Реакция на <paramref name="speechToReact"/>. 
        /// Возвращает ответную реплику.
        /// </summary>
        /// <param name="speechToReact"></param>
        /// <returns></returns>
        public SpeakAction<TAgent,TInitiator> GetReactionAtSpeech<TInitiator>(SpeakAction<TInitiator, TAgent> speechToReact, TInitiator speaker)
            where TInitiator: SchoolAgentBase<TInitiator>
        {
            var responsesTable = TablesHandler.AgentToSpeechResponsesTable;
            var speechType = speechToReact.GetType().Name;
            //16 векторов для данного набора характера
            var characterTableVectors = responsesTable.GetTableValuesFor<TAgent, ActionBase, FeatureBase, Sensor>
                ((TAgent)this, 0);
            //ответы на speechToRespond для данных векторов
            var selectedResponsesToSpeech = characterTableVectors.Where(x => x.SpeechToReact.Equals(speechType));
            var selectedProbReactions = selectedResponsesToSpeech.SelectMany(x => x.ProbablyReactions.ProbReactions);
            var itemWeightPairs = selectedProbReactions.Select(x => (x, x.ReactionWeight)).ToList();
            var (reaction, Value) = itemWeightPairs.SelectRandom();
            if (reaction != null)
                return reaction.GetReaction((TAgent)this, speaker);
            else
                throw new Exception($"Для спича {speechToReact} не было ответного спича у агента {this}. Добавь реакции на спич в таблицу");
        }
     
        public void StartActionVisual(IStatusBarDataSource source)
        {
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
                yield return new WaitForFixedUpdate();
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
                yield return new WaitForFixedUpdate();
            }

            var placer = new PlaceFinder(()=> EntranceRoot.Root.TeleportPlace.position, .2f, 2f, new ContactFilter2D() { useLayerMask = false });
            while (!placer.TryFindPlace()) { }
            transform.position = placer.Place;
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
    
        public IEnumerator OnBeforeStartMovement()
        {
            if (AgentEnvironment.ChairInfo != null//на стуле
                 && NewTargetNotCurrentChair())//и цель - не тот же стул
            {
                yield return OnLeaveChair();
            }
        }
        public  TNewState SetState<TNewState>() where TNewState : SchoolAgentStateBase<TAgent>, new()
        {
            var state = new TNewState();
            state.Initiate((TAgent)this);
            CurrentState = state;
            return state;
        }
        public abstract void SetDefaultState();
        private bool NewTargetNotCurrentChair()
        {
            return MovementTarget.gameObject.GetComponentInParent<ChairInterier>() != AgentEnvironment.ChairInfo.ThisInterier;
        }
        public IEnumerator OnLeaveChair()
        {
            pathfinder.constrainInsideGraph = true;
            AgentEnvironment.ChairInfo.CurrentAgent = null;
            var leavedChair = AgentEnvironment.ChairInfo.ThisInterier;
            AgentEnvironment.ChairInfo = null;
            AgentEnvironment.TableInfo.RemoveAgent(this);
            AgentEnvironment.TableInfo = null;

            var point = leavedChair.GetFreeChairPoint();
            if (point != null)
            {
                transform.position = point.transform.position;
                yield return new WaitForFixedUpdate();
            }
            else throw new Exception();
            leavedChair.Collider2D.isTrigger = false;
            
        }

        public IEnumerator OnTargetReachedRoutine(Transform target)
        {
            if (target.TryGetComponent(out ChairMovePoint chairMP))
            {
                var chair = chairMP.GetComponentInParent<ChairInterier>();
                if (AgentEnvironment.ChairInfo == chair.ChairInfo)//в колбеке AIPath стул был определен как текущий
                {
                    transform.position = chair.transform.position;
                    yield return RotateRoutine(chair.transform.up);
                }
            }
            else if (target.TryGetComponent(out ChairInterier chairTarget))
            {
                if (AgentEnvironment.ChairInfo == chairTarget.ChairInfo)
                {
                    transform.position = chairTarget.transform.position;
                    yield return RotateRoutine(chairTarget.transform.up);
                }
            }
        }

        public void SetProps(HumanRawData data)
        {
            //TODO доделать инициализацию
            //previewSprite =
            agentName = data.AgentName;

            PhenomValue = 5;
        }
    }
}