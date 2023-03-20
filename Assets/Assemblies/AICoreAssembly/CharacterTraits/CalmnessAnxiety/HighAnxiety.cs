namespace BehaviourModel
{
    /// <summary>
    /// ������� �����������.
    /// </summary>
    public class HighAnxiety : CalmnessAnxiety
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighCalmnessAnxiety;
        }

    }
}