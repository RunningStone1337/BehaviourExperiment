namespace BehaviourModel
{
    /// <summary>
    /// ��������
    /// </summary>
    public class HighCourage : TimidityCourage

    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighTimidityCourage;
        }
    }
}