using BuildingModule;
using Common;
using Core;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AgentBase : MonoBehaviour, IUIViewedObject, IEmotionSource, ICurrentRoomHandler
    {
        #region main

        [SerializeField] private ushort agentAge;
        [SerializeField] private CircleCollider2D agentCollider;
        [SerializeField] private Rigidbody2D agentRigidbody;
        [SerializeField] private string agentDescription;
        [SerializeField] private ushort agentHeight;
        [SerializeField] private string agentName;
        [SerializeField] private SpriteRenderer agentRenderer;
        [SerializeField] private SexBase agentSex;
        [SerializeField] private int agentValue;
        [SerializeField] private ushort agentWeight;
        [SerializeField] private ExperimentProcessHandler experimentHandler;
        [SerializeField] private bool idleWaiting;
        [SerializeField] private bool isActing;
        [SerializeField] private Sprite previewSprite;
        [SerializeField] private Room currentRoom;

        public RelationshipBase GetCurrentRelationTo(AgentBase ab) => relationsSystem.GetCurrentRelationTo(ab);

        #endregion main

        #region systems

        [SerializeField] private CharacterSystem characterSystem;
        [SerializeField] private FeaturesSystem featuresSystem;
        [SerializeField] private MovementComponent movementComponent;
        [SerializeField] private NervousSystem nervousSystem;
        [SerializeField] private RelationsSystem relationsSystem;
        [SerializeField] private Eyes thisEyes;

        #endregion systems
        public RelationsSystem RelationsSystem => relationsSystem;
        /// <summary>
        /// Список всех обнаруженных явлений.
        /// </summary>
        /// <returns></returns>
        private List<IPhenomenon> GetPhenomenons()
        {
            //анализируем обстановку:
            //1.1)в зависимости от текущего глобального события (занятие, перемена, etc) - глобальные явления
            var globalEventSource = ExperimentHandler.CurrentGlobalEvent;
            //1.2)в зависимости от текущих временных событий (действия других агентов, etc) - временные явления
            var temporatyEffectsSources = ExperimentHandler.TemporaryEffects;
            //1.3)в зависимости от внешних условий (объекты интерьера, !другие люди!) - контекст окружения
            var visualSources = thisEyes.GetPhenomenons();

            //1.4)в зависимости от внутренних побуждений (характер, фичи, ВОСПОМИНАНИЯ, ВЗАИМООТНОШЕНИЯ) - личностный контекст
            //var featuresContext = FeaturesSystem.GetPhenomenons();
            //var characterSources = CharacterSystem.GetPhenomenons();
            //TODO система воспоминаний
            //var remainsSources = MemorySystem.CreateActionsSources();
            //TODO система взаимоотношений
            //var relationsSources = RelationshipSystem.CreateActionsSources();

            List<IPhenomenon> phenomens = new List<IPhenomenon>();
            phenomens.Add(globalEventSource);
            phenomens.AddRange(temporatyEffectsSources);
            phenomens.AddRange(visualSources);
            //sources.AddRange(featuresContext);
            //sources.AddRange(characterSources);
            return phenomens;
        }

        private IEnumerator IdleActionRoutine()
        {
            while (idleWaiting)
            {
                yield return new WaitForSeconds(1f);
                Debug.Log("Idle");
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Entrance ent))
            {
                CurrentRoom = ent.CurrentRoom;
            }
        }
        /// <summary>
        /// Главный процесс агента. Здесь производятся действия.
        /// </summary>
        /// <returns></returns>
        private IEnumerator MainRoutine()
        {
            while (IsActing)
            {
                //1)анализируем обстановку -
                //2)шлём НС набор обнаруженных явлений для обработки -
                NervousSystem.AddNewPhenomenons(GetPhenomenons());
                NervousSystem.CurrentGlobalContext = ExperimentHandler.CurrentGlobalEvent;
                NervousSystem.ProceedPhenomenons();
                NervousSystem.StartThinking();
                //3)определяем возможные действия на основании состояния НС -
                //4)НС возвращает выбранное действие -
                var selectedAction = NervousSystem.SelectAction();
                //5)агент выполняет до окончания или прерывания
                yield return selectedAction;
                //yield return IdleActionRoutine();
                yield return null;
                //повторить
            }
        }

        public Collider2D AgentCollider => agentCollider;

        public CharacterSystem CharacterSystem { get => characterSystem; protected set => characterSystem = value; }

        public ExperimentProcessHandler ExperimentHandler { get => experimentHandler; private set => experimentHandler = value; }

        public FeaturesSystem FeaturesSystem { get => featuresSystem; protected set => featuresSystem = value; }

        public bool IsActing { get => isActing; private set => isActing = value; }

        public Coroutine MainCoroutine { get; private set; }

        public string Name => agentName;

        public NervousSystem NervousSystem { get => nervousSystem; protected set => nervousSystem = value; }

        public string ObjDescription => agentDescription;

        public int PhenomenonPower { get => agentValue; set => agentValue = value; }

        public Sprite PreviewSprite => previewSprite;

        public Rigidbody2D AgentRigidbody => agentRigidbody;

        public Room CurrentRoom { get => currentRoom; set => currentRoom = value; }

        public virtual void Initiate(HumanRawData data)
        {
            //TODO доделать инициализацию
            //previewSprite =
            agentName = data.AgentName;
            agentSex = data.Sex;
            agentAge = data.age;
            agentWeight = data.Weight;
            agentHeight = data.Height;

            PhenomenonPower = 5;
            NervousSystem.Initiate(data);
            CharacterSystem.Initiate(data);
            FeaturesSystem.Initiate(data);
            transform.parent = null;
        }

        public bool IsComrade(AgentBase ab) => relationsSystem.IsComrade(ab);

        public bool IsEnemy(AgentBase ab) => relationsSystem.IsEnemy(ab);

        /// <summary>
        /// Является ли <paramref name="agent"/> знакомым для агента?
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public bool IsFamiliar(AgentBase ab) => relationsSystem.IsFamiliar(ab);

        public bool IsFellow(AgentBase ab) => relationsSystem.IsFellow(ab);

        /// <summary>
        /// Непрятель
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        public bool IsFoe(AgentBase ab) => relationsSystem.IsFoe(ab);

        public bool IsFriend(AgentBase ab) => relationsSystem.IsFriend(ab);

        public void StartActing(ExperimentProcessHandler experimentProcessHandler)
        {
            IsActing = true;
            ExperimentHandler = experimentProcessHandler;
            MainCoroutine = StartCoroutine(MainRoutine());
        }
    }
}