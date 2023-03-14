//using BehaviourModel;
//using Core;
//using Events;
//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using Random = UnityEngine.Random;

//namespace Training
//{
//    public enum Relationships
//    {
//        NonFamiliar,
//        Familiar,
//        Fellow,
//        Comrade,
//        Friend,
//        Foe,
//        Enemy
//    }

//    public enum SettingsType
//    {
//        RandomSettings,
//        ManualSettings
//    }

//    public class TrainingConfigurator : EnvironmentInfoSource
//    {
//        [SerializeField] private SettingsType trainedAgentSettingsType;
//        [SerializeField] private SettingsType agentsRelationsSettingsType;
//        [SerializeField] private SettingsType trainSourceAgentSettingsType;
//        [SerializeField] private SettingsType eventSettingsType;
//        [SerializeField] private Relationships agentsManuallyRelations;
//        [SerializeField] private bool logAgent;
//        [SerializeField] private bool logTrainSourceAgent;
//        [SerializeField] private bool logEvent;
//        [SerializeField] private List<GlobalEvent> globalEvents;
//        [SerializeField] private PupilAgent trainedAgent;
//        //[SerializeField] private HumanAttentionComponent trainedAgentAttentionComponent;
//        //[SerializeField] private BehaviorParameters parameters;
//        [SerializeField] private PupilAgent trainSourceAgent;
//        [SerializeField] private PupilRawData trainAgentInitData;
//        [SerializeField] private PupilRawData trainSourceAgentInitData;
//        public PupilRawData TrainAgentInitData { get => trainAgentInitData; set => trainAgentInitData = value; }
//        public PupilRawData TrainSourceAgentInitData { get => trainSourceAgentInitData; set => trainSourceAgentInitData = value; }
//        //public HumanAttentionComponent AttentionComponent { get => trainedAgentAttentionComponent; }
//        //private void Awake()
//        //{
//        //    trainedAgentAttentionComponent.OnRevardCalculatedEvent += OnRevardCalculatedCallback;
//        //}
//        //private void OnDestroy()
//        //{
//        //    trainedAgentAttentionComponent.OnRevardCalculatedEvent -= OnRevardCalculatedCallback;

//        //}
//        private void OnRevardCalculatedCallback(RewardCalculationsEventArgs args)
//        {
//            //Debug.Log($"Последняя эмоция {args.LastReaction} оценена {args.Reward}.\nОтношения: {args.Relations}\nИвент: {args.Event}");
//        }

//        private void CreateNewRelations(Relationships relationsType, PupilAgent trainedAgent, PupilAgent trainSourceAgent)
//        {
//            //switch (relationsType)
//            //{
//            //    case Relationships.NonFamiliar:
//            //        //trainedAgent.RelationsSystem.CreateNewRelationship(new PoorKnownRelation(trainedAgent, trainSourceAgent));
//            //        break;

//            //    case Relationships.Familiar:
//            //        trainedAgent.RelationsSystem.CreateNewRelationship(new FamiliarRelationship(trainedAgent, trainSourceAgent));
//            //        break;

//            //    case Relationships.Fellow:
//            //        trainedAgent.RelationsSystem.CreateNewRelationship(new FellowRelationship(trainedAgent, trainSourceAgent));
//            //        break;

//            //    case Relationships.Comrade:
//            //        trainedAgent.RelationsSystem.CreateNewRelationship(new ComradeRelationship(trainedAgent, trainSourceAgent));
//            //        break;

//            //    case Relationships.Friend:
//            //        trainedAgent.RelationsSystem.CreateNewRelationship(new FriendRelationship(trainedAgent, trainSourceAgent));
//            //        break;

//            //    case Relationships.Foe:
//            //        trainedAgent.RelationsSystem.CreateNewRelationship(new FoeRelationship(trainedAgent, trainSourceAgent));
//            //        break;

//            //    case Relationships.Enemy:
//            //        trainedAgent.RelationsSystem.CreateNewRelationship(new EnemyRelationship(trainedAgent, trainSourceAgent));
//            //        break;

//            //    default:
//            //        break;
//            //}
//        }

//        private void CreateRandomCharacterTraits(PupilAgent agent)
//        {
//            var randomData = new PupilRawData();
//            var maxVal = 11;
//            randomData.calmnessAnxiety = (ushort)Random.Range(1, maxVal);
//            randomData.closenessSociability = (ushort)Random.Range(1, maxVal);
//            randomData.conformismNonconformism = (ushort)Random.Range(1, maxVal);
//            randomData.conservatismRadicalism = (ushort)Random.Range(1, maxVal);
//            randomData.credulitySuspicion = (ushort)Random.Range(1, maxVal);
//            randomData.emotionalInstabilityStability = (ushort)Random.Range(1, maxVal);
//            randomData.intelligence = (ushort)Random.Range(1, maxVal);
//            randomData.normativityOfBehaviour = (ushort)Random.Range(1, maxVal);
//            randomData.practicalityDreaminess = (ushort)Random.Range(1, maxVal);
//            randomData.relaxationTension = (ushort)Random.Range(1, maxVal);
//            randomData.restraintExpressiveness = (ushort)Random.Range(1, maxVal);
//            randomData.rigiditySensetivity = (ushort)Random.Range(1, maxVal);
//            randomData.selfcontrol = (ushort)Random.Range(1, maxVal);
//            randomData.straightforwardnessDiplomacy = (ushort)Random.Range(1, maxVal);
//            randomData.subordinationDomination = (ushort)Random.Range(1, maxVal);
//            randomData.timidityCourage = (ushort)Random.Range(1, maxVal);
//            //agent.CharacterSystem.Initiate(randomData);
//        }

//        private void ResetAgent(PupilAgent agentToReset, PupilAgent secondAgent, PupilRawData agentManualData, SettingsType agentSettingsType, SettingsType relationsSettingsType, bool log = false)
//        {
//            agentToReset.CharacterSystem.RemoveTraits();
//            agentToReset.RelationsSystem.RemoveRelations();
//            //if (agentSettingsType == SettingsType.ManualSettings)
//            //    agentToReset.CharacterSystem.Initiate(agentManualData);
//            //else
//            //    CreateRandomCharacterTraits(agentToReset);
//            if (log)
//                Debug.Log(agentToReset.CharacterSystem.ToString());
//            if (relationsSettingsType == SettingsType.ManualSettings)
//                CreateNewRelations(agentsManuallyRelations, agentToReset, secondAgent);
//            else
//                CreateNewRelations((Relationships)Random.Range(0, (int)Relationships.Enemy + 1), agentToReset, secondAgent);
//            //agentToReset.ClearEmotions();
//            //var relations = agentToReset.RelationsSystem.GetCurrentRelationTo<SchoolAgentBase, FeatureBase>(secondAgent);
//            //if (log)
//            //    Debug.Log(relations.ToString() + "\n");
//        }

//        private void ResetAgentGlobalEvent(PupilAgent trainedAgent, SettingsType eventSettingsType, bool logEvent = false)
//        {
//            if (eventSettingsType != SettingsType.ManualSettings)
//                currentEvent = globalEvents[Random.Range(0, globalEvents.Count)];
//            else if (currentEvent == null)
//                currentEvent = globalEvents[Random.Range(0, globalEvents.Count)];
//            if (logEvent)
//                Debug.Log(currentEvent.ToString());
//        }

//        private void Update()
//        {
//            //if (parameters.BehaviorType == BehaviorType.HeuristicOnly)
//            //{
//            //    var input = GetInputValue();
//            //    if (Mathf.Abs(input) != 2)
//            //    {
//            //        trainedAgentAttentionComponent.HeuristicInputValue = input;
//            //        Debug.Log($"Input {input} from configurator");
//            //        trainedAgentAttentionComponent.RequestDecision();
//            //    }
//            //}
//        }
//        private void FixedUpdate()
//        {
//            //if (parameters.BehaviorType != BehaviorType.HeuristicOnly)
//            //{
//            //    trainedAgentAttentionComponent.RequestDecision();
//            //}
//        }
//        protected static float GetInputValue()
//        {
//            float inputValue = 2;
//            var pads = new List<KeyCode>() {
//                KeyCode.Keypad0,
//                KeyCode.Keypad1,
//                KeyCode.Keypad2,
//                KeyCode.Keypad3,
//                KeyCode.Keypad4,
//                KeyCode.Keypad5,
//                KeyCode.Keypad6,
//                KeyCode.Keypad7,
//                KeyCode.Keypad8,
//                KeyCode.Keypad9,
//                KeyCode.KeypadMultiply
//            };
//            for (int p = 0; p < pads.Count; p++)
//            {
//                if (Input.GetKeyDown(pads[p]))
//                {
//                    if (Input.GetKey(KeyCode.LeftControl))
//                        inputValue = -p / 10f;
//                    else
//                        inputValue = p / 10f;
//                    if (p == 0)
//                        inputValue = p;
//                }
//            }
//            return inputValue;
//        }

//        public override GlobalEvent CurrentGlobalEvent => currentEvent;


//        public void OnEpisodeBegin()
//        {
//            //ресетим тренируемого
//            ResetAgent(trainedAgent, trainSourceAgent, trainAgentInitData, trainedAgentSettingsType, agentsRelationsSettingsType, logAgent);
//            //ресетим второго
//            ResetAgent(trainSourceAgent, trainedAgent, trainSourceAgentInitData, trainSourceAgentSettingsType, SettingsType.RandomSettings,logTrainSourceAgent);
//            //ресетим событие
//            ResetAgentGlobalEvent(trainedAgent, eventSettingsType,logEvent);
//            //requestDecision = true;
//        }
//    }
//}