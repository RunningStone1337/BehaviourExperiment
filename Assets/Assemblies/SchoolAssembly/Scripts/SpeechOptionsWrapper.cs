using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class SpeechOptionsWrapper
    {
        [Serializable]
        public class ReactionWeightPairs
        {
            [SerializeField, ListDrawerSettings(AlwaysAddDefaultValue = true)]
            List<ReactionWeightPair> probReactions = new List<ReactionWeightPair>();
            public List<ReactionWeightPair> ProbReactions => probReactions;

            [Serializable]
            public class ReactionWeightPair
            {
                [SerializeField, ValueDropdown("SpeechActionsFilter")]
                string speechToAnswer;
                public string SpeechToAnswer => speechToAnswer;
                [SerializeField, PropertyRange(0, 100)]
                float reactionWeight;
                public float ReactionWeight => reactionWeight;
                List<string> SpeechActionsFilter()
                {
                    var type = typeof(IExpression);
                    var types = GetTypes(type);
                    //types.AddRange(GetTypes(typeof(SpeakAction<TeacherAgent, PupilAgent>)));
                    //types.AddRange(GetTypes(typeof(SpeakAction<PupilAgent, PupilAgent>)));
                    return types;
                }

                private static List<string> GetTypes(Type type)
                {
                    var types = type.Assembly.GetTypes()
                        .Where(x => !x.IsAbstract)
                        .Where(x => !x.IsGenericTypeDefinition)
                        .Where(x => type.IsAssignableFrom(x));
                    return types.Select(x => x.AssemblyQualifiedName).ToList();
                }

                public SpeakAction<TAgent, TCompanion> GetReaction<TAgent, TCompanion>(TAgent reactor, TCompanion reactSource)
                   where TAgent: SchoolAgentBase<TAgent>
                   where TCompanion : SchoolAgentBase<TCompanion>
                {
                    var type = Type.GetType(speechToAnswer);
                    var instance = (SpeakAction<TAgent, TCompanion>)Activator.CreateInstance(type);
                    instance.Initiate(reactSource, reactor);
                    return instance;
                }
            }
        }

        [SerializeField, ValueDropdown("SpeechActionsFilter"), TableColumnWidth(100, resizable: true)]
        string speechToReact;
        public string SpeechToReact => speechToReact;
        [SerializeField,  TableColumnWidth(100, resizable: true)]
        ReactionWeightPairs probablyReactions = new ReactionWeightPairs();
        public ReactionWeightPairs ProbablyReactions => probablyReactions;
        List<string> SpeechActionsFilter()
        {
            var type = typeof(IRequest);
            var types = type.Assembly.GetTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericTypeDefinition)
                .Where(x => type.IsAssignableFrom(x));
            return types.Select(x => x.Name).ToList();
        }
    }
}