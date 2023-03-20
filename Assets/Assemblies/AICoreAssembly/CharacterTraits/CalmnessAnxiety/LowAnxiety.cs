namespace BehaviourModel
{
    /// <summary>
    /// Низкая тревожность=спокойный
    /// </summary>
    public class LowAnxiety : CalmnessAnxiety
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowCalmnessAnxiety;
        }
       
    }
}