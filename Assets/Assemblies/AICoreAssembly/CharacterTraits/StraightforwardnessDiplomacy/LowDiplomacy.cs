namespace BehaviourModel
{
    /// <summary>
    /// Низкая дипломатичность
    /// </summary>
    public class LowDiplomacy : StraightforwardnessDiplomacy
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidStraightforwardnessDiplomacy;
        }
    }
}