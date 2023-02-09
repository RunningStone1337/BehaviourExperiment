using Core;
using Events;
using System;
using System.Collections.Generic;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Оценка важности человека для этого агента
    /// </summary>
    //public class HumanAttentionComponent : AttentionComponent
    //{
    //    #region fields

    //    [SerializeField] private CharacterToPhenomFloatRelationsTable charToEventsRelations;
    //    [SerializeField] private CharacterToPhenomFloatRelationsTable charToRelationshipsRelations;
    //    [SerializeField] [HideInInspector] private List<EmotionBase> middleNegativeEmotions;
    //    [SerializeField] [HideInInspector] private List<EmotionBase> middlePositiveEmotions;
    //    [SerializeField] [HideInInspector] private List<EmotionBase> neutralEmotions;
    //    [SerializeField] [HideInInspector] private List<EmotionBase> strongNegativeEmotions;
    //    [SerializeField] [HideInInspector] private List<EmotionBase> strongPositiveEmotions;
    //    [SerializeField] [HideInInspector] private List<EmotionBase> weakNegativeEmotions;
    //    [SerializeField] [HideInInspector] private List<EmotionBase> weakPositiveEmotions;
    //    [SerializeField] protected SchoolAgentBase agentToReact;

    //    public event Action<RewardCalculationsEventArgs> OnRevardCalculatedEvent;

    //    #endregion fields

    //    private static void AddReaction(ref int positiveReactions, ref int negativeReactions, ref int neutralReactions, float react)
    //    {
    //        if (react > 0)
    //            positiveReactions++;
    //        else if (react < 0)
    //            negativeReactions++;
    //        else
    //            neutralReactions++;
    //    }

    //    private void Awake()
    //    {
    //        InitEmotionsLists();
    //    }

    //    /// <summary>
    //    /// Подсчёт награды за принятое действие.
    //    /// Оцениваем по количеству оценок в каждой категории.
    //    /// Если реакция есть в перечне ожидаемых
    //    /// </summary>
    //    /// <param name="positiveReactions"></param>
    //    /// <param name="negativeReactions"></param>
    //    /// <param name="neutralReactions"></param>
    //    /// <param name="lastReaction"></param>
    //    /// <returns></returns>
    //    private float CalculateCumulativeReward(int positiveReactions, int negativeReactions, int neutralReactions, EmotionBase lastReaction)
    //    {
    //        float result = 0f;
    //        //оценивем по предполагаемой реакции:
    //        //ожидаем: чем лучше отношения, тем позитивнее реакция
    //        //ожидаем: в перерыв уровень внимания выше, чем на уроке
    //        //List<EmotionBase> meanEmotions = GetMeantEmotionsLists(positiveReactions, negativeReactions, neutralReactions);
    //        //if (meanEmotions.Contains(lastReaction))
    //        //    result += 1f;
    //        //else
    //        //    result -= 1f;
    //        return result;
    //    }

    //    private float CalculateCumulativeReward(EmotionBase lastReaction, GlobalEvent currenEvent, RelationshipBase<FeatureBase,SchoolAgentStateBase> relations)
    //    {
    //        float result = default;
    //        if (currenEvent is BreakEvent br)
    //        {
    //            //любые реакции не штрафуются
    //            result += GetRelationshipBreakReward(lastReaction, relations);
    //        }
    //        else if (currenEvent is LessonEvent les)
    //        {
    //            //яркие реакции штрафуются
    //            if (lastReaction.PhenomenonPower == EmotionBase.STRONG_EMOTION_POWER)
    //                result -= 0.5f;
    //            else if (lastReaction.PhenomenonPower == EmotionBase.MIDDLE_EMOTION_POWER)
    //                result -= 0.25f;
    //            //в зависимости от типа отношений поощряются
    //            //чем крепче отношения, тем позитивнее реакция
    //            result += GetRelationshipLessonReward(lastReaction, relations);
    //        }
    //        else
    //            throw new Exception();
    //        return result;
    //    }

    //    /// <summary>
    //    /// Смысл оценки:
    //    /// сравниваем разницу между положительными и отрицательными, чем больше разры, тем явнее
    //    /// смещение в одну из сторон
    //    /// </summary>
    //    /// <param name="positiveReactions"></param>
    //    /// <param name="negativeReactions"></param>
    //    /// <param name="neutralReactions"></param>
    //    /// <returns></returns>
    //    private List<EmotionBase> GetMeantEmotionsLists(int positiveReactions, int negativeReactions, int neutralReactions)
    //    {
    //        int count = Mathf.Abs(positiveReactions - negativeReactions);
    //        if (positiveReactions > negativeReactions && count > 3)
    //        {
    //            ///какой-то из положительных списков
    //            ///чем больше разница, тем ярче реакция.
    //            if (count < 7)//4-6
    //                return weakPositiveEmotions;
    //            else if (count < 11)//7-11
    //                return middlePositiveEmotions;
    //            else
    //                return strongPositiveEmotions;
    //        }
    //        else if (positiveReactions < negativeReactions && count > 3)
    //        {
    //            if (count < 7)//4-6
    //                return weakNegativeEmotions;
    //            else if (count < 11)//7-11
    //                return middleNegativeEmotions;
    //            else
    //                return strongNegativeEmotions;
    //        }
    //        else
    //            return neutralEmotions;
    //    }

    //    private float GetRelationshipBreakReward(EmotionBase lastReaction, RelationshipBase relations)
    //    {
    //        float result = default;
    //        switch (relations.RelationshipType)
    //        {
    //            case RelationshipType.PoorlyKnown:
    //                if (neutralEmotions.Contains(lastReaction))
    //                    result += 0.25f;
    //                else if (weakPositiveEmotions.Contains(lastReaction))
    //                    result += 0.5f;
    //                else if (weakNegativeEmotions.Contains(lastReaction))
    //                    result += 0.25f;
    //                break;

    //            case RelationshipType.Familiar:
    //                if (weakPositiveEmotions.Contains(lastReaction))
    //                    result += 0.75f;
    //                else if (neutralEmotions.Contains(lastReaction))
    //                    result += 1;
    //                else if (weakNegativeEmotions.Contains(lastReaction))
    //                    result += 0.5f;
    //                break;

    //            case RelationshipType.Fellow:
    //                if (weakPositiveEmotions.Contains(lastReaction))
    //                    result += 0.5f;
    //                else if (middlePositiveEmotions.Contains(lastReaction))
    //                    result += 0.1f;
    //                else if (strongPositiveEmotions.Contains(lastReaction))
    //                    result += 1.25f;
    //                break;

    //            case RelationshipType.Comrade:
    //                if (weakPositiveEmotions.Contains(lastReaction))
    //                    result += 1f;
    //                else if (middlePositiveEmotions.Contains(lastReaction))
    //                    result += 1.25f;
    //                else if (strongPositiveEmotions.Contains(lastReaction))
    //                    result += 1f;
    //                break;

    //            case RelationshipType.Friend:
    //                if (weakPositiveEmotions.Contains(lastReaction))
    //                    result += 2f;
    //                else if (middlePositiveEmotions.Contains(lastReaction))
    //                    result += 2.5f;
    //                else if (strongPositiveEmotions.Contains(lastReaction))
    //                    result += 2f;
    //                break;
    //            //чем хуже отношения, тем негативнее реакция
    //            case RelationshipType.Foe:
    //                if (neutralEmotions.Contains(lastReaction))
    //                    result += 1f;
    //                else if (weakNegativeEmotions.Contains(lastReaction))
    //                    result += 2f;
    //                else if (middleNegativeEmotions.Contains(lastReaction))
    //                    result += 3f;
    //                else if (strongNegativeEmotions.Contains(lastReaction))
    //                    result += 2f;
    //                break;

    //            case RelationshipType.Enemy:
    //                if (neutralEmotions.Contains(lastReaction))
    //                    result -= 1;
    //                else if (weakNegativeEmotions.Contains(lastReaction))
    //                    result += 1f;
    //                else if (middleNegativeEmotions.Contains(lastReaction))
    //                    result += 2f;
    //                else if (strongNegativeEmotions.Contains(lastReaction))
    //                    result += 3f;
    //                break;

    //            default:
    //                break;
    //        }

    //        return result;
    //    }

    //    private float GetRelationshipLessonReward(EmotionBase lastReaction, RelationshipBase relations)
    //    {
    //        float result = default;
    //        switch (relations.RelationshipType)
    //        {
    //            case RelationshipType.PoorlyKnown:
    //                if (neutralEmotions.Contains(lastReaction))
    //                    result += 1f;
    //                break;

    //            case RelationshipType.Familiar:
    //                if (weakPositiveEmotions.Contains(lastReaction))
    //                    result += 0.75f;
    //                else if (neutralEmotions.Contains(lastReaction))
    //                    result += 1;
    //                else if (weakNegativeEmotions.Contains(lastReaction))
    //                    result += 0.5f;
    //                break;

    //            case RelationshipType.Fellow:
    //                if (weakPositiveEmotions.Contains(lastReaction))
    //                    result += 0.25f;
    //                else if (middlePositiveEmotions.Contains(lastReaction))
    //                    result += 0.75f;
    //                else if (strongPositiveEmotions.Contains(lastReaction))
    //                    result += 1f;
    //                break;

    //            case RelationshipType.Comrade:
    //                if (weakPositiveEmotions.Contains(lastReaction))
    //                    result += 0.5f;
    //                else if (middlePositiveEmotions.Contains(lastReaction))
    //                    result += 1f;
    //                else if (strongPositiveEmotions.Contains(lastReaction))
    //                    result += 1.25f;
    //                break;

    //            case RelationshipType.Friend:
    //                if (weakPositiveEmotions.Contains(lastReaction))
    //                    result += 0.75f;
    //                else if (middlePositiveEmotions.Contains(lastReaction))
    //                    result += 1.25f;
    //                else if (strongPositiveEmotions.Contains(lastReaction))
    //                    result += 2f;
    //                break;
    //            //чем хуже отношения, тем негативнее реакция
    //            case RelationshipType.Foe:
    //                if (neutralEmotions.Contains(lastReaction))
    //                    result += 0.5f;
    //                else if (weakNegativeEmotions.Contains(lastReaction))
    //                    result += 1f;
    //                else if (middleNegativeEmotions.Contains(lastReaction))
    //                    result += 0.75f;
    //                break;

    //            case RelationshipType.Enemy:
    //                if (neutralEmotions.Contains(lastReaction))
    //                    result += 0.25f;
    //                else if (weakNegativeEmotions.Contains(lastReaction))
    //                    result += 0.75f;
    //                else if (middleNegativeEmotions.Contains(lastReaction))
    //                    result += 1.25f;
    //                else if (strongNegativeEmotions.Contains(lastReaction))
    //                    result += 1.75f;
    //                break;

    //            default:
    //                break;
    //        }

    //        return result;
    //    }

    //    private void HandleApproximateReactionTo(CharacterTraitBase<TReaction, TFeature, TState> charTrat, GlobalEvent ev, ref int positiveReactions, ref int negativeReactions, ref int neutralReactions)
    //    {
    //        var react = charTrat.GetApproximateAttentionFor(ev, charToEventsRelations);
    //        AddReaction(ref positiveReactions, ref negativeReactions, ref neutralReactions, react);
    //    }

    //    private void HandleApproximateReactionTo(CharacterTraitBase<TReaction, TFeature, TState> charTrat, RelationshipBase relations, ref int positiveReactions, ref int negativeReactions, ref int neutralReactions)
    //    {
    //        var react = charTrat.GetApproximateAttentionFor(relations, charToRelationshipsRelations);
    //        AddReaction(ref positiveReactions, ref negativeReactions, ref neutralReactions, react);
    //    }

    //    private void InitEmotionsLists()
    //    {
    //        weakNegativeEmotions = new List<EmotionBase>() {
    //                new CautionHorrorEmotion(agentToReact),
    //                new AbstractnessAmazementEmotion(AgentToReact),
    //                new DespondencySadEmotion(AgentToReact),
    //                new DisapprovalDisgustEmotion(AgentToReact),
    //                new AnnoyanceAngerEmotion(AgentToReact)
    //            };

    //        middleNegativeEmotions = new List<EmotionBase>() {
    //                 new FearHorrorEmotion(agentToReact),
    //            new SurpriseAmazementEmotion(AgentToReact),
    //            new SadnessSadEmotion(AgentToReact),
    //            new DislikeDisgustEmotion(AgentToReact),
    //            new AngerAngerEmotion(AgentToReact)
    //            };

    //        strongNegativeEmotions = new List<EmotionBase>() {
    //                new HorrorHorrorEmotion(agentToReact),
    //                new AmazementAmazementEmotion(AgentToReact),
    //                new MiserySadEmotion(AgentToReact),
    //                new DisgustDisgustEmotion(AgentToReact),
    //                new RageAngerEmotion(AgentToReact)
    //            };

    //        weakPositiveEmotions = new List<EmotionBase>() {
    //            new InterestInterestEmotion(AgentToReact),
    //            new SerenityHappinessEmotion(AgentToReact),
    //            new ApprovalApprovalEmotion(AgentToReact)
    //            };

    //        middlePositiveEmotions = new List<EmotionBase>() {
    //            new AwaitingInterestEmotion(AgentToReact),
    //            new HappyHappinessEmotion(AgentToReact),
    //            new AcceptanceApprovalEmotion(AgentToReact)
    //            };

    //        strongPositiveEmotions = new List<EmotionBase>() {
    //            new AnticipationInterestEmotion(AgentToReact),
    //            new EiphoriaHappinessEmotion(AgentToReact),
    //            new AdorationApprovalEmotion(AgentToReact)
    //            };

    //        neutralEmotions = new List<EmotionBase>() {
    //             new DespondencySadEmotion(AgentToReact),
    //             new SerenityHappinessEmotion(AgentToReact)
    //        };
    //    }

    //    private EmotionBase SelectEmotionFromListForInput(float inputValue, List<EmotionBase> emotions, float diapStart, float diapEnd)
    //    {
    //        if (diapStart > diapEnd)
    //            throw new System.IndexOutOfRangeException("End diap must be bigger than diap start");
    //        float absInput = Mathf.Abs(inputValue);
    //        float diap = diapEnd - diapStart;
    //        int index = 0;
    //        float step = diap / emotions.Count;
    //        float currentPos = diapStart + step;
    //        while (currentPos < absInput)
    //        {
    //            currentPos += step;
    //            index++;
    //        }
    //        return emotions[index];
    //    }

    //    /// <summary>
    //    /// В оценке человека принимают участие факторы:
    //    /// характер, существующие взаимоотношения
    //    /// </summary>
    //    /// <param name="sensor"></param>
    //    protected override void AddPhenomenonObservations(VectorSensor sensor)
    //    {
    //        //4*16=64
    //        var cs = agentToReact.CharacterSystem;
    //        foreach (var charTrat in cs)
    //        {
    //            sensor.AddObservation(charTrat.RawCharacterValue);
    //            sensor.AddOneHotObservation((int)charTrat.CharacterGrade, NUM_TRAITS_TYPES);
    //        }
    //        //7
    //        var relations = thisAgent.RelationsSystem.GetCurrentRelationTo(agentToReact);
    //        sensor.AddOneHotObservation((int)relations.RelationshipType, NUM_RELATIONS_TYPES);
    //    }

    //    /// <summary>
    //    /// Награда или штраф за последнее принятое решение.
    //    /// Определяется личными чертами и отношением между субъектами.
    //    /// </summary>
    //    protected override void HandleLastActionRewarding()
    //    {
    //        var cs = agentToReact.CharacterSystem;
    //        var tcs = thisAgent.CharacterSystem;

    //        var relations = thisAgent.RelationsSystem.GetCurrentRelationTo(agentToReact);
    //        //var currenEvent = thisAgent.CurrentEvent;
    //        var lastReaction = thisAgent.NervousSystem.LastEmotion;
    //        int positiveReactions = 0, negativeReactions = 0, neutralReactions = 0;
    //        //получаем приблизительные реакции
    //        //фокус в том, что можем только оценить по типу отклика (да/нет/нейтрально),
    //        //а веса для характера определяются автоматически
    //        foreach (var charTrait in tcs)
    //        {
    //            //оценкой влияния характера пусть занимается сетка
    //            //HandleApproximateReactionTo(charTrait, agentToReact, ref positiveReactions, ref negativeReactions, ref neutralReactions);
    //            HandleApproximateReactionTo(charTrait, relations, ref positiveReactions, ref negativeReactions, ref neutralReactions);
    //            //как реагирует характер на уделение внимания человеку с этим типом события
    //            //HandleApproximateReactionTo(charTrait, currenEvent, ref positiveReactions, ref negativeReactions, ref neutralReactions);
    //        }
    //        //сравниваем полученную реакцию с ожидаемой
    //        //float totalReward = CalculateCumulativeReward(lastReaction, currenEvent, relations);
    //        //float totalReward = CalculateCumulativeReward(positiveReactions, negativeReactions, neutralReactions, lastReaction);
    //        //OnRevardCalculatedEvent?.Invoke(new RewardCalculationsEventArgs() { LastReaction = lastReaction, Reward = totalReward, Relations = relations, Event = currenEvent });
    //        //SetReward(totalReward);
    //    }

    //    protected override void HandleNegativeReactions(float negativeVal)
    //    {
    //        List<EmotionBase> emotions;
    //        float diapStart, diapEnd;
    //        float abs = Mathf.Abs(negativeVal);
    //        if (abs <= weakReactAbsEnd)
    //        {
    //            emotions = weakNegativeEmotions;
    //            diapStart = neutralReactAbsEnd;
    //            diapEnd = weakReactAbsEnd;
    //        }
    //        else if (abs <= midReactAbsEnd)
    //        {
    //            emotions = middleNegativeEmotions;
    //            diapStart = weakReactAbsEnd;
    //            diapEnd = midReactAbsEnd;
    //        }
    //        else
    //        {
    //            emotions = strongNegativeEmotions;
    //            diapStart = midReactAbsEnd;
    //            diapEnd = 1f;
    //        }
    //        thisAgent.AddEmotion(SelectEmotionFromListForInput(abs, emotions, diapStart, diapEnd));
    //    }

    //    protected override void HandlePositiveReactions(float positiveVal)
    //    {
    //        List<EmotionBase> emotions;
    //        float diapStart, diapEnd;
    //        if (positiveVal <= weakReactAbsEnd)
    //        {
    //            emotions = weakPositiveEmotions;
    //            diapStart = neutralReactAbsEnd;
    //            diapEnd = weakReactAbsEnd;
    //        }
    //        else if (positiveVal <= midReactAbsEnd)
    //        {
    //            emotions = middlePositiveEmotions;
    //            diapStart = weakReactAbsEnd;
    //            diapEnd = midReactAbsEnd;
    //        }
    //        else
    //        {
    //            emotions = strongPositiveEmotions;
    //            diapStart = midReactAbsEnd;
    //            diapEnd = 1f;
    //        }
    //        thisAgent.AddEmotion(SelectEmotionFromListForInput(positiveVal, emotions, diapStart, diapEnd));
    //    }

    //    protected override void HandleUndefinedReactions(float neutralVal)
    //    {
    //        if (neutralVal < 0)
    //            thisAgent.AddEmotion(neutralEmotions[0]);
    //        else
    //            thisAgent.AddEmotion(neutralEmotions[1]);
    //    }

    //    public SchoolAgentBase AgentToReact { get => agentToReact; set => agentToReact = value; }

    //    public override void OnEpisodeBegin()
    //    {
    //        config.OnEpisodeBegin();
    //    }
    //}
}