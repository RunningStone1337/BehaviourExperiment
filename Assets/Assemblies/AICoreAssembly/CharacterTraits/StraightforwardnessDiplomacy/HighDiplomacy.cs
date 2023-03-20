namespace BehaviourModel
{
    /// <summary>
    /// ������� ���������������
    /// </summary>
    public class HighDiplomacy : StraightforwardnessDiplomacy
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighStraightforwardnessDiplomacy;
        }
    }
}