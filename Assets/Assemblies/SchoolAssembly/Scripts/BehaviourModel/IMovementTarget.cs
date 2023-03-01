using System;
using System.Collections;

namespace BehaviourModel
{
    public interface IMovementTarget
    {
        Func<bool> MoveToTargetCondition { get;}
    }
}