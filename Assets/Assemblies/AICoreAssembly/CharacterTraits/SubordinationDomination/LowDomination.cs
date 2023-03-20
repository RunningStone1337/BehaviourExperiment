namespace BehaviourModel
{
    /// <summary>
    /// Подчинённость
    /// </summary>
    public class LowDomination : SubordinationDomination
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowSubordinationDomination;
        }
    }
}