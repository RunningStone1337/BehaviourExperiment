//using System.Collections.Generic;
//using Training;
//using Unity.MLAgents;
//using Unity.MLAgents.Actuators;
//using Unity.MLAgents.Sensors;
//using UnityEngine;

//namespace BehaviourModel
//{
//    //[RequireComponent(typeof(SchoolAgentBase))]
//    public abstract class AttentionComponent : Agent
//    {
//        [SerializeField] protected TrainingConfigurator config;
//        [SerializeField] [Range(0f, 1f)] protected float neutralReactAbsEnd = 0.15f;
//        [SerializeField] [Range(0, 1f)] protected float weakReactAbsEnd = 0.33f;
//        [SerializeField] [Range(0, 1f)] protected float midReactAbsEnd = 0.66f;
//        //[SerializeField] protected SchoolAgentBase thisAgent;
//        protected int NUM_EVENTS_TYPES = 3;
//        protected int NUM_RELATIONS_TYPES = 7;
//        protected int NUM_TRAITS_TYPES = 3;
//        private float heuristicInputValue;
//        public float HeuristicInputValue{ set => heuristicInputValue = value; }


//        /// <summary>
//        /// Наблюдения, относящиеся к конкретному типу наблюдаемого объекта.
//        /// </summary>
//        /// <param name="sensor"></param>
//        protected abstract void AddPhenomenonObservations(VectorSensor sensor);

//        /// <summary>
//        /// Обработка награды за последнее принятое действие.
//        /// </summary>
//        protected abstract void HandleLastActionRewarding();

//        /// <summary>
//        /// Выполняет отрицательное действие. Чем ниже значение, тем интенсивнее реакция.
//        /// </summary>
//        /// <param name="negativeVal"></param>
//        protected abstract void HandleNegativeReactions(float negativeVal);

//        /// <summary>
//        /// Выполняет положительное действие. Чем выше значение, тем интенсивнее реакция.
//        /// </summary>
//        /// <param name="positiveVal"></param>
//        protected abstract void HandlePositiveReactions(float positiveVal);

//        /// <summary>
//        /// Выполняет нейтральное действие
//        /// </summary>
//        /// <param name="neutralVal"></param>
//        protected abstract void HandleUndefinedReactions(float neutralVal);

//        /// <summary>
//        /// Факторы оценки значимости:
//        /// собственный характер
//        /// абстрактно значимые явления:
//        /// -знание о текущей обстановке
//        /// </summary>
//        /// <param name="sensor"></param>
//        public override void CollectObservations(VectorSensor sensor)
//        {
//            //характер агента
//            //(1+3)*16=64х
//            //var cs = thisAgent.CharacterSystem;
//            //foreach (var ct in cs)
//            //{
//            //    sensor.AddObservation(ct.RawCharacterValue / 10f);
//            //    sensor.AddOneHotObservation((int)ct.CharacterGrade, NUM_TRAITS_TYPES);
//            //}

//            //текущее событие
//            //var currenEvent = thisAgent.CurrentEvent;
//            //3х
//            //sensor.AddOneHotObservation((int)currenEvent.EventType, NUM_EVENTS_TYPES);
//            //явление, на которое реагируем - Nх, зависит от конкретного явления
//            AddPhenomenonObservations(sensor);
//        }

//        public override void Heuristic(in ActionBuffers actionsOut)
//        {
//            var act = actionsOut.ContinuousActions;
//            act[0] = heuristicInputValue;
//        }

//        /// <summary>
//        /// Варианты реакций:
//        /// Положительная/отрицательная/нейтральная
//        /// </summary>
//        /// <param name="actions"></param>
//        public override void OnActionReceived(ActionBuffers actions)
//        {
//            var acts = actions.ContinuousActions;
//            if (acts[0] >= -neutralReactAbsEnd && acts[0] <= neutralReactAbsEnd)//неопределённая реакция
//                HandleUndefinedReactions(acts[0]);
//            else if (acts[0] > neutralReactAbsEnd)//положительная реакция
//                HandlePositiveReactions(acts[0]);
//            else//отрицательная реакция
//                HandleNegativeReactions(acts[0]);

//            //оценить правильность действий
//            HandleLastActionRewarding();
//            EndEpisode();
//        }
//    }
//}