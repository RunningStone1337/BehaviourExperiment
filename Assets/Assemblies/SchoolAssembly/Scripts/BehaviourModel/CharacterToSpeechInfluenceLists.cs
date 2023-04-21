using UnityEngine;

namespace BehaviourModel
{
    [CreateAssetMenu(menuName = "RelationshipTables/CharacterToSpeechInfluenceLists", fileName = "ToSpeechRelationsInfluenceLists")]
    public class CharacterToSpeechInfluenceLists : CharacterToPhenomContainerBase<TableListViewDimension<SpeechInfluenceWrapper>, SpeechInfluenceWrapper>
    {
    }
}