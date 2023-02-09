using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class TeacherReactionResolver : SchoolReactionResolver
    {
        public override bool HasReactionOn(IPhenomenon reason, out List<IReaction> reaction)
        {
            throw new System.NotImplementedException();
        }
    }
}
