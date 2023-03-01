using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// Уныние, слабая эмоция
    /// </summary>
    public class DespondencySadEmotion : SadEmotionBase
    {
        public DespondencySadEmotion() : base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}