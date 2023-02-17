using BehaviourModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuildTester : MonoBehaviour
{
    [SerializeField] RawCharacterValuesHandler characterBuilder;
    [SerializeField] PupilAgent agentToBuild;

    [ContextMenu("ApplyCharacter")]
    public void ApplyNewCharacter()
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
    private void Start()
    {
        ApplyNewCharacter();
    }
    [ContextMenu("Randomize")]
    public void Randomize()
    {
        characterBuilder.Randomize();
    }
}
