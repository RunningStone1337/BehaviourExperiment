using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class SpeechInfluenceWrapper
    {
        [SerializeField, ValueDropdown("SpeechInfluenceFilter"), TableColumnWidth(100, resizable: true)]
        private string speechToReact;

        [SerializeField, TableColumnWidth(100, resizable: true)]
        private float probablyReactionInfluence;

        private static List<string> GetTypes(Type type)
        {
            var types = type.Assembly.GetTypes()
                            .Where(x => !x.IsAbstract)
                            .Where(x => !x.IsGenericTypeDefinition)
                            .Where(x => type.IsAssignableFrom(x));
            return types.Select(x => x.Name).ToList();
        }

        private List<string> SpeechInfluenceFilter()
        {
            var type = typeof(SpeakAction<PupilAgent, PupilAgent>);
            var res = GetTypes(type);
            res.AddRange(GetTypes(typeof(SpeakAction<PupilAgent, TeacherAgent>)));
            res.AddRange(GetTypes(typeof(SpeakAction<TeacherAgent, PupilAgent>)));
            return res;
        }

        public float ProbablyReactionInfluence => probablyReactionInfluence;
        public string SpeechToReact => speechToReact;
    }
}