using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class DreamState : SchoolAgentStateBase<PupilAgent>, IOptionalToCompleteState
    {
        private float dreamingTimer;
        private bool isDreaming = true;
        public bool IsContinue { get => isDreaming; set => isDreaming = value; }

        public override IEnumerator StartState()
        {
            dreamingTimer = Mathf.Pow(thisAgent.CharacterSystem.PracticalityDreaminess.RawCharacterValue, 1.25f) + Random.Range(0f, 3f);
            while (isDreaming && dreamingTimer > 0f)
            {
                yield return new WaitForFixedUpdate();
                dreamingTimer -= Time.fixedDeltaTime * Time.timeScale;
            }
            if (isDreaming)
                thisAgent.SetDefaultState();
        }
    }
}