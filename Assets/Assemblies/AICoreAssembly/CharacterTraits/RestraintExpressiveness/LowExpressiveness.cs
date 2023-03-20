namespace BehaviourModel
{
    /// <summary>
    /// Высокая сдержанность
    /// </summary>
    public class LowExpressiveness : RestraintExpressiveness
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowRestraintExpressiveness;
        }
    }
}