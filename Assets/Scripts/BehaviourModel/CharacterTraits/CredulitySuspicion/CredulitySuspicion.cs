using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������������-����������������.
    /// ��� ������� �������� ����������: ����������, �����������, ����������, �������������;
    /// ������� �� �������, ������������. ����� ���� ������� ����������� ����������������.
    /// ��� �������� �������� ����������: ������������, ���������������, ��������������� �� ��������� � �����;
    /// ���������� � ��������, ���������� ��������� ��������������� �� ������ �� ����������,
    /// �����������������.������ ������������, ����������������� � ������������� � ���������� ���������.
    /// � ����� ������ �������� ������������� ��������� � �����.
    /// ����� ������� ������ �� ����� ������� ������� �� �������� ������ � ������������� �������������,
    /// ����������������� ��������. ������ ����� ������������� �������� �����������, �� �������� � �����������.
    /// </summary>
    public abstract class CredulitySuspicion : CharacterTraitBase, IComparable<CredulitySuspicion>
    {
        public static bool operator <(CredulitySuspicion c1, CredulitySuspicion c2) =>
           Char1LessChar2<LowSuspicion, MiddleSuspicion, HighSuspicion, CredulitySuspicion>(c1, c2);

        public static bool operator <=(CredulitySuspicion c1, CredulitySuspicion c2) =>
            Char1LessOrEqualChar2<LowSuspicion, MiddleSuspicion, HighSuspicion, CredulitySuspicion>(c1, c2);

        public static bool operator >(CredulitySuspicion c1, CredulitySuspicion c2) =>
                    Char1MoreChar2<LowSuspicion, MiddleSuspicion, HighSuspicion, CredulitySuspicion>(c1, c2);

        public static bool operator >=(CredulitySuspicion c1, CredulitySuspicion c2) =>
            Char1MoreOrEqualChar2<LowSuspicion, MiddleSuspicion, HighSuspicion, CredulitySuspicion>(c1, c2);
        protected override List<CharacterTraitBase> GetInterestedTraitsForCharacter(AgentBase agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase>() {
                cs.ClosenessSociability,
                cs.ConformismNonconformism,
                cs.ConservatismRadicalism,
                cs.CredulitySuspicion,
                cs.EmotionalInstabilityStability,
                cs.PracticalityDreaminess,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.Selfcontrol,
                cs.StraightforwardnessDiplomacy
            };
        }
        public int CompareTo(CredulitySuspicion other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}