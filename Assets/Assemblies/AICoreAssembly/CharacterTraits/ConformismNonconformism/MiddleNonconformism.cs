
namespace BehaviourModel
{
    /// <summary>
    /// Средний нонкомформизс
    /// </summary>
    public class MiddleNonconformism : ConformismNonconformism
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidConformismNonconformism;
        }
    }
}