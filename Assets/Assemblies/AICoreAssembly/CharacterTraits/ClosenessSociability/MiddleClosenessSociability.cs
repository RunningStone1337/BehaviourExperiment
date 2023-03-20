
namespace BehaviourModel
{
    /// <summary>
    /// —редн€€ общительность
    /// </summary>
    public class MiddleClosenessSociability : ClosenessSociability
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidClosenessSociability;
        }
    }
}