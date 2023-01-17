using BuildingModule;
using Common;
using Core;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AgentBase : MonoBehaviour, IUIViewedObject, IContextCreator
    {
        #region main

        [SerializeField] private ushort agentAge;
        [SerializeField] private string agentDescription;
        [SerializeField] private ushort agentHeight;
        [SerializeField] private string agentName;
        [SerializeField] private SpriteRenderer agentRenderer;
        [SerializeField] private SexBase agentSex;
        [SerializeField] private ushort agentWeight;
        [SerializeField] private ExperimentProcessHandler experimentHandler;
        [SerializeField] private bool idleWaiting;
        [SerializeField] private bool isActing;
        [SerializeField] private CircleCollider2D nearestFeelingCollider;
        [SerializeField] private Sprite previewSprite;

        #endregion main

        #region systems

        [SerializeField] private CharacterSystem characterSystem;
        [SerializeField] private int currentComfort;
        [SerializeField] private FeaturesSystem featuresSystem;
        [SerializeField] private MovementComponent movementComponent;
        [SerializeField] private NervousSystem nervousSystem;
        [SerializeField] private Eyes thisEyes;

        #endregion systems

        #region interier

        [SerializeField] private List<PlacedInterier> feltInterier;
        [SerializeField] private List<PlacedInterier> seengInterier;

        #endregion interier

        /// <summary>
        /// �������� ���������.
        /// ������������ ��� ��� ����� �������� � � ������� ���� ���������� � �������.
        /// </summary>
        /// <returns></returns>
        private List<IContext> CreateOuterContext()
        {
            var res = new List<IContext>();
            foreach (var fi in feltInterier)
                res.AddRange(fi.CreateContext());
            foreach (var fi in seengInterier)
                res.AddRange(fi.CreateContext());
            return res;
        }

        private IEnumerator IdleActionRoutine()
        {
            while (idleWaiting)
            {
                yield return new WaitForSeconds(1f);
                Debug.Log("Idle");
            }
        }

        /// <summary>
        /// ������� ������� ������. ����� ������������ ������������ ��������.
        /// </summary>
        /// <returns></returns>
        private IEnumerator MainRoutine()
        {
            //����������� ���������� � ��������� ��������:
            //1)� ����������� �� �������� ����������� ������� (�������, ��������, etc) - ���������� ��������
            //2)� ����������� �� ������� ��������� ������� (�������� ������ �������, etc) - ��������� ��������
            //3)� ����������� �� ������� ������� (������� ���������, ��� ���������) - �������� ���������
            //4)� ����������� �� ���������� ���������� (��������, ����) - ���������� ��������
            //��� ���� ���������� ����������

            while (IsActing)
            {
                //����� �������� - �������� ��������� ��������
                //� ������� ��������� ����� ���� �������� ����������� ��������
                var globalContext = ExperimentHandler.CurrentGlobalEvent;
                var temporatyContexts = ExperimentHandler.TemporaryEffects;
                var outerContext = CreateOuterContext();
                var personalContexts = CreateContext();
                //yield return IdleActionRoutine();
                yield return null;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != nearestFeelingCollider && collision != thisEyes.ViewCollider)
            {
                var contextHandler = collision.GetComponent<IContextCreator>();
                if (contextHandler != null)
                {
                    if (contextHandler is PlacedInterier pi)
                        FeltInterier.Add(pi);
                    if (contextHandler is IInfluenceSource iis)
                        CurrentComfort += iis.InfluenceValue;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision != nearestFeelingCollider && collision != thisEyes.ViewCollider)
            {
                var contextHandler = collision.GetComponent<IContextCreator>();
                if (contextHandler != null)
                {
                    if (contextHandler is PlacedInterier pi)
                        FeltInterier.Remove(pi);
                    if (contextHandler is IInfluenceSource iis)
                        CurrentComfort -= iis.InfluenceValue;
                }
            }
        }

        public CharacterSystem CharacterSystem { get => characterSystem; protected set => characterSystem = value; }

        public int CurrentComfort { get => currentComfort; set => currentComfort = Mathf.Clamp(value, 0, 10); }
        public ExperimentProcessHandler ExperimentHandler { get => experimentHandler; private set => experimentHandler = value; }

        public FeaturesSystem FeaturesSystem { get => featuresSystem; protected set => featuresSystem = value; }

        public List<PlacedInterier> FeltInterier { get => feltInterier; private set => feltInterier = value; }
        public bool IsActing { get => isActing; private set => isActing = value; }

        public Coroutine MainCoroutine { get; private set; }

        public string Name => agentName;

        public Collider2D NearestFeelingCollider => nearestFeelingCollider;
        public NervousSystem NervousSystem { get => nervousSystem; protected set => nervousSystem = value; }

        public string ObjDescription => agentDescription;

        public Sprite PreviewSprite => previewSprite;
        public List<PlacedInterier> SeeingInterier { get => seengInterier; private set => seengInterier = value; }

        /// <summary>
        /// ���������� �������� - �������� � �����������.
        /// </summary>
        /// <returns></returns>
        public List<IContext> CreateContext()
        {
            var res = new List<IContext>();
            res.AddRange(CharacterSystem.CreateContext());
            res.AddRange(FeaturesSystem.CreateContext());
            return res;
        }

        public virtual void Initiate(HumanRawData data)
        {
            //TODO �������� �������������
            //previewSprite =
            agentName = data.AgentName;
            agentSex = data.Sex;
            agentAge = data.age;
            agentWeight = data.Weight;
            agentHeight = data.Height;

            NervousSystem.Initiate(data);
            CharacterSystem.Initiate(data);
            FeaturesSystem.Initiate(data);
            transform.parent = null;
        }

        public void StartActing(ExperimentProcessHandler experimentProcessHandler)
        {
            IsActing = true;
            ExperimentHandler = experimentProcessHandler;
            MainCoroutine = StartCoroutine(MainRoutine());
        }
    }
}