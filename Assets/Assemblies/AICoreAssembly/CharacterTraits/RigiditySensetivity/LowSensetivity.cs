namespace BehaviourModel
{
    /// <summary>
    /// ������ ���������������� - ���������
    /// </summary>
    public class LowSensetivity : RigiditySensetivity
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowRigiditySensetivity;
        }
    }
}