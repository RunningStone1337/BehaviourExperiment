using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// «лость
    /// </summary>
    public class AngerAngerEmotion : AngerEmotionBase
    {
        public AngerAngerEmotion(IReactionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
        public AngerAngerEmotion():base()
        {

        }
       
    }
}