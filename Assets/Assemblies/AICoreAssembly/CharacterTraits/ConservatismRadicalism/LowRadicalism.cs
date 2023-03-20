namespace BehaviourModel
{
    /// <summary>
    /// ������ ����������.
    /// </summary>
    public class LowRadicalism : ConservatismRadicalism
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowConservatismRadicalism;
        }
    }
}