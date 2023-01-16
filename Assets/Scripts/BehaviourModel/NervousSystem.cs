using System;
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
        [SerializeField] [Range(1, 10)] private int reactivity;
        [SerializeField] [Range(1, 10)] private int nervousMobility;
        [SerializeField] [Range(1, 10)] private int nervousPower;
        [SerializeField] [Range(1, 10)] private int currentExcitement;
        [SerializeField] NervousBalanceType nervousBalance;

        /// <summary>
        /// Степень активности воздействия на мир и целеустремлённость.
        /// </summary>
        public int Activity { get => activity; private set => activity = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Отношение активности к реактивности, определяет мотивы действий - зависимость от внешних сили или внутренних побуждений.
        /// При == 1 вероятность 0.5, выше 1 - высокая активность, ниже 1 - высокая реактивность.
        /// </summary>
        public float ActReactRelation { get => ((float)activity) / reactivity; }

        /// <summary>
        /// Уравновешенность НС — свойство нервной системы, выражающее соотношение между возбуждением
        /// и торможением, баланс этих процессов. Является самостоятельным свойством нервной системы,
        /// образующее в сочетании с другими (с силой и подвижностью) определенный тип высшей нервной деятельности.
        /// </summary>
        public NervousBalanceType NervousBalance { get => nervousBalance; private set => nervousBalance = value; }

        /// <summary>
        /// Подвижность НС - свойство нервной системы, состоящее в способности быстро реагировать на изменения в окружающей среде,
        /// способности переключаться с возбудительного процесса на тормозный и наоборот.
        /// </summary>
        public int NervousMobility { get => nervousMobility; private set => nervousMobility = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Сила НС - свойство нервной системы, отражающее предел работоспособности клеток коры головного мозга,
        /// т.е. их способность выдерживать, не переходя в тормозное состояние (торможение),
        /// либо очень сильное, либо длительно действующее (хотя и не сильное) возбуждение.
        /// Cила нервной системы связана также с чувствительностью анализаторов:
        /// более слабая нервная система является и более чувствительной, т.е.
        /// она способна реагировать на стимулы более низкой интенсивности, чем сильная.
        /// </summary>
        public int NervousPower { get => nervousPower; private set => nervousPower = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Степень непроизвольности реакций на внешние и внутренние импульсы.
        /// </summary>
        public int Reactivity { get => reactivity; private set => reactivity = Mathf.Clamp(value, 1, 10); }

        public void Initiate(HumanRawData data)
        {
            Activity = data.NsActivity;
            NervousBalance = data.NsType;
            NervousMobility = data.NsMoveability;
            NervousPower = data.NsPower;
            Reactivity = data.NsReactivity;
        }
    }
}