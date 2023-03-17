#if UNITY_EDITOR
using UnityEngine;

namespace BehaviourModel
{
    public class TeacherBuildTester : CharacterBuildTester<TeacherAgent>
    {
        public override void ApplyNewCharacter()
        {
            agentToBuild.CharacterSystem.RemoveTraits();
            agentToBuild.CharacterSystem.Initiate<
                TeacherLowAnxiety, TeacherMiddleAnxiety, TeacherHighAnxiety,
                TeacherLowClosenessSociability, TeacherMiddleClosenessSociability, TeacherHighClosenessSociability,
                TeacherLowEmotionalStability, TeacherMiddleEmotionalStability, TeacherHighEmotionalStability,
                TeacherLowNonconformism, TeacherMiddleNonconformism, TeacherHighNonconformism,
                TeacherLowNormativityOfBehaviour, TeacherMiddleNormativityOfBehaviour, TeacherHighNormativityOfBehaviour,
                TeacherLowRadicalism, TeacherMiddleRadicalism, TeacherHighRadicalism,
                TeacherLowSelfcontrol, TeacherMiddleSelfcontrol, TeacherHighSelfcontrol,
                TeacherLowSensetivity, TeacherMiddleSensetivity, TeacherHighSensetivity,
                TeacherLowSuspicion, TeacherMiddleSuspicion, TeacherHighSuspicion,
                TeacherLowTension, TeacherMiddleTension, TeacherHighTension,
                TeacherLowExpressiveness, TeacherMiddleExpressiveness, TeacherHighExpressiveness,
                TeacherLowIntelligence, TeacherMiddleIntelligence, TeacherHighIntelligence,
                TeacherLowDreaminess, TeacherMiddleDreaminess, TeacherHighDreaminess,
                TeacherLowDomination, TeacherMiddleDomination, TeacherHighDomination,
                TeacherLowDiplomacy, TeacherMiddleDiplomacy, TeacherHighDiplomacy,
                TeacherLowCourage, TeacherMiddleCourage, TeacherHighCourage>(characterBuilder);
            Debug.Log($"New character:\n {agentToBuild.CharacterSystem}");
        }
    }
}
#endif
