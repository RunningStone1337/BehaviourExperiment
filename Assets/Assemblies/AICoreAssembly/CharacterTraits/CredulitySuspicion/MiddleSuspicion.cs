namespace BehaviourModel
{
    /// <summary>
    /// ��������� ����������������
    /// </summary>
    public class MiddleSuspicion : CredulitySuspicion
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidCredulitySuspicion;
        }
    }
}