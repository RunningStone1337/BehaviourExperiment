namespace BehaviourModel
{
    /// <summary>
    /// Высокая тревожность.
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