namespace BehaviourModel
{
    /// <summary>
    /// ��������� ���������������
    /// </summary>
    public class MiddleExpressiveness : RestraintExpressiveness
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidRestraintExpressiveness;
        }
    }
}