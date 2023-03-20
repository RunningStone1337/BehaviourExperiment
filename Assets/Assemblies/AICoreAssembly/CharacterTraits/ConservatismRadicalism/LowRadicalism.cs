namespace BehaviourModel
{
    /// <summary>
    /// Низкий радикализм.
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