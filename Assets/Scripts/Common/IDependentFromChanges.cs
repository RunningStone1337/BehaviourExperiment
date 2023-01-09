namespace Common
{
    /// <summary>
    /// Интерфейс, реализующий изменение состояния объекта при изменении определённых условий
    /// </summary>
    public interface IDependentFromChanges
    {
        /// <summary>
        /// Изменяет состояние объекта при изменениях
        /// </summary>
        /// <param name="param"></param>
        void ResetIfConditionsChanged(object param);
    }
}