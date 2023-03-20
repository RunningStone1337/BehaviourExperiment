namespace BehaviourModel
{
    /// <summary>
    /// Умеренная смелость
    /// </summary>
    public class MiddleCourage : TimidityCourage
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidTimidityCourage;
        }

       
    }
}