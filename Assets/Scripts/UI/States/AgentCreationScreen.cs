using BehaviourModel;
using Common;
using UnityEngine;

namespace UI
{
    public class AgentCreationScreen : UIScreenBase
    {
        #region common

        [SerializeField] private AgentsSelectionScreen agentsSelectionScreen;
        [SerializeField] private ContentOrderHandler cardsOrderHandler;
        [SerializeField] private AgentCardPreview currentPreview;
        [SerializeField] private AgentRawData �urrentData;
        public AgentRawData CurrentData { get => �urrentData; private set => �urrentData = value; }
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

        [Header("�������� ���������")]
        [Space]
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

        public CharacterRect CharacterRect => characterRect;
        public FeaturesRect FeaturesRect => featuresRect;
        public NervousSystemRect NervousSystemRect { get => nervousSystemRect; }

        #endregion character

        #region weight

        [Space]
        [Header("����������� ���������� �������� ���� � �����")]
        [SerializeField] private ListVector3IntHandler ageHeightsHandler;

        [SerializeField] private ListVector3IntHandler ageWeightsHandler;

        public ListVector3IntHandler AgeHeightsHandler { get => ageHeightsHandler; }
        public ListVector3IntHandler AgeWeightsHandler { get => ageWeightsHandler; }

        #endregion weight

        private void ConfirmAgentCreation()
        {
            AgentCardPreview newCard;
            if (CurrentPreview == null)//����� �����
            {
                //������� �������� �� ������ ������
                newCard = Instantiate(SceneDataStorage.Storage.AgentCardPrafab,
                    cardsOrderHandler.transform).GetComponent<AgentCardPreview>();
                CurrentPreview = newCard;
            }

            //������ ����� ��� ����������� ������������?
            if (CurrentData == null)
            {
                CurrentData = new AgentRawData();
                //��������� ���� � ���������� ����������� � ����� ��� ������������� GO � ����� �����������
                CurrentData.Initiate(this);
            }
            else
                CurrentData.Initiate(this);
            CurrentPreview.Initiate(this, CurrentData);
            agentsSelectionScreen.AddAgentData(CurrentData);
            BeforeChangeState();
        }

        private void SetDefaultControls<T>() where T : AgentBase
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.SetDefaultControlsValues<T>();
        }

        private void SetExistDataControls<T>(AgentRawData rawData) where T : AgentBase
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.SetControlsValues<T>(rawData);
        }

        public override void BeforeChangeState()
        {
            base.BeforeChangeState();
            cardsOrderHandler.ReorderContent();
            CurrentData = null;
            CurrentPreview = null;
        }

        public void InitiateState<T>() where T : AgentBase
        {
            base.InitiateState();
            ResetControlls<T>();
        }

        public void InitiateState<T>(AgentRawData ard, AgentCardPreview acp) where T : AgentBase
        {
            InitiateState<T>(ard);
            CurrentPreview = acp;
        }

        public void InitiateState<T>(AgentRawData ard) where T : AgentBase
        {
            base.InitiateState();
            ResetControlls<T>(ard);
            CurrentData = ard;
        }

        public void LoadAgentButtonClick()
        {
            CanvasController.Controller.AgentsConfigureScreen.AgentLoadScreen.InitiateState();
        }

        public void OnAgeSelectionChanged()
        {
            var ageChangeHandler = new AgeChangeHandler(SelectedAge, this);
            ageChangeHandler.ResetCharacterExtremeValues();
            ageChangeHandler.ResetWieghtAndHeightDropdowns();
        }

        public void OnConfirmCreationButtonClick()
        {
            ConfirmAgentCreation();
        }

        public void ResetControlls<T>(AgentRawData rawData = null) where T : AgentBase
        {
            if (rawData == null)
                SetDefaultControls<T>();
            else
                SetExistDataControls<T>(rawData);
        }

        public void SaveButtonClick()
        {
            CanvasController.Controller.AgentsConfigureScreen.AgentSaveScreen.InitiateState();
        }

        public void SetFullRandomValuesButtonClick()
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.RandomizeControlsValues();
        }
    }
}