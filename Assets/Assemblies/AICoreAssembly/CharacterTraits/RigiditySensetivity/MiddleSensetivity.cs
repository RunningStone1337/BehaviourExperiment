namespace BehaviourModel
{
    /// <summary>
    /// ��������� ����������������
    /// </summary>
    public class MiddleSensetivity : RigiditySensetivity
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidRigiditySensetivity;
        }
    }
}