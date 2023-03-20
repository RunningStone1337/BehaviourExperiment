#if UNITY_EDITOR
using BehaviourModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupilCharBuildTester : CharacterBuildTester<PupilAgent>
{
    public override void ApplyNewCharacter()
    {
        agentToBuild.CharacterSystem.RemoveTraits();
        agentToBuild.CharacterSystem.Initiate<
             LowAnxiety, MiddleAnxiety, HighAnxiety,
             LowClosenessSociability, MiddleClosenessSociability, HighClosenessSociability,
             LowEmotionalStability, MiddleEmotionalStability, HighEmotionalStability,
             LowNonconformism, MiddleNonconformism, HighNonconformism,
             LowNormativityOfBehaviour, MiddleNormativityOfBehaviour, HighNormativityOfBehaviour,
             LowRadicalism, MiddleRadicalism, HighRadicalism,
             LowSelfcontrol, MiddleSelfcontrol, HighSelfcontrol,
             LowSensetivity, MiddleSensetivity, HighSensetivity,
             LowSuspicion, MiddleSuspicion, HighSuspicion,
             LowTension, MiddleTension, HighTension,
             LowExpressiveness, MiddleExpressiveness, HighExpressiveness,
             LowIntelligence, MiddleIntelligence, HighIntelligence,
             LowDreaminess, MiddleDreaminess, HighDreaminess,
             LowDomination, MiddleDomination, HighDomination,
             LowDiplomacy, MiddleDiplomacy, HighDiplomacy,
             LowCourage, MiddleCourage, HighCourage>(characterBuilder);
        Debug.Log($"New character:\n {agentToBuild.CharacterSystem}");
    }
   
}
#endif
