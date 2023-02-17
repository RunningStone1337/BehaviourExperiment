using BehaviourModel;
using UnityEngine;

namespace Events
{
    public abstract class DisciplineBase : ScriptableObject, IPhenomenon
    {
        [SerializeField] private string disciplineName;
        [SerializeField] float disciplinePower;
        public string DisciplineName { get => disciplineName; }
        public float PhenomenonPower { get => disciplinePower; set => disciplinePower = value; }
    }
}