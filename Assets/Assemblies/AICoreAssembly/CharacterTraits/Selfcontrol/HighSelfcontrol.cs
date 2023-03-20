namespace BehaviourModel
{
    /// <summary>
    /// Высокий самоконтроль
    /// </summary>
    public class HighSelfcontrol : Selfcontrol
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighSelfcontrol;
        }
    }
}