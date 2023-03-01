using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// Страх
    /// </summary>
    public class FearHorrorEmotion : HorrorEmotionBase
    {
        public FearHorrorEmotion() : base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}