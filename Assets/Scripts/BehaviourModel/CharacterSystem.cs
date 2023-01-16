using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Система приобретённых особенностей человека, формы проявления
    /// импульсов нервной системы, возникающих вследствие внешних или внутренних или
    ///  факторов.
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

        private TRes CreateCharacter<TLow, TMid, THigh, TRes>(int characterValue)
            where TLow : TRes
            where TMid : TRes
            where THigh : TRes
            where TRes : CharacterTraitBase
        {
            TRes res;
            var range = Enumerable.Range(1, 3);
            if (range.Contains(characterValue))
            {
                res = gameObject.AddComponent<TLow>();
                res.Initiate(characterValue);
            }
            range = Enumerable.Range(4, 4);
            if (range.Contains(characterValue))
            {
                res = gameObject.AddComponent<TMid>();
                res.Initiate(characterValue);
            }
            range = Enumerable.Range(8, 3);
            if (range.Contains(characterValue))
            {
                res = gameObject.AddComponent<THigh>();
                res.Initiate(characterValue);
            }
            throw new Exception($"Value {nameof(characterValue)} was out of range [1;10]");
        }

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

        public void Initiate(HumanRawData data)
        {
            CalmnessAnxiety = CreateCharacter<LowAnxiety, MiddleAnxiety, HighAnxiety, CalmnessAnxiety>(data.CalmnessAnxiety);
            ClosenessSociability = CreateCharacter<LowClosenessSociability, MiddleClosenessSociability, HighClosenessSociability, ClosenessSociability>(data.ClosenessSociability);
            ConformismNonconformism = CreateCharacter<LowNonconformism, MiddleNonconformism, HighNonconformism, ConformismNonconformism>(data.ConformismNonconformism);
            ConservatismRadicalism = CreateCharacter<LowRadicalism, MiddleRadicalism, HighRadicalism, ConservatismRadicalism>(data.ConservatismRadicalism);
            CredulitySuspicion = CreateCharacter<LowSuspicion, MiddleSuspicion, HighSuspicion, CredulitySuspicion>(data.CredulitySuspicion);
            EmotionalInstabilityStability = CreateCharacter<LowEmotionalStability, MiddleEmotionalStability, HighEmotionalStability, EmotionalInstabilityStability>(data.EmotionalInstabilityStability);
            Intelligence = CreateCharacter<LowIntelligence, MiddleIntelligence, HighIntelligence, Intelligence>(data.Intelligence);
            NormativityOfBehaviour = CreateCharacter<LowNormativityOfBehaviour, MiddleNormativityOfBehaviour, HighNormativityOfBehaviour, NormativityOfBehaviour>(data.NormativityOfBehaviour);
            PracticalityDreaminess = CreateCharacter<LowDreaminess, MiddleDreaminess, HighDreaminess, PracticalityDreaminess>(data.PracticalityDreaminess);
            RelaxationTension = CreateCharacter<LowTension, MiddleTension, HighTension, RelaxationTension>(data.RelaxationTension);
            RestraintExpressiveness = CreateCharacter<LowExpressiveness, MiddleExpressiveness, HighExpressiveness, RestraintExpressiveness>(data.RestraintExpressiveness);
            RigiditySensetivity = CreateCharacter<LowSensetivity, MiddleSensetivity, HighSensetivity, RigiditySensetivity>(data.RigiditySensetivity);
            Selfcontrol = CreateCharacter<LowSelfcontrol, MiddleSelfcontrol, HighSelfcontrol, Selfcontrol>(data.Selfcontrol);
            StraightforwardnessDiplomacy = CreateCharacter<LowDiplomacy, MiddleDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(data.StraightforwardnessDiplomacy);
            SubordinationDomination = CreateCharacter<LowDomination, MiddleDomination, HighDomination, SubordinationDomination>(data.SubordinationDomination);
            TimidityCourage = CreateCharacter<LowCourage, MiddleCourage, HighCourage, TimidityCourage>(data.TimidityCourage);
        }
    }
}