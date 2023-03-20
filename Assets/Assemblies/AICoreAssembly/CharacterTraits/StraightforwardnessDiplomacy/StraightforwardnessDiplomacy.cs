using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: откровенность, простота, наивность, прямолинейность,
    /// бестактность, естественность, непосредственность, эмоциональность, недисциплинированность,
    /// неумение анализировать мотивы партнера, отсутствие проницательности, простота вкусов, довольствие имеющимся.
    /// Для высокого значения характерно: изысканность, умение вести себя в обществе, в общении дипломатичность,
    /// эмоциональная выдержанность, проницательность, осторожность, хитрость, эстетическая изощренность,
    /// иногда ненадежность, умение находить выход из сложных ситуаций, расчетливость.
    /// Фактор ориентирован на измерение отношений личности к людям и окружающей действительности.
    /// Пока этот фактор недостаточно исследован.Однако можно говорить о том, что фактор характеризует
    /// некоторую форму тактического мастерства личности(фактор положительно коррелирует с умственными
    /// способностями и доминантностью и с определенной неуверенностью личности в себе).
    /// Высокие оценки по этому фактору характеризуют дипломатов в противоположность «естественному и прямолинейному»
    /// человеку с наивной эмоциональной искренностью, прямотой и непринужденностью.
    /// Существуют данные о том, что люди с низкими оценками по этому фактору вызывают
    /// больше доверия и симпатии, особенно у детей. Людей с высокими оценками можно охарактеризовать
    /// как интеллектуальных, независимых, со сложной натурой. В субкультурных исследованиях была выявлена связь
    /// высоких показателей по этому фактору со способностью к выживанию и определенной изощренностью.
    /// По динамическим характеристикам люди с высокими показателями являются лидерами в аналитической,
    /// целенаправленной дискуссии и в формировании функциональных групповых решений
    /// (у театральных режиссеров, кинорежиссеров, дипломатов как правило высокие оценки по этому фактору).
    /// </summary>
    public abstract class StraightforwardnessDiplomacy : CharacterTraitBase,
        IComparable<StraightforwardnessDiplomacy>
    {
        public static bool operator <(StraightforwardnessDiplomacy c1,
            StraightforwardnessDiplomacy c2) =>
         Char1LessChar2<LowDiplomacy,
             MiddleDiplomacy,
             HighDiplomacy,
             StraightforwardnessDiplomacy>(c1, c2);

        public static bool operator <=(StraightforwardnessDiplomacy c1,
            StraightforwardnessDiplomacy c2) =>
            Char1LessOrEqualChar2<LowDiplomacy,
                MiddleDiplomacy,
                HighDiplomacy,
                StraightforwardnessDiplomacy>(c1, c2);

        public static bool operator >(StraightforwardnessDiplomacy c1,
            StraightforwardnessDiplomacy c2) =>
            Char1MoreChar2<LowDiplomacy,
                MiddleDiplomacy,
                HighDiplomacy,
                StraightforwardnessDiplomacy>(c1, c2);

        public static bool operator >=(StraightforwardnessDiplomacy c1,
            StraightforwardnessDiplomacy c2) =>
            Char1MoreOrEqualChar2<LowDiplomacy,
                MiddleDiplomacy,
                HighDiplomacy,
                StraightforwardnessDiplomacy>(c1, c2);

        public int CompareTo(StraightforwardnessDiplomacy other)
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
            ThisCharType = CharTraitType.StraightforwardnessDiplomacy;
        }      

        public override string ToString()
        {
            return $"Прямол.-дипломат.: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}