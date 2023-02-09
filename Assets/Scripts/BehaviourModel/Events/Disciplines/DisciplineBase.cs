using BehaviourModel;
using UnityEngine;

namespace Events
{
    public abstract class DisciplineBase : ScriptableObject, IPhenomenon
    {
        [SerializeField] private string disciplineName;
        [SerializeField] int disciplinePower;
        public string DisciplineName { get => disciplineName; }
        public int PhenomenonPower { get => disciplinePower; set => disciplinePower = value; }
    }
}