namespace BehaviourModel
{
    /// <summary>
    /// ������ �����������=���������
    /// </summary>
    public class LowAnxiety : CalmnessAnxiety
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowCalmnessAnxiety;
        }
       
    }
}