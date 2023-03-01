using System.Collections;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// «лость
    /// </summary>
    public class AngerAngerEmotion : AngerEmotionBase
    {
        public AngerAngerEmotion():base()
        {

        }

        public override IEnumerator TryPerformAction()
        {
            throw new System.Exception();
        }
    }
}