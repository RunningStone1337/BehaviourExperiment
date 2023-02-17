using Core;
using Events;

namespace BehaviourModel
{
    public class RewardCalculationsEventArgs
    {
        public ReactionBase LastReaction { get; internal set; }
        public float Reward { get; internal set; }
        //public RelationshipBase Relations { get; internal set; }
        public GlobalEvent Event { get; internal set; }
    }
}