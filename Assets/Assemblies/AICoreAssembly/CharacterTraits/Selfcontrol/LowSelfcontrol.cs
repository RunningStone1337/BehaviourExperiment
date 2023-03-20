namespace BehaviourModel
{
    /// <summary>
    /// Низкий самоконтроль
    /// </summary>
    public class LowSelfcontrol : Selfcontrol
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowSelfcontrol;
        }
    }
}