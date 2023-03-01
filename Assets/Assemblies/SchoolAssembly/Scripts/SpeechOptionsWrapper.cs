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
                int reactionWeight;
                public int ReactionWeight => reactionWeight;
                List<string> SpeechActionsFilter()
                {
                    var type = typeof(SpeakAction);
                    var types = type.Assembly.GetTypes()
                        .Where(x => !x.IsAbstract)
                        .Where(x => !x.IsGenericTypeDefinition)
                        .Where(x => type.IsAssignableFrom(x));
                    return types.Select(x => x.Name).ToList();
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
            var type = typeof(SpeakAction);
            var types = type.Assembly.GetTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericTypeDefinition)
                .Where(x => type.IsAssignableFrom(x));
            return types.Select(x => x.Name).ToList();
        }
    }
}