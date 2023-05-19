using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: склонность к непостоянству, подверженность влиянию чувств,
    /// случая и обстоятельств. Потворствует своим желаниям, не делает усилий по выполнению групповых
    /// требований и норм. Неорганизованность, безответственность, импульсивность, отсутствие согласия
    /// с общепринятыми моральными правилами и стандартами, гибкость по отношению к социальным нормам,
    /// свобода от их влияния, иногда беспринципность и склонность к асоциальному поведению.
    /// Для высокого значения характерно: добросовестность, ответственность, стабильность, уравновешенность,
    /// настойчивость, склонность к морализированию, разумность, совестливость.
    /// Развитое чувство долга и ответственности, осознанное соблюдение общепринятых моральных правил и норм,
    /// настойчивость в достижении цели, деловая направленность.
    /// </summary>
    public abstract class NormativityOfBehaviour : CharacterTraitBase,
        IComparable<NormativityOfBehaviour>, IRegulationalTrait
    {
        public static bool operator <(NormativityOfBehaviour c1,
            NormativityOfBehaviour c2) =>
         Char1LessChar2<LowNormativityOfBehaviour,
             MiddleNormativityOfBehaviour,
             HighNormativityOfBehaviour,
             NormativityOfBehaviour>(c1, c2);

        public static bool operator <=(NormativityOfBehaviour c1,
            NormativityOfBehaviour c2) =>
            Char1LessOrEqualChar2<LowNormativityOfBehaviour,
                MiddleNormativityOfBehaviour,
                HighNormativityOfBehaviour,
                NormativityOfBehaviour>(c1, c2);

        public static bool operator >(NormativityOfBehaviour c1,
            NormativityOfBehaviour c2) =>
            Char1MoreChar2<LowNormativityOfBehaviour,
                MiddleNormativityOfBehaviour,
                HighNormativityOfBehaviour,
                NormativityOfBehaviour>(c1, c2);

        public static bool operator >=(NormativityOfBehaviour c1,
            NormativityOfBehaviour c2) =>
            Char1MoreOrEqualChar2<LowNormativityOfBehaviour,
                MiddleNormativityOfBehaviour,
                HighNormativityOfBehaviour,
                NormativityOfBehaviour>(c1, c2);

        public int CompareTo(NormativityOfBehaviour other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisCharType = CharTraitType.NormativityOfBehaviour;
        }
       

        public override string ToString()
        {
            return $"Нормативность поведения: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}