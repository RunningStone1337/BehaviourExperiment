using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// Опасение
    /// </summary>
    public class CautionHorrorEmotion : HorrorEmotionBase
    {
        public CautionHorrorEmotion() : base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}