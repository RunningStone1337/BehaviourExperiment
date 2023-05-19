using UnityEngine;

namespace BehaviourModel
{
    [CreateAssetMenu(menuName = "RelationshipTables/CharacterToSpeechReactionsLists", fileName = "ToSpeechReactionsLists")]
    public class CharacterToSpeechReactionsLists : CharacterToPhenomContainerBase<TableListViewDimension<SpeechOptionsWrapper>, SpeechOptionsWrapper>
    {
    }
}