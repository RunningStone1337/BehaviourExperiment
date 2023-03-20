using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: низкая дисциплинированность, следует своим желаниям,
    /// зависимость от настроений, неумение контролировать свои эмоции и поведение.
    /// Для высокого значения характерно: целенаправленность, сильная воля, умение контролировать свои эмоции и поведение.
    /// Низкие оценки по этому фактору указывают на слабую волю и плохой самоконтроль.
    /// Деятельность таких людей неупорядочена и импульсивна.Личность с высокими оценками по этому фактору
    /// имеет социально одобряемые характеристики: самоконтроль, настойчивость, сознательность, склонность
    /// к соблюдению этикета. Для того, чтобы соответствовать таким стандартам, от личности требуется приложение
    /// определенных усилий, наличие четких принципов, убеждений и учет общественного мнения.
    /// Этот фактор измеряет уровень внутреннего контроля поведения, интегрированность личности.
    /// </summary>
    public abstract class Selfcontrol : CharacterTraitBase,
        IComparable<Selfcontrol>
    {
        public static bool operator <(Selfcontrol c1,
                    Selfcontrol c2) =>
         Char1LessChar2<LowSelfcontrol,
             MiddleSelfcontrol,
             HighSelfcontrol,
             Selfcontrol>(c1, c2);

        public static bool operator <=(Selfcontrol c1,
            Selfcontrol c2) =>
            Char1LessOrEqualChar2<LowSelfcontrol,
                MiddleSelfcontrol,
                HighSelfcontrol,
                Selfcontrol>(c1, c2);

        public static bool operator >(Selfcontrol c1,
            Selfcontrol c2) =>
            Char1MoreChar2<LowSelfcontrol,
                MiddleSelfcontrol,
                HighSelfcontrol,
                Selfcontrol>(c1, c2);

        public static bool operator >=(Selfcontrol c1,
            Selfcontrol c2) =>
            Char1MoreOrEqualChar2<LowSelfcontrol,
                MiddleSelfcontrol,
                HighSelfcontrol,
                Selfcontrol>(c1, c2);

        public int CompareTo(Selfcontrol other)
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
            ThisCharType = CharTraitType.Selfcontrol;
        }
      

        public override string ToString()
        {
            return $"Самоконтроль: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}