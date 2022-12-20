using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Система приобретённых особенностей человека, формы проявления
    /// импульсов нервной системы, возникающих вследствие внешних воздействий или
    /// внутренних факторов.
    /// </summary>
    public class CharacterSystem : MonoBehaviour
    {
        [SerializeField] ClosenessSociability closenessSociability;
        [SerializeField] CalmnessAnxiety calmnessAnxiety;
        [SerializeField] ConformismNonconformism conformismNonconformism;
        [SerializeField] ConservatismRadicalism conservatismRadicalism;
        [SerializeField] CredulitySuspicion credulitySuspicion;
        [SerializeField] EmotionalInstabilityStability emotionalInstabilityStability;
        [SerializeField] Intelligence intelligence;
        [SerializeField] NormativityOfBehaviour normativityOfBehaviour;
        [SerializeField] PracticalityDreaminess practicalityDreaminess;
        [SerializeField] RelaxationTension relaxationTension;
        [SerializeField] RestraintExpressiveness restraintExpressiveness;
        [SerializeField] RigiditySensetivity rigiditySensetivity;
        [SerializeField] Selfcontrol selfcontrol;
        [SerializeField] StraightforwardnessDiplomacy straightforwardnessDiplomacy;
        [SerializeField] SubordinationDomination subordinationDomination;
        [SerializeField] TimidityCourage timidityCourage;
        
        public ClosenessSociability ClosenessSociability { get => closenessSociability; private set => closenessSociability = value; }
        public CalmnessAnxiety CalmnessAnxiety { get => calmnessAnxiety; private set => calmnessAnxiety = value; }
        public ConformismNonconformism ConformismNonconformism { get => conformismNonconformism; private set => conformismNonconformism = value; }
        public ConservatismRadicalism ConservatismRadicalism { get => conservatismRadicalism; private set => conservatismRadicalism = value; }
        public CredulitySuspicion CredulitySuspicion { get => credulitySuspicion; private set => credulitySuspicion = value; }
        public EmotionalInstabilityStability EmotionalInstabilityStability { get => emotionalInstabilityStability; private set => emotionalInstabilityStability = value; }
        public Intelligence Intelligence { get => intelligence; private set => intelligence = value; }
        public NormativityOfBehaviour NormativityOfBehaviour { get => normativityOfBehaviour; private set => normativityOfBehaviour = value; }
        public PracticalityDreaminess PracticalityDreaminess { get => practicalityDreaminess; private set => practicalityDreaminess = value; }
        public RelaxationTension RelaxationTension { get => relaxationTension; private set => relaxationTension = value; }
        public RestraintExpressiveness RestraintExpressiveness { get => restraintExpressiveness; private set => restraintExpressiveness = value; }
        public RigiditySensetivity RigiditySensetivity { get => rigiditySensetivity; private set => rigiditySensetivity = value; }
        public Selfcontrol Selfcontrol { get => selfcontrol; private set => selfcontrol = value; }
        public StraightforwardnessDiplomacy StraightforwardnessDiplomacy { get => straightforwardnessDiplomacy; private set => straightforwardnessDiplomacy = value; }
        public SubordinationDomination SubordinationDomination { get => subordinationDomination; private set => subordinationDomination = value; }
        public TimidityCourage TimidityCourage { get => timidityCourage; private set => timidityCourage = value; }
    }
}