using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BehaviourModel
{
    public class CharacterSystem<TAgent, TReaction, TFeature, TState, TSensor> : SystemBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IEnumerable<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
        where TAgent : ICurrentStateHandler<TState>
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState 
        where TSensor : ISensor
    {
        [SerializeField] private CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> calmnessAnxiety;
        [SerializeField] [HideInInspector] private List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>> characterTraits;
        [SerializeField] private ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> closenessSociability;
        [SerializeField] private ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> conformismNonconformism;
        [SerializeField] private ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> conservatismRadicalism;
        [SerializeField] private CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> credulitySuspicion;
        [SerializeField] private EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> emotionalInstabilityStability;
        [SerializeField] private Intelligence<TAgent, TReaction, TFeature, TState, TSensor> intelligence;
        [SerializeField] private NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> normativityOfBehaviour;
        [SerializeField] private PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> practicalityDreaminess;
        [SerializeField] private RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> relaxationTension;
        [SerializeField] private RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> restraintExpressiveness;
        [SerializeField] private RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> rigiditySensetivity;
        [SerializeField] private Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> selfcontrol;
        [SerializeField] private StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> straightforwardnessDiplomacy;
        [SerializeField] private SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> subordinationDomination;
        [SerializeField] private TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> timidityCourage;

        private void Awake()
        {
            characterTraits = new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>();
        }

        private TRes CreateCharacter<TLow, TMid, THigh, TRes>(int characterValue)
                    where TLow : TRes
            where TMid : TRes
            where THigh : TRes
            where TRes : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>
        {
            TRes res = null;
            var range = Enumerable.Range(1, 3);
            if (range.Contains(characterValue))
                //res = new TLow();
                res = gameObject.AddComponent<TLow>();
            range = Enumerable.Range(4, 4);
            if (range.Contains(characterValue))
                //res = new TMid();
                res = gameObject.AddComponent<TMid>();
            range = Enumerable.Range(8, 3);
            if (range.Contains(characterValue))
                //res = new THigh();
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
             where TLowAnx : LowAnxiety<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidAnx : MiddleAnxiety<TAgent, TReaction, TFeature, TState, TSensor>
            where THighAnx : HighAnxiety<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSoc : LowClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSoc : MiddleClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSoc : HighClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowStab : LowEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidStab : MiddleEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>
            where THighStab : HighEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowNonc : LowNonconformism<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidNonc : MiddleNonconformism<TAgent, TReaction, TFeature, TState, TSensor>
            where THighNonc : HighNonconformism<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowNorm : LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidNorm : MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>
            where THighNorm : HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowRad : LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidRad : MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>
            where THighRad : HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSelf : LowSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSelf : MiddleSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSelf : HighSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSens : LowSensetivity<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSens : MiddleSensetivity<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSens : HighSensetivity<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSusp : LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSusp : MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSusp : HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowTens : LowTension<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidTens : MiddleTension<TAgent, TReaction, TFeature, TState, TSensor>
            where THighTens : HighTension<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowExpre : LowExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidExpre : MiddleExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>
            where THighExpre : HighExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowInt : LowIntelligence<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidInt : MiddleIntelligence<TAgent, TReaction, TFeature, TState, TSensor>
            where THighInt : HighIntelligence<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowDrea : LowDreaminess<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidDrea : MiddleDreaminess<TAgent, TReaction, TFeature, TState, TSensor>
            where THighDrea : HighDreaminess<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowDom : LowDomination<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidDom : MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>
            where THighDom : HighDomination<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowDipl : LowDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidDipl : MiddleDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>
            where THighDipl : HighDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowCour : LowCourage<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidCour : MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>
            where THighCour : HighCourage<TAgent, TReaction, TFeature, TState, TSensor>
        {
            CalmnessAnxiety = CreateCharacter<TLowAnx,
                TMidAnx,
                THighAnx,
                CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.CalmnessAnxiety);
            ClosenessSociability = CreateCharacter<TLowSoc,
                TMidSoc,
                THighSoc,
                ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.ClosenessSociability);
            ConformismNonconformism = CreateCharacter<TLowNonc,
                TMidNonc,
                THighNonc,
                ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.ConformismNonconformism);
            ConservatismRadicalism = CreateCharacter<TLowRad,
                TMidRad,
                THighRad,
                ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.ConservatismRadicalism);
            CredulitySuspicion = CreateCharacter<TLowSusp,
                TMidSusp,
                THighSusp,
                CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.CredulitySuspicion);
            EmotionalInstabilityStability = CreateCharacter<TLowStab,
                TMidStab,
                THighStab,
                EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.EmotionalInstabilityStability);
            Intelligence = CreateCharacter<TLowInt,
                TMidInt,
                THighInt,
                Intelligence<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.Intelligence);
            NormativityOfBehaviour = CreateCharacter<TLowNorm,
                TMidNorm,
                THighNorm,
                NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.NormativityOfBehaviour);
            PracticalityDreaminess = CreateCharacter<TLowDrea,
                TMidDrea,
                THighDrea,
                PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.PracticalityDreaminess);
            RelaxationTension = CreateCharacter<TLowTens,
                TMidTens,
                THighTens,
                RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.RelaxationTension);
            RestraintExpressiveness = CreateCharacter<TLowExpre,
                TMidExpre,
                THighExpre,
                RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.RestraintExpressiveness);
            RigiditySensetivity = CreateCharacter<TLowSens,
                TMidSens,
                THighSens,
                RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.RigiditySensetivity);
            Selfcontrol = CreateCharacter<TLowSelf,
                TMidSelf,
                THighSelf,
                Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.Selfcontrol);
            StraightforwardnessDiplomacy = CreateCharacter<TLowDipl,
                TMidDipl,
                THighDipl,
                StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.StraightforwardnessDiplomacy);
            SubordinationDomination = CreateCharacter<TLowDom,
                TMidDom,
                THighDom,
                SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.SubordinationDomination);
            TimidityCourage = CreateCharacter<TLowCour,
                TMidCour,
                THighCour,
                TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>(rawValues.TimidityCourage);
        }

        public CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> CalmnessAnxiety
        { get => calmnessAnxiety; private set => calmnessAnxiety = value; }

        public ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> ClosenessSociability
        { get => closenessSociability; private set => closenessSociability = value; }

        public ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> ConformismNonconformism
        { get => conformismNonconformism; private set => conformismNonconformism = value; }

        public ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> ConservatismRadicalism
        { get => conservatismRadicalism; private set => conservatismRadicalism = value; }

        public CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> CredulitySuspicion
        { get => credulitySuspicion; private set => credulitySuspicion = value; }

        public EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> EmotionalInstabilityStability
        { get => emotionalInstabilityStability; private set => emotionalInstabilityStability = value; }

        public Intelligence<TAgent, TReaction, TFeature, TState, TSensor> Intelligence
        { get => intelligence; private set => intelligence = value; }

        public NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> NormativityOfBehaviour
        { get => normativityOfBehaviour; private set => normativityOfBehaviour = value; }

        public PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> PracticalityDreaminess
        { get => practicalityDreaminess; private set => practicalityDreaminess = value; }

        public RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> RelaxationTension
        { get => relaxationTension; private set => relaxationTension = value; }

        public RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> RestraintExpressiveness
        { get => restraintExpressiveness; private set => restraintExpressiveness = value; }

        public RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> RigiditySensetivity
        { get => rigiditySensetivity; private set => rigiditySensetivity = value; }

        public Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> Selfcontrol
        { get => selfcontrol; private set => selfcontrol = value; }

        public StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> StraightforwardnessDiplomacy
        { get => straightforwardnessDiplomacy; private set => straightforwardnessDiplomacy = value; }

        public SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> SubordinationDomination
        { get => subordinationDomination; private set => subordinationDomination = value; }

        public TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> TimidityCourage
        { get => timidityCourage; private set => timidityCourage = value; }

        public CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor> this[int index]
        {
            get { return characterTraits[index]; }
            set { characterTraits[index] = value; }
        }

        public IEnumerator<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>> GetEnumerator() =>
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
            where TLowAnx : LowAnxiety<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidAnx : MiddleAnxiety<TAgent, TReaction, TFeature, TState, TSensor>
            where THighAnx : HighAnxiety<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSoc : LowClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSoc : MiddleClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSoc : HighClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowStab : LowEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidStab : MiddleEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>
            where THighStab : HighEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowNonc : LowNonconformism<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidNonc : MiddleNonconformism<TAgent, TReaction, TFeature, TState, TSensor>
            where THighNonc : HighNonconformism<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowNorm : LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidNorm : MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>
            where THighNorm : HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowRad : LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidRad : MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>
            where THighRad : HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSelf : LowSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSelf : MiddleSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSelf : HighSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSens : LowSensetivity<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSens : MiddleSensetivity<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSens : HighSensetivity<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSusp : LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSusp : MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSusp : HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowTens : LowTension<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidTens : MiddleTension<TAgent, TReaction, TFeature, TState, TSensor>
            where THighTens : HighTension<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowExpre : LowExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidExpre : MiddleExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>
            where THighExpre : HighExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowInt : LowIntelligence<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidInt : MiddleIntelligence<TAgent, TReaction, TFeature, TState, TSensor>
            where THighInt : HighIntelligence<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowDrea : LowDreaminess<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidDrea : MiddleDreaminess<TAgent, TReaction, TFeature, TState, TSensor>
            where THighDrea : HighDreaminess<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowDom : LowDomination<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidDom : MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>
            where THighDom : HighDomination<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowDipl : LowDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidDipl : MiddleDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>
            where THighDipl : HighDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowCour : LowCourage<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidCour : MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>
            where THighCour : HighCourage<TAgent, TReaction, TFeature, TState, TSensor>
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