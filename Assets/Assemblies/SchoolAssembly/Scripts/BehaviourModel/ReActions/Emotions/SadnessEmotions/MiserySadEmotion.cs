using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// Страдание, сильная эмоция
    /// </summary>
    public class MiserySadEmotion : SadEmotionBase
    {
        public MiserySadEmotion() : base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}