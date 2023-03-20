namespace BehaviourModel
{
    /// <summary>
    /// Умеренная дипломтичность
    /// </summary>
    public class MiddleDiplomacy : StraightforwardnessDiplomacy
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidStraightforwardnessDiplomacy;
        }
    }
}