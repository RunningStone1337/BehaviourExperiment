using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class DreamState : SchoolAgentStateBase<PupilAgent>, IOptionalToCompleteState
    {
        bool isDreaming = true;
        public bool IsContinue { get => isDreaming; set => isDreaming = value; }
        float dreamingTimer;

        public override IEnumerator StartState()
        {
            dreamingTimer = Mathf.Pow(thisAgent.CharacterSystem.PracticalityDreaminess.RawCharacterValue, 1.25f) + Random.Range(0f, 3f);
            while (isDreaming && dreamingTimer > 0f)
            {
                yield return new WaitForFixedUpdate();
                dreamingTimer -= Time.fixedDeltaTime;
            }
            if (isDreaming)
                thisAgent.SetDefaultState();
        }
    }
}
