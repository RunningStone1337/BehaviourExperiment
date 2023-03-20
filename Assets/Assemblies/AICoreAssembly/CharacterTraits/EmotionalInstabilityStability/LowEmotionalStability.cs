namespace BehaviourModel
{
    /// <summary>
    /// Низкая стабильность
    /// </summary>
    public class LowEmotionalStability : EmotionalInstabilityStability
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowEmotionalInstabilityStability;
        }

    }
}