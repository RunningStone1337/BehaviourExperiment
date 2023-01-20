using Core;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Базовый класс склонностей к определённому поведению или деятельности.
    /// </summary>
    public abstract class TendentionBase : IPhenomenon
    {
        public int PhenomenonPower { get; set; }

    }
}