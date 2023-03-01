using Events;
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
            //если доступно - реализуем, иначе остаёмся в стейте выбора и пытаемся сделать что-то ещё
            yield return choosen.TryPerformAction();
        }

        /// <summary>
        /// Все доступные действия с учётом наблюдений
        /// </summary>
        /// <returns></returns>
        private List<(ReactionBase reaction, float prob)> GetProbablyActions()
        {
            var probReactions = new List<(ReactionBase reaction, float prob)>();

            //пройти по всем наблюдениям и создать потенциальные действия для них
            //foreach (var item in thisAgent.Brain.reac)
            //{

            //}
            var dimension = thisAgent.TablesHandler.CharacterToEventsReactionsTable[thisAgent.CurrentEvent.Name];
            foreach (var charTrait in thisAgent.CharacterSystem)
            {
                //абсолютной вероятностью для каждого действия является специализированное значение данной черты
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