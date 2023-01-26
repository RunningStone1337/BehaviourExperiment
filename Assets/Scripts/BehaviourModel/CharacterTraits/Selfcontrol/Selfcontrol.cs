using System;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// ƒл€ низкого значени€ характерно: низка€ дисциплинированность, следует своим желани€м,
    /// зависимость от настроений, неумение контролировать свои эмоции и поведение.
    /// ƒл€ высокого значени€ характерно: целенаправленность, сильна€ вол€, умение контролировать свои эмоции и поведение.
    /// Ќизкие оценки по этому фактору указывают на слабую волю и плохой самоконтроль.
    /// ƒе€тельность таких людей неупор€дочена и импульсивна.Ћичность с высокими оценками по этому фактору
    /// имеет социально одобр€емые характеристики: самоконтроль, настойчивость, сознательность, склонность
    /// к соблюдению этикета. ƒл€ того, чтобы соответствовать таким стандартам, от личности требуетс€ приложение
    /// определенных усилий, наличие четких принципов, убеждений и учет общественного мнени€.
    /// Ётот фактор измер€ет уровень внутреннего контрол€ поведени€, интегрированность личности.
    /// </summary>
    public abstract class Selfcontrol : CharacterTraitBase, IComparable<Selfcontrol>
    {
        [SerializeField] [Range(0f, 1f)] protected float recognitionChance;

        /// <summary>
        /// Ўанс скрыть что-либо. Ќапр€мую зависит от значени€ самоконтрол€.
        /// </summary>
        public float RecognitionChance { get; }

        public static bool operator <(Selfcontrol c1, Selfcontrol c2) =>
                          Char1LessChar2<LowSelfcontrol, MiddleSelfcontrol, HighSelfcontrol, Selfcontrol>(c1, c2);

        public static bool operator <=(Selfcontrol c1, Selfcontrol c2) =>
            Char1LessOrEqualChar2<LowSelfcontrol, MiddleSelfcontrol, HighSelfcontrol, Selfcontrol>(c1, c2);

        public static bool operator >(Selfcontrol c1, Selfcontrol c2) =>
            Char1MoreChar2<LowSelfcontrol, MiddleSelfcontrol, HighSelfcontrol, Selfcontrol>(c1, c2);

        public static bool operator >=(Selfcontrol c1, Selfcontrol c2) =>
            Char1MoreOrEqualChar2<LowSelfcontrol, MiddleSelfcontrol, HighSelfcontrol, Selfcontrol>(c1, c2);

        public int CompareTo(Selfcontrol other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}