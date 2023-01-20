using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class ActionBase
    {
        protected ActionBase(IPhenomenon context)
        {
            Context = context;
        }

        public IPhenomenon Context { get; protected set; }
    }
}