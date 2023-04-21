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
            //�������� ���������
            var choosen = probReactions.SelectRandom().Key;
            choosen.Initiate(thisAgent.CurrentEvent, thisAgent);
            //���� �������� - ���������, ����� ������� � ������ ������ � �������� ������� ���-�� ���
            yield return choosen.TryPerformAction();
        }

        /// <summary>
        /// ��� ��������� �������� � ������ ����������
        /// </summary>
        /// <returns></returns>
        private List<(ReactionBase reaction, float prob)> GetProbablyActions()
        {
            var probReactions = new List<(ReactionBase reaction, float prob)>();

            var dimension = thisAgent.TablesHandler.CharacterToEventsReactionsTable[thisAgent.CurrentEvent.Name];
            foreach (var charTrait in thisAgent.CharacterSystem)
            {
                //���������� ������������ ��� ������� �������� �������� ������������������ �������� ������ �����
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