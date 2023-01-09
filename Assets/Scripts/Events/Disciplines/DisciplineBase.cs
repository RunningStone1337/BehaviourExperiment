using UnityEngine;

namespace Events
{
    public abstract class DisciplineBase : ScriptableObject
    {
        [SerializeField] private string disciplineName;
        public string DisciplineName { get => disciplineName; }
    }
}