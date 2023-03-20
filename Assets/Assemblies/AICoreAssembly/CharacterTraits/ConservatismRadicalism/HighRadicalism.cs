namespace BehaviourModel
{
    /// <summary>
    /// Высокий радикализм
    /// </summary>
    public class HighRadicalism : ConservatismRadicalism
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighConservatismRadicalism;
        }
    }
}