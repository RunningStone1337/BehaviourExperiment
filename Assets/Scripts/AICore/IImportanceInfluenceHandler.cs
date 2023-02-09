namespace BehaviourModel
{
    /// <summary>
    /// Объект может иметь влияние на важность для определённого явления.
    /// </summary>
    public interface IImportanceInfluenceHandler<T> where T : IPhenomenon
    {
        /// <summary>
        /// Значение влияния на данное явление.
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        float GetImportanceValueFor(T phenomenon);
      
    }
}