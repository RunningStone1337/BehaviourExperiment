
namespace BehaviourModel
{
    /// <summary>
    /// ����������, ������ �������������
    /// </summary>
    public class LowNonconformism : ConformismNonconformism
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowConformismNonconformism;
        }
    }
}