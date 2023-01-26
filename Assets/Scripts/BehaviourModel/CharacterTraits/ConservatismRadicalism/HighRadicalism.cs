namespace BehaviourModel
{
    /// <summary>
    /// ¬ысокий радикализм
    /// </summary>
    public sealed class HighRadicalism : ConservatismRadicalism
    {
        protected override float CalculateImportanceForFamiliar(AgentBase ab)
        {
            float res = default;
            var currentRelation = ThisAgent.GetCurrentRelationTo(ab);
            if (currentRelation.HasImportanceFor(this))
                res += currentRelation.GetImportanceValueFor(this);
            return res;
        }

        /// <summary>
        /// я очень прогрессивна€ личность и уважаю только таких же как €,
        /// остальные мне мало интересны. —корее всего, они не очень
        /// умны и интересны. ≈сли мне покажетс€, что ты представл€ешь
        /// интеллектуальный потенциал, € могу про€вить интерес. »наче нет.
        /// ћы знакомы? ≈сли да, то какой у теб€ кругозор и интеллект? ≈сли
        /// хот€ бы не ниже моего, может попробовать общатьс€.
        /// ≈сли нет - € пока не определилс€, интересен ли ты как собеседник.
        /// ¬ любом случае нужно провести анализ.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}