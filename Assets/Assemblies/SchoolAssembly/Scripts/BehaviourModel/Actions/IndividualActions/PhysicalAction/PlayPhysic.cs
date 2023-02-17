using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class PlayPhysic : PositivePhysicAction
    {
        public PlayPhysic(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
        public PlayPhysic():base()
        {

        }
    }
}