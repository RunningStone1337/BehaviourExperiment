using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public static class CharacterTraitBaseExtensions 
    {
        /// <summary>
        /// Значение важности <paramref name="agent"/> для черты характера
        /// при условии что агент не знаком с <paramref name="agent"/>.
        /// составляем впечатление о челике на основании только своих черт характера
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        //public static float CalculateImportanceForStranger(this CharacterTraitBase charTrait, PupilAgent agent) => charTrait.CharacterValue * agent.AttentionToNonFamiliarCoef;
    }
}
