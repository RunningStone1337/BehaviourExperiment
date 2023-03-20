namespace BehaviourModel
{
    public class MiddleRadicalism : ConservatismRadicalism
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidConservatismRadicalism;
        }

    }
}