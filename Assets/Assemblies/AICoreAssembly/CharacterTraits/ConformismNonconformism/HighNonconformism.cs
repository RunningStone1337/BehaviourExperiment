namespace BehaviourModel
{
    /// <summary>
    /// Нонконформист
    /// </summary>
    public class HighNonconformism : ConformismNonconformism
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighConformismNonconformism;
        }
    }
}