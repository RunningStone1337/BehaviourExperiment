using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Репрезентация нервной системы человека.
    /// Нижний уровень обработки поступающей информации, формирующий тенденцию отклика на ситуации и
    /// создающий новые импульсы, являющися основой для действий.
    /// Уровень органических предпосылок личности.
    /// </summary>
    public class NervousSystem : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private int activity;
        [SerializeField] [Range(1f, 10f)] private float actReactRelation;
        [SerializeField] private int[] nervousBalance;
        [SerializeField] [Range(1, 10)] private int nervousMobility;
        [SerializeField] [Range(1, 10)] private int nervousPower;
        [SerializeField] [Range(1, 10)] private int reactivity;
        ///добавить текущий уровень возбуждения НС
        ///разделение неуравновшенности на тормозную и возбудимую

        /// <summary>
        /// Степень активности воздействия на мир и целеустремлённость.
        /// </summary>
        public int Activity { get => activity; set => activity = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Отношение активности к реактивности, определяет мотивы действий - зависимость от внешних сили или внутренних побуждений.
        /// При == 1 вероятность 0.5, выше 1 - высокая активность, ниже 1 - высокая реактивность.
        /// </summary>
        public float ActReactRelation { get => actReactRelation; set => actReactRelation = activity / reactivity; }

        /// <summary>
        /// Уравновешенность НС — свойство нервной системы, выражающее соотношение между возбуждением
        /// и торможением, баланс этих процессов. Является самостоятельным свойством нервной системы,
        /// образующее в сочетании с другими (с силой и подвижностью) определенный тип высшей нервной деятельности.
        /// </summary>
        public int[] NervousBalance { get => nervousBalance; set => nervousBalance = value; }

        /// <summary>
        /// Подвижность НС - свойство нервной системы, состоящее в способности быстро реагировать на изменения в окружающей среде,
        /// способности переключаться с возбудительного процесса на тормозный и наоборот.
        /// </summary>
        public int NervousMobility { get => nervousMobility; set => nervousMobility = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Сила НС - свойство нервной системы, отражающее предел работоспособности клеток коры головного мозга,
        /// т.е. их способность выдерживать, не переходя в тормозное состояние (торможение),
        /// либо очень сильное, либо длительно действующее (хотя и не сильное) возбуждение.
        /// Cила нервной системы связана также с чувствительностью анализаторов:
        /// более слабая нервная система является и более чувствительной, т.е.
        /// она способна реагировать на стимулы более низкой интенсивности, чем сильная.
        /// </summary>
        public int NervousPower { get => nervousPower; set => nervousPower = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Степень непроизвольности реакций на внешние и внутренние импульсы.
        /// </summary>
        public int Reactivity { get => reactivity; set => reactivity = Mathf.Clamp(value, 1, 10); }
    }
}