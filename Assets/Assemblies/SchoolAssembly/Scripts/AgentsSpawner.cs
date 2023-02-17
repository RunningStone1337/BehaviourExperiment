using UnityEngine;

namespace BehaviourModel
{
    public class AgentsSpawner : MonoBehaviour
    {
        [SerializeField] protected GameObject pupilPrefab;
        [SerializeField] protected GameObject teacherPrefab;
        public T CreateAgent<T>(HumanRawData pup, Transform spawnTransform)
           where T : SchoolAgentBase<T>
        {
            GameObject prefab;
            if (typeof(T).IsEquivalentTo(typeof(PupilAgent)))
                prefab = pupilPrefab;
            else
                prefab = teacherPrefab;
            var pupGO = Instantiate(prefab, spawnTransform, true).GetComponent<T>();
            if (pupGO is PupilAgent p)
            {
                p.Initiate<
            PupilLowAnxiety, PupilMiddleAnxiety, PupilHighAnxiety,
            PupilLowClosenessSociability, PupilMiddleClosenessSociability, PupilHighClosenessSociability,
            PupilLowEmotionalStability, PupilMiddleEmotionalStability, PupilHighEmotionalStability,
            PupilLowNonconformism, PupilMiddleNonconformism, PupilHighNonconformism,
            PupilLowNormativityOfBehaviour, PupilMiddleNormativityOfBehaviour, PupilHighNormativityOfBehaviour,
            PupilLowRadicalism, PupilMiddleRadicalism, PupilHighRadicalism,
            PupilLowSelfcontrol, PupilMiddleSelfcontrol, PupilHighSelfcontrol,
            PupilLowSensetivity, PupilMiddleSensetivity, PupilHighSensetivity,
            PupilLowSuspicion, PupilMiddleSuspicion, PupilHighSuspicion,
            PupilLowTension, PupilMiddleTension, PupilHighTension,
            PupilLowExpressiveness, PupilMiddleExpressiveness, PupilHighExpressiveness,
            PupilLowIntelligence, PupilMiddleIntelligence, PupilHighIntelligence,
            PupilLowDreaminess, PupilMiddleDreaminess, PupilHighDreaminess,
            PupilLowDomination, PupilMiddleDomination, PupilHighDomination,
            PupilLowDiplomacy, PupilMiddleDiplomacy, PupilHighDiplomacy,
            PupilLowCourage, PupilMiddleCourage, PupilHighCourage>(pup);
            }
            else if (pupGO is TeacherAgent t)
            {
                t.Initiate<
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
           TeacherLowCourage, TeacherMiddleCourage, TeacherHighCourage>(pup);
            }
            return pupGO;
        }
    }
}