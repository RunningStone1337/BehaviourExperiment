using BehaviourModel;
using Common;
using System;
using System.Collections.Generic;
using IState = Common.IState;

namespace Extensions
{
    public static partial class ListExtensions
    {
        public static List<EmotionBase> ToEmotions(this List<Emotions> enums, IEmotionSource reason)
        {
            List<EmotionBase> res = new List<EmotionBase>();
            foreach (var en in enums)
            {
                switch (en)
                {
                    case Emotions.Annoyance:
                        res.Add(new AnnoyanceAngerEmotion(reason));
                        break;
                    case Emotions.Anger:
                        res.Add(new AngerAngerEmotion(reason));
                        break;
                    case Emotions.Rage:
                        res.Add(new RageAngerEmotion(reason));
                        break;
                    case Emotions.Approval:
                        res.Add(new ApprovalApprovalEmotion(reason));
                        break;
                    case Emotions.Acceptance:
                        res.Add(new AcceptanceApprovalEmotion(reason));
                        break;
                    case Emotions.Adoration:
                        res.Add(new AdorationApprovalEmotion(reason));
                        break;
                    case Emotions.Abstractness:
                        res.Add(new AbstractnessAmazementEmotion(reason));
                        break;
                    case Emotions.Surprise:
                        res.Add(new SurpriseAmazementEmotion(reason));
                        break;
                    case Emotions.Amazement:
                        res.Add(new AmazementAmazementEmotion(reason));
                        break;
                    case Emotions.Disapproval:
                        res.Add(new DisapprovalDisgustEmotion(reason));
                        break;
                    case Emotions.Dislike:
                        res.Add(new DislikeDisgustEmotion(reason));
                        break;
                    case Emotions.Disgust:
                        res.Add(new DisgustDisgustEmotion(reason));
                        break;
                    case Emotions.Caution:
                        res.Add(new CautionHorrorEmotion(reason));
                        break;
                    case Emotions.Fear:
                        res.Add(new FearHorrorEmotion(reason));
                        break;
                    case Emotions.Horror:
                        res.Add(new HorrorHorrorEmotion(reason));
                        break;
                    case Emotions.Serenity:
                        res.Add(new SerenityHappinessEmotion(reason));
                        break;
                    case Emotions.Happy:
                        res.Add(new HappyHappinessEmotion(reason));
                        break;
                    case Emotions.Eiphoria:
                        res.Add(new EiphoriaHappinessEmotion(reason));
                        break;
                    case Emotions.Interest:
                        res.Add(new InterestInterestEmotion(reason));
                        break;
                    case Emotions.Awaiting:
                        res.Add(new AwaitingInterestEmotion(reason));
                        break;
                    case Emotions.Anticipation:
                        res.Add(new AnticipationInterestEmotion(reason));
                        break;
                    case Emotions.Despondency:
                        res.Add(new DespondencySadEmotion(reason));
                        break;
                    case Emotions.Sad:
                        res.Add(new SadnessSadEmotion(reason));
                        break;
                    case Emotions.Misery:
                        res.Add(new MiserySadEmotion(reason));
                        break;
                    default:
                        break;
                }
            }
            return res;
        }
        public static void AddObjectIfMatch<T>(this List<T> list, T obj, Func<bool> func)
        {
            if (func.Invoke())
                list.Add(obj);
        }

       

        public static void SetStatesFromS1ToS2<T, S1, S2, StateTypeBase>(this List<T> places)
            where T : Common.ICurrentStateHandler<StateTypeBase>
            where S1 : StateTypeBase
            where S2 : StateTypeBase
            where StateTypeBase : IState
        {
            foreach (var p in places)
            {
                if (p.CurrentState is S1)
                    p.SetState<S2>();
            }
        }
        public static void AddIfNotContains<T>(this List<T> lst, T obj)
        {
            if (!lst.Contains(obj))
                lst.Add(obj);
        }
    }
}