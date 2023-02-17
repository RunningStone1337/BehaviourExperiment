using System;

namespace BehaviourModel
{
    [Serializable]
    public class ReactionBase : IPhenomenon, IReaction
    {
        public ReactionBase()
        {

        }
        protected ReactionBase(IReactionSource source, int phenomPower)
        {
            ReactionSource = source;
            PhenomenonPower = phenomPower;
        }

        public IReactionSource ReactionSource { get; private set; }
        public float PhenomenonPower { get; set; }
    }
}