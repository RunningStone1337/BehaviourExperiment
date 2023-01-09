using BehaviourModel;
using Common;
using Extensions;
using System;
using UnityEngine;

namespace UI
{
    public class AgentCreationScreen : UIScreenBase
    {
        #region common

        [SerializeField] private AgentsSelectionScreen agentsSelectionScreen;
        [SerializeField] private ContentOrderHandler cardsOrderHandler;
        [SerializeField] private AgentCardPreview currentPreview;
        [SerializeField] private PupilRawData сurrentData;
        public PupilRawData CurrentData { get => сurrentData; private set => сurrentData = value; }
        public AgentCardPreview CurrentPreview { get => currentPreview; private set => currentPreview = value; }

        #endregion common

        #region main

        [Header("Основные контролы")]
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
        [Header("Основные параметры")]
        [SerializeField] private ListVector2IntHandler pupilsAgeHandler;

        [SerializeField] private ListVector2IntHandler teachersAgeHandler;
        public ListVector2IntHandler PupilsAgeHandler => pupilsAgeHandler;
        public int SelectedAge { get => int.Parse(ageDropButtonPair.DropdownValue); }
        public ListVector2IntHandler TeachersAgeHandler => teachersAgeHandler;

        #endregion params

        #region character

        [Space]
        [Header("Настройки характера")]
        [SerializeField] private CharacterRect characterRect;

        [Space]
        [Header("Настройки особенностей")]
        [SerializeField] private FeaturesRect featuresRect;

        [Space]
        [Header("Настройки ЦНС")]
        [SerializeField] private NervousSystemRect nervousSystemRect;

        [Space]
        [Header("Настройки шаблонов поведения")]
        [SerializeField] private PrefferedBehaviourRect prefferedBehaviourRect;

        public CharacterRect CharacterRect => characterRect;
        public FeaturesRect FeaturesRect => featuresRect;
        public NervousSystemRect NervousSystemRect => nervousSystemRect;
        public PrefferedBehaviourRect PrefferedBehaviourRect => prefferedBehaviourRect;

        #endregion character

        #region weight

        [Space]
        [Header("Контроллеры диапазонов значений веса и роста")]
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

        private void ConfirmAgentCreation()
        {
            AgentCardPreview newCard;
            if (CurrentPreview == null)//новый агент
            {
                //создать карточку на панели выбора
                newCard = Instantiate(SceneDataStorage.Storage.AgentCardPrafab,
                    cardsOrderHandler.transform).GetComponent<AgentCardPreview>();
                CurrentPreview = newCard;
            }

            //создаём новую или редактируем существующую?
            if (CurrentData == null)
            {
                CurrentData = new PupilRawData();
                //сохранить дату с выбранными параметрами в класс для инициализации GO с этими параметрами
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
            var helper = new AgentCreationScreenInitializer<T>(this);
            helper.SetDefaultControlsValues();
        }

        private void SetExistDataControls<T>(PupilRawData rawData) where T : AgentBase
        {
            var helper = new AgentCreationScreenInitializer<T>(this);
            helper.SetControlsValues(rawData);
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
            CreatedType = typeof(T);
        }

        public void InitiateState<T>(PupilRawData ard, AgentCardPreview acp) where T : AgentBase
        {
            InitiateState<T>(ard);
            CurrentPreview = acp;
        }

        public void InitiateState<T>(PupilRawData ard) where T : AgentBase
        {
            base.InitiateState();
            ResetControlls<T>(ard);
            CurrentData = ard;
        }

        public void LoadAgentButtonClick()
        {
            CanvasController.Controller.AgentsConfigureScreen.AgentLoadScreen.InitiateState();
        }

        public void OnCloseButtonCLick()
        {
            BeforeChangeState();
        }

        public void OnConfirmCreationButtonClick()
        {
            ConfirmAgentCreation();
        }

        public void ResetControlls<T>(PupilRawData rawData = null) where T : AgentBase
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
            if (CreatedType.Equals<PupilAgent>())
            {
                var helper = new AgentCreationScreenInitializer<PupilAgent>(this);
                helper.RandomizeControlsValues();
            }
            else if (CreatedType.Equals<TeacherAgent>())
            {
                var helper = new AgentCreationScreenInitializer<TeacherAgent>(this);
                helper.RandomizeControlsValues();
            }
        }
    }
}