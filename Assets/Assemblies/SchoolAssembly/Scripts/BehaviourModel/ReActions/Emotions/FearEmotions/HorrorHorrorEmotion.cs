using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// Ужас, сильная эмоция
    /// </summary>
    public class HorrorHorrorEmotion : HorrorEmotionBase
    {
        public HorrorHorrorEmotion() : base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}