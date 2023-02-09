using UnityEngine;

namespace BehaviourModel
{
    public abstract class PhenomenonRelationTable : ScriptableObject
    {
        [SerializeField] private string tableDescription;
        public string TableDescription { get => tableDescription; set => tableDescription = value; }
    }
}