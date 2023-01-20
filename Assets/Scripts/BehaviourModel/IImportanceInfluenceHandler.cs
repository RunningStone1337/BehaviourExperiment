namespace BehaviourModel
{
    /// <summary>
    /// Объект может иметь влияние на важность для определённого явления.
    /// </summary>
    public interface IImportanceInfluenceHandler 
    {
        /// <summary>
        /// Значение влияния на данное явление.
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        float GetImportanceValueFor<T>(T phenomenon) where T : IPhenomenon;

        /// <summary>
        /// Имеется ли влияние для данного объекта на данное явление?
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        bool HasImportanceFor<T>(T phenomenon) where T : IPhenomenon;
    }
}