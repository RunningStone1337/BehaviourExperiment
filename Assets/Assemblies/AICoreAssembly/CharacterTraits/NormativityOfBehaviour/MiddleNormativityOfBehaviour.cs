namespace BehaviourModel
{
    /// <summary>
    /// ��������� �������������
    /// </summary>
    public class MiddleNormativityOfBehaviour : NormativityOfBehaviour
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.MidNormativityOfBehaviour;
        }

        //protected override float CalculateImportanceForFamiliar(AgentBase agent)
        //{
        //    float res = default;
        //    var currentRelation = ThisAgent.GetCurrentRelationTo(agent);
        //    if (currentRelation != null)
        //        res += currentRelation.GetImportanceValueFor(this);
        //    return res;
        //}
    }
}