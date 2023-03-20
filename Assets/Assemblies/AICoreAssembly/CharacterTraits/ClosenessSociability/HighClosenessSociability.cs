namespace BehaviourModel
{
    /// <summary>
    /// ������� �������������
    /// </summary>
    public class HighClosenessSociability : ClosenessSociability
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighClosenessSociability;
        }
    }
}