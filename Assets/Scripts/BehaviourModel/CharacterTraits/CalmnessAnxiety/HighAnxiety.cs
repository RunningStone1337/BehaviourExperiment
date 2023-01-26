using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ¬ысока€ тревожность.
    /// </summary>
    public sealed class HighAnxiety : CalmnessAnxiety
    {
        protected override float CalculateImportanceForFamiliar(AgentBase agent)
        {
            float res = default;
            var currentRelation = ThisAgent.GetCurrentRelationTo(agent);
            if (currentRelation.HasImportanceFor(this))
                res += currentRelation.GetImportanceValueFor(this);
            return res;
        }

        /// <summary>
        ///  ак важен человек дл€ тревожного характера?
        /// я его знаю? ≈сли нет, то скорее всего, это источник проблем и непри€тностей.
        /// я буду его избегать или осторожно изучать.
        /// ≈сли знаю, то беспокоит он мен€ или нет? ¬ любом случае, нужно быть начеку.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(NegativeEmotionBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -1 * CharacterValue);
        }
    }
}