using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class ContactGroupAction : GroupAction
    {
        public ContactGroupAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
    }
}