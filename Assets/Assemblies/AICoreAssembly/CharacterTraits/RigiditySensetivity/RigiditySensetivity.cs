using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: несентиментальность, самоуверенность, суровость,
    /// рассудочность, гибкость в суждениях, практичность, иногда некоторая жесткость
    /// и черствость по отношению к окружающим, рациональность, логичность.
    /// Для высокого значения характерно: чувствительность, впечатлительность, богатство
    /// эмоциональных переживаний, склонность к романтизму, художественное восприятие мира,
    /// развитые эстетические интересы, артистичность, женственность, склонность к эмпатии, сочувствию,
    /// сопереживанию и пониманию других людей, утонченная эмоциональность.
    /// Этот фактор отражает различия в культурном уровне и эстетической восприимчивости личности.
    /// Интересен тот факт, что люди с низкими показателями по этому фактору меньше болеют, более агрессивны,
    /// чаще занимаются спортом, атлетичны.
    /// Характеристики этого фактора ближе к фактору второго порядка «низкая эмоциональность
    /// – высокая эмоциональность»; данный фактор является там главенствующим.
    /// Личность с высокими показателями по этому фактору характеризуется как физически и умственно утонченная,
    /// склонная к рефлексии, задумывающаяся над своими ошибками и путями избежания таковых.
    /// </summary>
    public abstract class RigiditySensetivity : CharacterTraitBase
        , IComparable<RigiditySensetivity>, IEmotionalTrait
    {
        public static bool operator <(RigiditySensetivity c1,
                    RigiditySensetivity c2) =>
         Char1LessChar2<LowSensetivity,
             MiddleSensetivity,
             HighSensetivity,
             RigiditySensetivity>(c1, c2);

        public static bool operator <=(RigiditySensetivity c1,
            RigiditySensetivity c2) =>
            Char1LessOrEqualChar2<LowSensetivity,
                MiddleSensetivity,
                HighSensetivity,
                RigiditySensetivity>(c1, c2);

        public static bool operator >(RigiditySensetivity c1,
            RigiditySensetivity c2) =>
            Char1MoreChar2<LowSensetivity,
                MiddleSensetivity,
                HighSensetivity,
                RigiditySensetivity>(c1, c2);

        public static bool operator >=(RigiditySensetivity c1,
            RigiditySensetivity c2) =>
            Char1MoreOrEqualChar2<LowSensetivity,
                MiddleSensetivity,
                HighSensetivity,
                RigiditySensetivity>(c1, c2);
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisCharType = CharTraitType.RigiditySensetivity;
        }
        public int CompareTo(RigiditySensetivity other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }

        

        public override string ToString()
        {
            return $"Жесткость-чувствительность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}