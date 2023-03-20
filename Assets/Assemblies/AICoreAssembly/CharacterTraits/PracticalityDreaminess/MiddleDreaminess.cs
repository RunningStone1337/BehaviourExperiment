namespace BehaviourModel
{
    /// <summary>
    /// Умеренная мечтательность
    /// </summary>
    public class MiddleDreaminess : PracticalityDreaminess
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidPracticalityDreaminess;
        }
    }
}