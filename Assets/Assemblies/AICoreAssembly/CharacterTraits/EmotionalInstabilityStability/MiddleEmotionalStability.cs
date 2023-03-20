namespace BehaviourModel
{
    /// <summary>
    /// Умеренная стабильность
    /// </summary>
    public class MiddleEmotionalStability : EmotionalInstabilityStability

    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidEmotionalInstabilityStability;
        }
       
    }
}