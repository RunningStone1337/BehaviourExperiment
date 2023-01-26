using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Высокий самоконтроль
    /// </summary>
    public sealed class HighSelfcontrol : Selfcontrol
    {

        /// <summary>
        /// Я наредкость выдержан. Немногословен и неэмоционален на людях.
        /// Мы знакомы? Если нет, я не проявлю интереса.
        /// Если да, то какие у нас отношения?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            recognitionChance = (4 - CharacterValue)/10f;
            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 5 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -5 * CharacterValue);
        }
      
    }
}