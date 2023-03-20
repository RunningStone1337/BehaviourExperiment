namespace BehaviourModel
{
    /// <summary>
    /// Низкая нормативность
    /// </summary>
    public class LowNormativityOfBehaviour : NormativityOfBehaviour
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowNormativityOfBehaviour;
        }

    }
}