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
        [SerializeField, TableColumnWidth(100, resizable: true)]
        private ReactionWeightPairs probablyReactions = new ReactionWeightPairs();

        [SerializeField, ValueDropdown("SpeechActionsFilter"), TableColumnWidth(100, resizable: true)]
        private string speechToReact;

        private List<string> SpeechActionsFilter()
        {
            var type = typeof(IRequest);
            var types = type.Assembly.GetTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericTypeDefinition)
                .Where(x => type.IsAssignableFrom(x));
            return types.Select(x => x.Name).ToList();
        }

        public ReactionWeightPairs ProbablyReactions => probablyReactions;

        public string SpeechToReact => speechToReact;

        [Serializable]
        public class ReactionWeightPairs
        {
            [SerializeField, ListDrawerSettings(AlwaysAddDefaultValue = true)]
            private List<ReactionWeightPair> probReactions = new List<ReactionWeightPair>();

            public List<ReactionWeightPair> ProbReactions => probReactions;

            [Serializable]
            public class ReactionWeightPair
            {
                [SerializeField, PropertyRange(0, 100)]
                private float reactionWeight;

                [SerializeField, ValueDropdown("SpeechActionsFilter")]
                private string speechToAnswer;

                private static List<string> GetTypes(Type type)
                {
                    var types = type.Assembly.GetTypes()
                        .Where(x => !x.IsAbstract)
                        .Where(x => !x.IsGenericTypeDefinition)
                        .Where(x => type.IsAssignableFrom(x));
                    return types.Select(x => x.AssemblyQualifiedName).ToList();
                }

                private List<string> SpeechActionsFilter()
                {
                    var type = typeof(IExpression);
                    var types = GetTypes(type);
                    return types;
                }

                public float ReactionWeight => reactionWeight;
                public string SpeechToAnswer => speechToAnswer;

                public SpeakAction<TAgent, TCompanion> GetReaction<TAgent, TCompanion>(TAgent reactor, TCompanion reactSource)
                   where TAgent : SchoolAgentBase<TAgent>
                   where TCompanion : SchoolAgentBase<TCompanion>
                {
                    var type = Type.GetType(speechToAnswer);
                    var instance = (SpeakAction<TAgent, TCompanion>)Activator.CreateInstance(type);
                    instance.Initiate(reactSource, reactor);
                    return instance;
                }
            }
        }
    }
}