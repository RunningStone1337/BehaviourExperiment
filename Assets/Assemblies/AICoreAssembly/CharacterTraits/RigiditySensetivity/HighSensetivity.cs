namespace BehaviourModel
{
    /// <summary>
    /// Высокая чувствительность
    /// </summary>
    public class HighSensetivity : RigiditySensetivity

    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighRigiditySensetivity;
        }
    }
}