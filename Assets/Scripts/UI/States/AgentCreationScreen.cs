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
        [SerializeField] private RectTransform createdCardsPreviewsRect;
        [SerializeField] private AgentCardPreview currentPreview;
        [SerializeField] private HumanRawData сurrentData;
        public HumanRawData CurrentData { get => сurrentData; private set => сurrentData = value; }
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

        private void ConfirmAgentCreation(Type createdType)
        {
            if (createdType.Equals<PupilAgent>())
                ConfirmPupilCreation();
            else if (createdType.Equals<TeacherAgent>())
                ConfirmTeacherCreation();
            else throw new Exception($"Unexpected type {createdType.FullName}");
        }

        private void ConfirmPupilCreation()
        {
            if (CurrentPreview == null)//новый агент
            {
                //создать карточку на панели выбора
                CurrentPreview = Instantiate(SceneDataStorage.Storage.AgentCardPrafab,
                    createdCardsPreviewsRect).GetComponent<AgentCardPreview>();
            }

            //создаём новую или редактируем существующую?
            if (CurrentData == null)
            {
                CurrentData = new PupilRawData();
                //сохранить дату с выбранными параметрами в класс для инициализации GO с этими параметрами
            }
            CurrentData.Initiate(this);
            CurrentPreview.Initiate(this, CurrentData);
            agentsSelectionScreen.AddAgentData((PupilRawData)CurrentData);
            BeforeChangeState();
        }

        private void ConfirmTeacherCreation()
        {
            if (CurrentPreview == null)//новый агент
            {
                //создать карточку на панели выбора
                CurrentPreview = Instantiate(SceneDataStorage.Storage.AgentCardPrafab,
                    createdCardsPreviewsRect).GetComponent<AgentCardPreview>();
                cardsOrderHandler.FirstTransform = (RectTransform)CurrentPreview.transform;
                cardsOrderHandler.ReorderContent();
            }
            //создаём новую или редактируем существующую?
            if (CurrentData == null)
            {
                CurrentData = new TeacherRawData();
                //сохранить дату с выбранными параметрами в класс для инициализации GO с этими параметрами
            }
            CurrentData.Initiate(this);
            CurrentPreview.Initiate(this, CurrentData);
            agentsSelectionScreen.SelectedTeacher = (TeacherRawData)CurrentData;
            BeforeChangeState();
        }

        private bool CreationAllowed()
        {
            return !string.IsNullOrEmpty(NameInputFieldButtonPair.InputField.text);
        }

        private void NotifyUser()
        {
            Debug.Log("Creation failed");
        }

        /// <summary>
        /// Инициализирует контролы по умолчанию
        /// </summary>
        private void ResetControls()
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.SetDefaultControlsValues();
        }

        /// <summary>
        /// Инициализирует контролы на основании существующих данных
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
            InputSystem.InputListener.Listener.SwipesAllowed = true;
        }

        /// <summary>
        /// Инициализация по известному типу - создание нового
        /// </summary>
        /// <param name="type"></param>
        public void InitiateState(Type type)
        {
            base.InitiateState();
            CreatedType = type;
            ResetControls();
            InputSystem.InputListener.Listener.SwipesAllowed = false;
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
            InputSystem.InputListener.Listener.SwipesAllowed = false;
        }

        public void LoadAgentButtonClick()
        {
            if (CreatedType.IsEquivalentTo(typeof(PupilAgent)))
                CanvasController.Controller.AgentsConfigureScreen.AgentLoadScreen.InitiateState<PupilRawData, PupilAgent>();
            else
                CanvasController.Controller.AgentsConfigureScreen.AgentLoadScreen.InitiateState<TeacherRawData, TeacherAgent>();
        }

        public void OnAgeSelectionChanged()
        {
            var ageChangeHandler = new AgeChangeHandler(SelectedAge, this);
            ageChangeHandler.ResetCharacterExtremeValues();
            ageChangeHandler.ResetWeightAndHeightDropdowns();
        }

        public void OnCloseButtonCLick()
        {
            BeforeChangeState();
        }

        public void OnConfirmCreationButtonClick()
        {
            if (CreationAllowed())
                ConfirmAgentCreation(CreatedType);
            else
                NotifyUser();
        }

        public void SaveButtonClick()
        {
            if (CreatedType.IsEquivalentTo(typeof(PupilAgent)))
                CanvasController.Controller.AgentsConfigureScreen.AgentSaveScreen.InitiateState<PupilRawData, PupilAgent>();
            else
                CanvasController.Controller.AgentsConfigureScreen.AgentSaveScreen.InitiateState<TeacherRawData, TeacherAgent>();
        }

        public void SetFullRandomValuesButtonClick()
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.RandomizeControlsValues();
        }
    }
}