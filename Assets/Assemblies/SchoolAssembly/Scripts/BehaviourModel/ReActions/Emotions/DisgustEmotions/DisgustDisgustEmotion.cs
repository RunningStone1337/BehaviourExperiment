using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// Отвращение
    /// </summary>
    public class DisgustDisgustEmotion : DisgustEmotionBase
    {
        public DisgustDisgustEmotion() : base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}