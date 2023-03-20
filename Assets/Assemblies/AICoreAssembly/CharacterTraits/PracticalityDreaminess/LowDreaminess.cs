namespace BehaviourModel
{
    /// <summary>
    /// ������ �������������� = ������������
    /// </summary>
    public class LowDreaminess : PracticalityDreaminess
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowPracticalityDreaminess;
        }
    }
}