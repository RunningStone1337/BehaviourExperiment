using System;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public abstract class ActionBase
        : IAction, IStatusBarDataSource
    {
        protected ActionBase() { }

        public IAgent ActionActor { get; set; }
        public IPhenomenon ReactionSource { get; set; }
        public float ActionUtility { get; set; }
        public bool WasPerformed { get; set; }
        protected float actionMakingTime;
        protected ActionType actionType;
        public float BarShowingTime { get => actionMakingTime; set => actionMakingTime = value; }
        public Sprite StatusBarSprite { get => ActionsImagesDictionary.Instance.KeyValuePairs[actionType]; set => ActionsImagesDictionary.Instance.KeyValuePairs[actionType] = value; }
        /// <summary>
        /// A state change or other reaction representing the implementation of this action
        /// </summary>
        public abstract IEnumerator TryPerformAction();

        public virtual void Initiate(IPhenomenon reactSource, IAgent reactionActor)
        {
            ReactionSource = reactSource;
            ActionActor = reactionActor;
        }


        public float CalculateUtility(IUtilityCalculationSource source)
        {
            ActionUtility = Mathf.Abs(((CharacterTraitBase)source).SpecializedCharacterValue);
            return ActionUtility;
        }
    }
}