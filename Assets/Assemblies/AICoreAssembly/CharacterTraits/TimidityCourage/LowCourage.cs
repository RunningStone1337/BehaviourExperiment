namespace BehaviourModel
{
    /// <summary>
    /// �������
    /// </summary>
    public class LowCourage : TimidityCourage
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowTimidityCourage;
        }
    }
}