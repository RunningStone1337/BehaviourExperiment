using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [CreateAssetMenu(menuName = "RelationshipTables/CharacterReactionsMatrix", fileName = "NewReactionsMatrix")]
    public class CharacterToPhenomReactionsMatrix : 
        CharacterToPhenomContainerBase<ReactionsMatrixViewDimension, ReactionsWrapper>
    {
    }
}
