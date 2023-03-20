
namespace BehaviourModel
{
    /// <summary>
    /// Замкнутость
    /// </summary>
    public class LowClosenessSociability : ClosenessSociability

    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowClosenessSociability;
        }
    }
}