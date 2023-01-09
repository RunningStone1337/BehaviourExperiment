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
        [SerializeField] private CalmnessAnxiety calmnessAnxiety;
        [SerializeField] private ClosenessSociability closenessSociability;
        [SerializeField] private ConformismNonconformism conformismNonconformism;
        [SerializeField] private ConservatismRadicalism conservatismRadicalism;
        [SerializeField] private CredulitySuspicion credulitySuspicion;
        [SerializeField] private EmotionalInstabilityStability emotionalInstabilityStability;
        [SerializeField] private Intelligence intelligence;
        [SerializeField] private NormativityOfBehaviour normativityOfBehaviour;
        [SerializeField] private PracticalityDreaminess practicalityDreaminess;
        [SerializeField] private RelaxationTension relaxationTension;
        [SerializeField] private RestraintExpressiveness restraintExpressiveness;
        [SerializeField] private RigiditySensetivity rigiditySensetivity;
        [SerializeField] private Selfcontrol selfcontrol;
        [SerializeField] private StraightforwardnessDiplomacy straightforwardnessDiplomacy;
        [SerializeField] private SubordinationDomination subordinationDomination;
        [SerializeField] private TimidityCourage timidityCourage;

        public CalmnessAnxiety CalmnessAnxiety { get => calmnessAnxiety; private set => calmnessAnxiety = value; }
        public ClosenessSociability ClosenessSociability { get => closenessSociability; private set => closenessSociability = value; }
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