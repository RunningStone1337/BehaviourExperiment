namespace BehaviourModel
{
    /// <summary>
    /// ������������
    /// </summary>
    public class LowSuspicion : CredulitySuspicion
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowCredulitySuspicion;
        }
    }
}