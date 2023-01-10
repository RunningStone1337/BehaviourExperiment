using BehaviourModel;
using Common;
using System;
using Extensions;
using UnityEngine;

namespace UI
{
    public class AgentCreationScreen : UIScreenBase
    {
        #region common

        [SerializeField] private AgentsSelectionScreen agentsSelectionScreen;
        [SerializeField] private ContentOrderHandler cardsOrderHandler;
        [SerializeField] private AgentCardPreview currentPreview;
        [SerializeField] private HumanRawData �urrentData;
        public HumanRawData CurrentData { get => �urrentData; private set => �urrentData = value; }
        public AgentCardPreview CurrentPreview { get => currentPreview; private set => currentPreview = value; }

        #endregion common

        #region main

        [Header("�������� ��������")]
        [SerializeField] private DropdownButtonPair ageDropButtonPair;

        [SerializeField] private AgentImageHandler agentImageHandler;
        [SerializeField] private DropdownButtonPair heightDropButtonPair;
        [SerializeField] private TextButtonPair nameInputFieldButtonPair;
        [SerializeField] private DropdownButtonPair sexDropButtonPair;
        [SerializeField] private DropdownButtonPair weightDropButtonPair;
        public DropdownButtonPair AgeDropButtonPair { get => ageDropButtonPair; }
        public AgentImageHandler AgentImageHandler { get => agentImageHandler; }
        public DropdownButtonPair HeightDropButtonPair { get => heightDropButtonPair; }
        public TextButtonPair NameInputFieldButtonPair { get => nameInputFieldButtonPair; }
        public DropdownButtonPair SexDropButtonPair { get => sexDropButtonPair; }
        public DropdownButtonPair WeightDropButtonPair { get => weightDropButtonPair; }

        #endregion main

        #region params

        [Space]
        [Header("�������� ���������")]
        [SerializeField] private ListVector2IntHandler pupilsAgeHandler;

        [SerializeField] private ListVector2IntHandler teachersAgeHandler;
        public ListVector2IntHandler PupilsAgeHandler => pupilsAgeHandler;
        public int SelectedAge { get => int.Parse(ageDropButtonPair.DropdownValue); }
        public ListVector2IntHandler TeachersAgeHandler => teachersAgeHandler;

        #endregion params

        #region character

        [Space]
        [Header("��������� ���������")]
        [SerializeField] private CharacterRect characterRect;

        [Space]
        [Header("��������� ������������")]
        [SerializeField] private FeaturesRect featuresRect;

        [Space]
        [Header("��������� ���")]
        [SerializeField] private NervousSystemRect nervousSystemRect;

        [Space]
        [Header("��������� �������� ���������")]
        [SerializeField] private PrefferedBehaviourRect prefferedBehaviourRect;

        public CharacterRect CharacterRect => characterRect;
        public FeaturesRect FeaturesRect => featuresRect;
        public NervousSystemRect NervousSystemRect => nervousSystemRect;
        public PrefferedBehaviourRect PrefferedBehaviourRect => prefferedBehaviourRect;

        #endregion character

        #region weight

        [Space]
        [Header("����������� ���������� �������� ���� � �����")]
        [SerializeField] private ListVector3IntHandler pupilAgeHeightsHandler;

        [SerializeField] private ListVector3IntHandler pupilAgeWeightsHandler;
        [SerializeField] private ListVector3IntHandler teacherAgeHeightsHandler;
        [SerializeField] private ListVector3IntHandler teacherAgeWeightsHandler;

        public Type CreatedType { get; private set; }
        public ListVector3IntHandler PupilAgeHeightsHandler { get => pupilAgeHeightsHandler; }
        public ListVector3IntHandler PupilAgeWeightsHandler { get => pupilAgeWeightsHandler; }
        public ListVector3IntHandler TeacherAgeHeightsHandler { get => teacherAgeHeightsHandler; }
        public ListVector3IntHandler TeacherAgeWeightsHandler { get => teacherAgeWeightsHandler; }

        #endregion weight

        private void ConfirmAgentCreation(Type createdType)
        {
            if (createdType.Equals<PupilAgent>())
                ConfirmPupilCreation();
            else if (createdType.Equals<TeacherAgent>())
                ConfirmTeacherCreation();
            else throw new Exception($"Unexpected type {createdType.FullName}");
        }

        private void ConfirmTeacherCreation()
        {
            if (CurrentPreview == null)//����� �����
            {
                //������� �������� �� ������ ������
                CurrentPreview = Instantiate(SceneDataStorage.Storage.AgentCardPrafab,
                    cardsOrderHandler.transform).GetComponent<AgentCardPreview>();
                cardsOrderHandler.FirstTransform = (RectTransform)CurrentPreview.transform;
                cardsOrderHandler.ReorderContent();
            }
            //������ ����� ��� ����������� ������������?
            if (CurrentData == null)
            {
                CurrentData = new TeacherRawData();
                //��������� ���� � ���������� ����������� � ����� ��� ������������� GO � ����� �����������
            }
            CurrentData.Initiate(this);
            CurrentPreview.Initiate(this, CurrentData);
            agentsSelectionScreen.SelectedTeacher = (TeacherRawData)CurrentData;
            BeforeChangeState();
        }

        private void ConfirmPupilCreation()
        {
            if (CurrentPreview == null)//����� �����
            {
                //������� �������� �� ������ ������
                CurrentPreview = Instantiate(SceneDataStorage.Storage.AgentCardPrafab,
                    cardsOrderHandler.transform).GetComponent<AgentCardPreview>();
            }

            //������ ����� ��� ����������� ������������?
            if (CurrentData == null)
            {
                CurrentData = new PupilRawData();
                //��������� ���� � ���������� ����������� � ����� ��� ������������� GO � ����� �����������
            }
            CurrentData.Initiate(this);
            CurrentPreview.Initiate(this, CurrentData);
            agentsSelectionScreen.AddAgentData((PupilRawData)CurrentData);
            BeforeChangeState();
        }

        /// <summary>
        /// �������������� �������� �� ���������
        /// </summary>
        private void ResetControls()
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.SetDefaultControlsValues();
        }

        /// <summary>
        /// �������������� �������� �� ��������� ������������ ������
        /// </summary>
        /// <param name="rawData"></param>
        private void ResetControls(HumanRawData rawData)
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.SetControlsValues(rawData);
        }

        public override void BeforeChangeState()
        {
            base.BeforeChangeState();
            cardsOrderHandler.ReorderContent();
            CurrentData = null;
            CurrentPreview = null;
        }

        /// <summary>
        /// ������������� �� ���������� ���� - �������� ������
        /// </summary>
        /// <param name="type"></param>
        public void InitiateState(Type type)
        {
            base.InitiateState();
            CreatedType = type;
            ResetControls();
        }

        public void InitiateState(HumanRawData ard, AgentCardPreview acp)
        {
            InitiateState(ard);
            CurrentPreview = acp;
        }

        public void InitiateState(HumanRawData ard)
        {
            base.InitiateState();
            var type = Type.GetType(ard.AgentType);
            CreatedType = type;
            ResetControls(ard);
            CurrentData = ard;
        }

        public void LoadAgentButtonClick()
        {
            if (CreatedType.IsEquivalentTo(typeof(PupilAgent)))
                CanvasController.Controller.AgentsConfigureScreen.AgentLoadScreen.InitiateState<PupilRawData>();
            else
                CanvasController.Controller.AgentsConfigureScreen.AgentLoadScreen.InitiateState<TeacherRawData>();
        }

        public void OnCloseButtonCLick()
        {
            BeforeChangeState();
        }

        public void OnConfirmCreationButtonClick()
        {
            ConfirmAgentCreation(CreatedType);
        }        

        public void OnAgeSelectionChanged()
        {
            var ageChangeHandler = new AgeChangeHandler(SelectedAge, this);
            ageChangeHandler.ResetCharacterExtremeValues();
            ageChangeHandler.ResetWeightAndHeightDropdowns();
        }

        public void SaveButtonClick()
        {
            if (CreatedType.IsEquivalentTo(typeof(PupilAgent)))
                CanvasController.Controller.AgentsConfigureScreen.AgentSaveScreen.InitiateState<PupilRawData>();
            else
                CanvasController.Controller.AgentsConfigureScreen.AgentSaveScreen.InitiateState<TeacherRawData>();
        }

        public void SetFullRandomValuesButtonClick()
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.RandomizeControlsValues();
        }
    }
}