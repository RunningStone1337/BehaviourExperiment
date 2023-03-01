using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Стейт бездействия
    /// </summary>
    public abstract class ChooseActionState<T> : SchoolAgentStateBase<T>, IOptionalToCompleteState
        where T : SchoolAgentBase<T>
    {
        //public override bool StateBreaked { get => stateBreaked; set => stateBreaked = value; }
        public bool IsContinue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ChooseActionState():base()
        {

        }
    }
}