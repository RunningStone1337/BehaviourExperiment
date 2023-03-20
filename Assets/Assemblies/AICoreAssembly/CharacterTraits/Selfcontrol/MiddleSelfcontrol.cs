namespace BehaviourModel
{
    /// <summary>
    /// Умеренный самоконтроль
    /// </summary>
    public class MiddleSelfcontrol : Selfcontrol
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidSelfcontrol;
        }
    }
}