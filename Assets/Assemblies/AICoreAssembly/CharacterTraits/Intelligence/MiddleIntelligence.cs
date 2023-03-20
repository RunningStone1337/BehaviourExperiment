namespace BehaviourModel
{
    /// <summary>
    /// Средний интеллект
    /// </summary>
    public class MiddleIntelligence : Intelligence
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidIntelligence;
        }
    }
}