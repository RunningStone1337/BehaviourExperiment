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
            PupilLowAnxiety,PupilMiddleAnxiety,PupilHighAnxiety,
            PupilLowClosenessSociability,PupilMiddleClosenessSociability,PupilHighClosenessSociability,
            PupilLowEmotionalStability,PupilMiddleEmotionalStability,PupilHighEmotionalStability,
            PupilLowNonconformism,PupilMiddleNonconformism,PupilHighNonconformism,
            PupilLowNormativityOfBehaviour,PupilMiddleNormativityOfBehaviour,PupilHighNormativityOfBehaviour,
            PupilLowRadicalism,PupilMiddleRadicalism,PupilHighRadicalism,
            PupilLowSelfcontrol,PupilMiddleSelfcontrol,PupilHighSelfcontrol,
            PupilLowSensetivity,PupilMiddleSensetivity,PupilHighSensetivity,
            PupilLowSuspicion,PupilMiddleSuspicion,PupilHighSuspicion,
            PupilLowTension,PupilMiddleTension,PupilHighTension,
            PupilLowExpressiveness,PupilMiddleExpressiveness,PupilHighExpressiveness,
            PupilLowIntelligence,PupilMiddleIntelligence,PupilHighIntelligence,
            PupilLowDreaminess,PupilMiddleDreaminess,PupilHighDreaminess,
            PupilLowDomination,PupilMiddleDomination,PupilHighDomination,
            PupilLowDiplomacy,PupilMiddleDiplomacy,PupilHighDiplomacy,
            PupilLowCourage,PupilMiddleCourage,PupilHighCourage>(characterBuilder);
        Debug.Log($"New character:\n {agentToBuild.CharacterSystem}");
    }
   
}
#endif
