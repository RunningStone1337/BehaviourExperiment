namespace BehaviourModel
{
    /// <summary>
    /// —редн€€ доминантность
    /// </summary>
    public class MiddleDomination : SubordinationDomination
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidSubordinationDomination;
        }
    }
}