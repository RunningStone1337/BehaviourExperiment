using UnityEngine;

namespace BehaviourModel
{
    public class PupilRelationsTableHandler : SchoolRelationsTableHandler
    {
        [SerializeField] private CharacterToPhenomReactionsLists characterToTeacherReactionsTable;
        public CharacterToPhenomReactionsLists CharacterToTeacherReactionsTable => characterToTeacherReactionsTable;
        [SerializeField] private CharacterToPhenomReactionsLists characterToInterierReactionsTable;
        public CharacterToPhenomReactionsLists CharacterToInterierReactionsTable => characterToInterierReactionsTable;
    }
}
