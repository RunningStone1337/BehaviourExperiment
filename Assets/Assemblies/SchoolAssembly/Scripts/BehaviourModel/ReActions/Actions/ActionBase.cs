using System;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public abstract class ActionBase : ReactionBase, IAction, IStatusBarDataSource
    {
        protected float actionMakingTime;
        protected ActionType actionType;
        public float BarShowingTime { get => actionMakingTime; set => actionMakingTime = value; }
        public  Sprite StatusBarSprite { get => ActionsImagesDictionary.Instance.KeyValuePairs[actionType]; set=> ActionsImagesDictionary.Instance.KeyValuePairs[actionType] = value; }

        public ActionBase() : base()
        {
        }
    }
}