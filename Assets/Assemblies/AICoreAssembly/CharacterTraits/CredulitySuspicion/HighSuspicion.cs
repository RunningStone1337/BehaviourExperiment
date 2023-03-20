namespace BehaviourModel
{
    /// <summary>
    /// ����������������
    /// </summary>
    public class HighSuspicion : CredulitySuspicion
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighCredulitySuspicion;
        }
    }
}