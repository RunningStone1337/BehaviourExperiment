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
        /// ������ ���� ������������ �������.
        /// </summary>
        /// <returns></returns>
        private List<IPhenomenon> GetPhenomenons()
        {
            //����������� ����������:
            //1.1)� ����������� �� �������� ����������� ������� (�������, ��������, etc) - ���������� �������
            var globalEventSource = ExperimentHandler.CurrentGlobalEvent;
            //1.2)� ����������� �� ������� ��������� ������� (�������� ������ �������, etc) - ��������� �������
            var temporatyEffectsSources = ExperimentHandler.TemporaryEffects;
            //1.3)� ����������� �� ������� ������� (������� ���������, !������ ����!) - �������� ���������
            var visualSources = thisEyes.GetPhenomenons();

            //1.4)� ����������� �� ���������� ���������� (��������, ����, ������������, ���������������) - ���������� ��������
            //var featuresContext = FeaturesSystem.GetPhenomenons();
            //var characterSources = CharacterSystem.GetPhenomenons();
            //TODO ������� ������������
            //var remainsSources = MemorySystem.CreateActionsSources();
            //TODO ������� ���������������
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
        /// ������� ������� ������. ����� ������������ ��������.
        /// </summary>
        /// <returns></returns>
        private IEnumerator MainRoutine()
        {
            while (IsActing)
            {
                //1)����������� ���������� -
                //2)��� �� ����� ������������ ������� ��� ��������� -
                NervousSystem.AddNewPhenomenons(GetPhenomenons());
                NervousSystem.CurrentGlobalContext = ExperimentHandler.CurrentGlobalEvent;
                NervousSystem.ProceedPhenomenons();
                NervousSystem.StartThinking();
                //3)���������� ��������� �������� �� ��������� ��������� �� -
                //4)�� ���������� ��������� �������� -
                var selectedAction = NervousSystem.SelectAction();
                //5)����� ��������� �� ��������� ��� ����������
                yield return selectedAction;
                //yield return IdleActionRoutine();
                yield return null;
                //���������
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
            //TODO �������� �������������
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
        /// �������� �� <paramref name="agent"/> �������� ��� ������?
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public bool IsFamiliar(AgentBase ab) => relationsSystem.IsFamiliar(ab);

        public bool IsFellow(AgentBase ab) => relationsSystem.IsFellow(ab);

        /// <summary>
        /// ���������
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