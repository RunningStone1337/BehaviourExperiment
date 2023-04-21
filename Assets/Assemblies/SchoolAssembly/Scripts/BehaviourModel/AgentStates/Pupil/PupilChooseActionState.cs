using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilChooseActionState : ChooseActionState<PupilAgent>
    {
        public PupilChooseActionState():base()
        {

        }
        public override IEnumerator StartState()
        {
            var probReactions = GetProbablyActions();
            //выбираем случайную
            var choosen = probReactions.SelectRandom().Key;
            choosen.Initiate(thisAgent.CurrentEvent, thisAgent);
            //если доступно - реализуем, иначе остаЄмс€ в стейте выбора и пытаемс€ сделать что-то ещЄ
            yield return choosen.TryPerformAction();
        }

        /// <summary>
        /// ¬се доступные действи€ с учЄтом наблюдений
        /// </summary>
        /// <returns></returns>
        private List<(ReactionBase reaction, float prob)> GetProbablyActions()
        {
            var probReactions = new List<(ReactionBase reaction, float prob)>();

            var dimension = thisAgent.TablesHandler.CharacterToEventsReactionsTable[thisAgent.CurrentEvent.Name];
            foreach (var charTrait in thisAgent.CharacterSystem)
            {
                //абсолютной веро€тностью дл€ каждого действи€ €вл€етс€ специализированное значение данной черты
                var absSpecialValue = Mathf.Abs(charTrait.SpecializedCharacterValue);
                var cell = dimension[charTrait.ThisConcreteCharType][0];
                foreach (var react in cell.GetReactions())
                {
                    probReactions.Add((react, absSpecialValue));
                }
            }

            return probReactions;
        }
    }
}