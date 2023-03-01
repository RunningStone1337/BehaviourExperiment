using Events;
using System;
using System.Collections;

namespace BehaviourModel
{
    [Serializable]
    public abstract class ReactionBase : IPhenomenon, IReaction
    {
        protected ReactionBase()
        {

        }

        public IAgent ActionActor { get; set; }
        public IReactionSource ReactionSource { get; set; }
        public float PhenomenonPower { get; set; }
        public bool WasPerformed { get; set; }

        /// <summary>
        /// A state change or other reaction representing the implementation of this action
        /// </summary>
        public abstract IEnumerator TryPerformAction();

        public void Initiate(IReactionSource reactSource, IAgent reactionActor)
        {
            ReactionSource = reactSource;
            ActionActor = reactionActor;
        }
    }
}