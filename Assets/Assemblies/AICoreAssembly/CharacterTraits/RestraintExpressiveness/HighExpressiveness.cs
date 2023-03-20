namespace BehaviourModel
{
    /// <summary>
    /// ������� ���������������.
    /// </summary>
    public class HighExpressiveness : RestraintExpressiveness
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighRestraintExpressiveness;
        }
    }
}