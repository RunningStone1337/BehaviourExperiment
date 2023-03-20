namespace BehaviourModel
{
    /// <summary>
    /// Высокая нормативность
    /// </summary>
    public class HighNormativityOfBehaviour : NormativityOfBehaviour
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighNormativityOfBehaviour;
        }
    }
}