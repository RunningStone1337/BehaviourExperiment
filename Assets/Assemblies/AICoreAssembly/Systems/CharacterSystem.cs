using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BehaviourModel
{
    public class CharacterSystem<TAgent, TReaction, TFeature, TSensor> :
        SystemBase<TAgent, TReaction, TFeature, TSensor>,
        IEnumerable<CharacterTraitBase>
        where TAgent : IAgent
        where TReaction : IAction
        where TFeature : IFeature
        where TSensor : ISensor
    {
        [SerializeField] private CalmnessAnxiety calmnessAnxiety;
        [SerializeField] [HideInInspector] private List<CharacterTraitBase> characterTraits;
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

        protected override void Awake()
        {
            base.Awake();
            characterTraits = new List<CharacterTraitBase>();
        }

        private TRes CreateCharacter<TLow, TMid, THigh, TRes>(int characterValue)
                    where TLow : TRes
            where TMid : TRes
            where THigh : TRes
            where TRes : CharacterTraitBase
        {
            TRes res = null;
            var range = Enumerable.Range(1, 3);
            if (range.Contains(characterValue))
                res = gameObject.AddComponent<TLow>();
            range = Enumerable.Range(4, 4);
            if (range.Contains(characterValue))
                res = gameObject.AddComponent<TMid>();
            range = Enumerable.Range(8, 3);
            if (range.Contains(characterValue))
                res = gameObject.AddComponent<THigh>();
            if (res != null)
            {
                res.Initiate(characterValue, ThisAgent);
                characterTraits.Add(res);
                return res;
            }
            throw new Exception($"Value {characterValue} {nameof(characterValue)} was out of range [1;10]");
        }

        private void InitFromRawValues<
            TLowAnx, TMidAnx, THighAnx,
            TLowSoc, TMidSoc, THighSoc,
            TLowStab, TMidStab, THighStab,
            TLowNonc, TMidNonc, THighNonc,
            TLowNorm, TMidNorm, THighNorm,
            TLowRad, TMidRad, THighRad,
            TLowSelf, TMidSelf, THighSelf,
            TLowSens, TMidSens, THighSens,
            TLowSusp, TMidSusp, THighSusp,
            TLowTens, TMidTens, THighTens,
            TLowExpre, TMidExpre, THighExpre,
            TLowInt, TMidInt, THighInt,
            TLowDrea, TMidDrea, THighDrea,
            TLowDom, TMidDom, THighDom,
            TLowDipl, TMidDipl, THighDipl,
            TLowCour, TMidCour, THighCour
            >(IRawCharacterInfoSource rawValues)
             where TLowAnx : LowAnxiety
            where TMidAnx : MiddleAnxiety
            where THighAnx : HighAnxiety

            where TLowSoc : LowClosenessSociability
            where TMidSoc : MiddleClosenessSociability
            where THighSoc : HighClosenessSociability

            where TLowStab : LowEmotionalStability
            where TMidStab : MiddleEmotionalStability
            where THighStab : HighEmotionalStability

            where TLowNonc : LowNonconformism
            where TMidNonc : MiddleNonconformism
            where THighNonc : HighNonconformism

            where TLowNorm : LowNormativityOfBehaviour
            where TMidNorm : MiddleNormativityOfBehaviour
            where THighNorm : HighNormativityOfBehaviour

            where TLowRad : LowRadicalism
            where TMidRad : MiddleRadicalism
            where THighRad : HighRadicalism

            where TLowSelf : LowSelfcontrol
            where TMidSelf : MiddleSelfcontrol
            where THighSelf : HighSelfcontrol

            where TLowSens : LowSensetivity
            where TMidSens : MiddleSensetivity
            where THighSens : HighSensetivity

            where TLowSusp : LowSuspicion
            where TMidSusp : MiddleSuspicion
            where THighSusp : HighSuspicion

            where TLowTens : LowTension
            where TMidTens : MiddleTension
            where THighTens : HighTension

            where TLowExpre : LowExpressiveness
            where TMidExpre : MiddleExpressiveness
            where THighExpre : HighExpressiveness

            where TLowInt : LowIntelligence
            where TMidInt : MiddleIntelligence
            where THighInt : HighIntelligence

            where TLowDrea : LowDreaminess
            where TMidDrea : MiddleDreaminess
            where THighDrea : HighDreaminess

            where TLowDom : LowDomination
            where TMidDom : MiddleDomination
            where THighDom : HighDomination

            where TLowDipl : LowDiplomacy
            where TMidDipl : MiddleDiplomacy
            where THighDipl : HighDiplomacy

            where TLowCour : LowCourage
            where TMidCour : MiddleCourage
            where THighCour : HighCourage
        {
            CalmnessAnxiety = CreateCharacter<TLowAnx,
                TMidAnx,
                THighAnx,
                CalmnessAnxiety>(rawValues.CalmnessAnxiety);
            ClosenessSociability = CreateCharacter<TLowSoc,
                TMidSoc,
                THighSoc,
                ClosenessSociability>(rawValues.ClosenessSociability);
            ConformismNonconformism = CreateCharacter<TLowNonc,
                TMidNonc,
                THighNonc,
                ConformismNonconformism>(rawValues.ConformismNonconformism);
            ConservatismRadicalism = CreateCharacter<TLowRad,
                TMidRad,
                THighRad,
                ConservatismRadicalism>(rawValues.ConservatismRadicalism);
            CredulitySuspicion = CreateCharacter<TLowSusp,
                TMidSusp,
                THighSusp,
                CredulitySuspicion>(rawValues.CredulitySuspicion);
            EmotionalInstabilityStability = CreateCharacter<TLowStab,
                TMidStab,
                THighStab,
                EmotionalInstabilityStability>(rawValues.EmotionalInstabilityStability);
            Intelligence = CreateCharacter<TLowInt,
                TMidInt,
                THighInt,
                Intelligence>(rawValues.Intelligence);
            NormativityOfBehaviour = CreateCharacter<TLowNorm,
                TMidNorm,
                THighNorm,
                NormativityOfBehaviour>(rawValues.NormativityOfBehaviour);
            PracticalityDreaminess = CreateCharacter<TLowDrea,
                TMidDrea,
                THighDrea,
                PracticalityDreaminess>(rawValues.PracticalityDreaminess);
            RelaxationTension = CreateCharacter<TLowTens,
                TMidTens,
                THighTens,
                RelaxationTension>(rawValues.RelaxationTension);
            RestraintExpressiveness = CreateCharacter<TLowExpre,
                TMidExpre,
                THighExpre,
                RestraintExpressiveness>(rawValues.RestraintExpressiveness);
            RigiditySensetivity = CreateCharacter<TLowSens,
                TMidSens,
                THighSens,
                RigiditySensetivity>(rawValues.RigiditySensetivity);
            Selfcontrol = CreateCharacter<TLowSelf,
                TMidSelf,
                THighSelf,
                Selfcontrol>(rawValues.Selfcontrol);
            StraightforwardnessDiplomacy = CreateCharacter<TLowDipl,
                TMidDipl,
                THighDipl,
                StraightforwardnessDiplomacy>(rawValues.StraightforwardnessDiplomacy);
            SubordinationDomination = CreateCharacter<TLowDom,
                TMidDom,
                THighDom,
                SubordinationDomination>(rawValues.SubordinationDomination);
            TimidityCourage = CreateCharacter<TLowCour,
                TMidCour,
                THighCour,
                TimidityCourage>(rawValues.TimidityCourage);
        }

        public CalmnessAnxiety CalmnessAnxiety
        { get => calmnessAnxiety; private set => calmnessAnxiety = value; }

        public ClosenessSociability ClosenessSociability
        { get => closenessSociability; private set => closenessSociability = value; }

        public ConformismNonconformism ConformismNonconformism
        { get => conformismNonconformism; private set => conformismNonconformism = value; }

        public ConservatismRadicalism ConservatismRadicalism
        { get => conservatismRadicalism; private set => conservatismRadicalism = value; }

        public CredulitySuspicion CredulitySuspicion
        { get => credulitySuspicion; private set => credulitySuspicion = value; }

        public EmotionalInstabilityStability EmotionalInstabilityStability
        { get => emotionalInstabilityStability; private set => emotionalInstabilityStability = value; }

        public Intelligence Intelligence
        { get => intelligence; private set => intelligence = value; }

        public NormativityOfBehaviour NormativityOfBehaviour
        { get => normativityOfBehaviour; private set => normativityOfBehaviour = value; }

        public PracticalityDreaminess PracticalityDreaminess
        { get => practicalityDreaminess; private set => practicalityDreaminess = value; }

        public RelaxationTension RelaxationTension
        { get => relaxationTension; private set => relaxationTension = value; }

        public RestraintExpressiveness RestraintExpressiveness
        { get => restraintExpressiveness; private set => restraintExpressiveness = value; }

        public RigiditySensetivity RigiditySensetivity
        { get => rigiditySensetivity; private set => rigiditySensetivity = value; }

        public Selfcontrol Selfcontrol
        { get => selfcontrol; private set => selfcontrol = value; }

        public StraightforwardnessDiplomacy StraightforwardnessDiplomacy
        { get => straightforwardnessDiplomacy; private set => straightforwardnessDiplomacy = value; }

        public SubordinationDomination SubordinationDomination
        { get => subordinationDomination; private set => subordinationDomination = value; }

        public TimidityCourage TimidityCourage
        { get => timidityCourage; private set => timidityCourage = value; }

        public CharacterTraitBase this[int index]
        {
            get { return characterTraits[index]; }
            set { characterTraits[index] = value; }
        }

        public IEnumerator<CharacterTraitBase> GetEnumerator() =>
            characterTraits.GetEnumerator();

        public void Initiate<
            TLowAnx, TMidAnx, THighAnx,
            TLowSoc, TMidSoc, THighSoc,
            TLowStab, TMidStab, THighStab,
            TLowNonc, TMidNonc, THighNonc,
            TLowNorm, TMidNorm, THighNorm,
            TLowRad, TMidRad, THighRad,
            TLowSelf, TMidSelf, THighSelf,
            TLowSens, TMidSens, THighSens,
            TLowSusp, TMidSusp, THighSusp,
            TLowTens, TMidTens, THighTens,
            TLowExpre, TMidExpre, THighExpre,
            TLowInt, TMidInt, THighInt,
            TLowDrea, TMidDrea, THighDrea,
            TLowDom, TMidDom, THighDom,
            TLowDipl, TMidDipl, THighDipl,
            TLowCour, TMidCour, THighCour
            >
            (IRawCharacterInfoSource rawValues)
            where TLowAnx : LowAnxiety
            where TMidAnx : MiddleAnxiety
            where THighAnx : HighAnxiety

            where TLowSoc : LowClosenessSociability
            where TMidSoc : MiddleClosenessSociability
            where THighSoc : HighClosenessSociability

            where TLowStab : LowEmotionalStability
            where TMidStab :              MiddleEmotionalStability
            where THighStab : HighEmotionalStability

            where TLowNonc : LowNonconformism
            where TMidNonc : MiddleNonconformism
            where THighNonc : HighNonconformism

            where TLowNorm : LowNormativityOfBehaviour
            where TMidNorm : MiddleNormativityOfBehaviour
            where THighNorm : HighNormativityOfBehaviour

            where TLowRad : LowRadicalism
            where TMidRad : MiddleRadicalism
            where THighRad : HighRadicalism

            where TLowSelf : LowSelfcontrol
            where TMidSelf : MiddleSelfcontrol
            where THighSelf : HighSelfcontrol

            where TLowSens : LowSensetivity
            where TMidSens : MiddleSensetivity
            where THighSens : HighSensetivity

            where TLowSusp : LowSuspicion
            where TMidSusp : MiddleSuspicion
            where THighSusp : HighSuspicion

            where TLowTens : LowTension
            where TMidTens : MiddleTension
            where THighTens : HighTension

            where TLowExpre : LowExpressiveness
            where TMidExpre : MiddleExpressiveness
            where THighExpre : HighExpressiveness

            where TLowInt : LowIntelligence
            where TMidInt : MiddleIntelligence
            where THighInt : HighIntelligence

            where TLowDrea : LowDreaminess
            where TMidDrea : MiddleDreaminess
            where THighDrea : HighDreaminess

            where TLowDom : LowDomination
            where TMidDom : MiddleDomination
            where THighDom : HighDomination

            where TLowDipl : LowDiplomacy
            where TMidDipl : MiddleDiplomacy
            where THighDipl : HighDiplomacy

            where TLowCour : LowCourage
            where TMidCour : MiddleCourage
            where THighCour : HighCourage
        {
            InitFromRawValues<
            TLowAnx, TMidAnx, THighAnx,
            TLowSoc, TMidSoc, THighSoc,
            TLowStab, TMidStab, THighStab,
            TLowNonc, TMidNonc, THighNonc,
            TLowNorm, TMidNorm, THighNorm,
            TLowRad, TMidRad, THighRad,
            TLowSelf, TMidSelf, THighSelf,
            TLowSens, TMidSens, THighSens,
            TLowSusp, TMidSusp, THighSusp,
            TLowTens, TMidTens, THighTens,
            TLowExpre, TMidExpre, THighExpre,
            TLowInt, TMidInt, THighInt,
            TLowDrea, TMidDrea, THighDrea,
            TLowDom, TMidDom, THighDom,
            TLowDipl, TMidDipl, THighDipl,
            TLowCour, TMidCour, THighCour
            >(rawValues);
        }

        public void RemoveTraits()
        {
            var c = characterTraits.Count;
            for (int i = 0; i < c; i++)
            {
                Destroy(characterTraits[i]);
            }
            characterTraits.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(CalmnessAnxiety.ToString() + "\n");
            sb.Append(ClosenessSociability.ToString() + "\n");
            sb.Append(ConformismNonconformism.ToString() + "\n");
            sb.Append(ConservatismRadicalism.ToString() + "\n");
            sb.Append(CredulitySuspicion.ToString() + "\n");
            sb.Append(EmotionalInstabilityStability.ToString() + "\n");
            sb.Append(Intelligence.ToString() + "\n");
            sb.Append(NormativityOfBehaviour.ToString() + "\n");
            sb.Append(PracticalityDreaminess.ToString() + "\n");
            sb.Append(RelaxationTension.ToString() + "\n");
            sb.Append(RestraintExpressiveness.ToString() + "\n");
            sb.Append(RigiditySensetivity.ToString() + "\n");
            sb.Append(Selfcontrol.ToString() + "\n");
            sb.Append(StraightforwardnessDiplomacy.ToString() + "\n");
            sb.Append(SubordinationDomination.ToString() + "\n");
            sb.Append(TimidityCourage.ToString() + "\n");
            return sb.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return characterTraits.GetEnumerator();
        }
    }
}