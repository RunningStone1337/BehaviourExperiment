using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public abstract class ActionBase : ReactionBase, IAction
    {
        public ActionBase():base()
        {

        }
    }
}