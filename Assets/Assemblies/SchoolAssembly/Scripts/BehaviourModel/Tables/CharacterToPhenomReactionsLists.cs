using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [CreateAssetMenu(menuName = "RelationshipTables/CharacterReactionsLists", fileName = "NewReactionsLists")]
    public class CharacterToPhenomReactionsLists : CharacterToPhenomContainerBase<SimpleFoldoutListsViewDimension<ReactionsWrapper>, ReactionsWrapper>
    {
        
    }
}
