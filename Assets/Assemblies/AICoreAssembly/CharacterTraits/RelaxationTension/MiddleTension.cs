namespace BehaviourModel
{
    /// <summary>
    /// —редн€€ напр€жЄнность
    /// </summary>
    public class MiddleTension : RelaxationTension
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidRelaxationTension;
        }
    }
}