namespace BehaviourModel
{
    /// <summary>
    /// Явление - всё что может быть воспринято агентом как предмет интеллектальной деятельности.
    /// </summary>
    public interface IPhenomenon
    {
        /// <summary>
        /// Базовая сила явления - относительная величина, степень воздействия на восприятие
        /// </summary>
        int PhenomenonPower { get; set; }
    }
}