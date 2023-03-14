using System;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public abstract class ActionBase : ReactionBase, IAction, IStatusBarDataSource
    {
        protected float actionMakingTime;
        protected Sprite actionSprite;
        public float BarShowingTime { get => actionMakingTime; set => actionMakingTime = value; }
        public Sprite StatusBarSprite { get => actionSprite; set => actionSprite = value; }

        public ActionBase() : base()
        {
        }
    }
}