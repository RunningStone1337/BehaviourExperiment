namespace BehaviourModel
{
    /// <summary>
    /// Расслабленность
    /// </summary>
    public class LowTension : RelaxationTension
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowRelaxationTension;
        }
    }
}