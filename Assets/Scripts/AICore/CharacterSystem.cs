using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Система приобретённых особенностей человека, формы проявления
    /// импульсов нервной системы, возникающих вследствие внешних или внутренних или
    ///  факторов.
    /// </summary>
    public class CharacterSystem<TReaction, TFeature, TState> : SystemBase<TReaction, TFeature, TState>,
        IEnumerable<CharacterTraitBase<TReaction, TFeature, TState>>
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
    {
        [SerializeField] [HideInInspector] private List<CharacterTraitBase<TReaction, TFeature, TState>> characterTraits;
        [SerializeField] private CalmnessAnxiety<TReaction, TFeature, TState> calmnessAnxiety;
        [SerializeField] private ClosenessSociability<TReaction, TFeature, TState> closenessSociability;
        [SerializeField] private ConformismNonconformism<TReaction, TFeature, TState> conformismNonconformism;
        [SerializeField] private ConservatismRadicalism<TReaction, TFeature, TState> conservatismRadicalism;
        [SerializeField] private CredulitySuspicion<TReaction, TFeature, TState> credulitySuspicion;
        [SerializeField] private EmotionalInstabilityStability<TReaction, TFeature, TState> emotionalInstabilityStability;
        [SerializeField] private Intelligence<TReaction, TFeature, TState> intelligence;
        [SerializeField] private NormativityOfBehaviour<TReaction, TFeature, TState> normativityOfBehaviour;
        [SerializeField] private PracticalityDreaminess<TReaction, TFeature, TState> practicalityDreaminess;
        [SerializeField] private RelaxationTension<TReaction, TFeature, TState> relaxationTension;
        [SerializeField] private RestraintExpressiveness<TReaction, TFeature, TState> restraintExpressiveness;
        [SerializeField] private RigiditySensetivity<TReaction, TFeature, TState> rigiditySensetivity;
        [SerializeField] private Selfcontrol<TReaction, TFeature, TState> selfcontrol;
        [SerializeField] private StraightforwardnessDiplomacy<TReaction, TFeature, TState> straightforwardnessDiplomacy;
        [SerializeField] private SubordinationDomination<TReaction, TFeature, TState> subordinationDomination;
        [SerializeField] private TimidityCourage<TReaction, TFeature, TState> timidityCourage;

        private TRes CreateCharacter<TLow, TMid, THigh, TRes>(int characterValue)
            where TLow : TRes
            where TMid : TRes
            where THigh : TRes
            where TRes : CharacterTraitBase<TReaction, TFeature, TState>
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

        public CalmnessAnxiety<TReaction, TFeature, TState> CalmnessAnxiety { get => CalmnessAnxiety; private set => CalmnessAnxiety = value; }

        public ClosenessSociability<TReaction, TFeature, TState> ClosenessSociability { get => closenessSociability; private set => closenessSociability = value; }

        public ConformismNonconformism<TReaction, TFeature, TState> ConformismNonconformism { get => conformismNonconformism; private set => conformismNonconformism = value; }

        public ConservatismRadicalism<TReaction, TFeature, TState> ConservatismRadicalism { get => conservatismRadicalism; private set => conservatismRadicalism = value; }

        public CredulitySuspicion<TReaction, TFeature, TState> CredulitySuspicion { get => credulitySuspicion; private set => credulitySuspicion = value; }

        public EmotionalInstabilityStability<TReaction, TFeature, TState> EmotionalInstabilityStability { get => emotionalInstabilityStability; private set => emotionalInstabilityStability = value; }

        public Intelligence<TReaction, TFeature, TState> Intelligence { get => intelligence; private set => intelligence = value; }

        public NormativityOfBehaviour<TReaction, TFeature, TState> NormativityOfBehaviour { get => normativityOfBehaviour; private set => normativityOfBehaviour = value; }

        public PracticalityDreaminess<TReaction, TFeature, TState> PracticalityDreaminess { get => practicalityDreaminess; private set => practicalityDreaminess = value; }

        public RelaxationTension<TReaction, TFeature, TState> RelaxationTension { get => relaxationTension; private set => relaxationTension = value; }

        public RestraintExpressiveness<TReaction, TFeature, TState> RestraintExpressiveness { get => restraintExpressiveness; private set => restraintExpressiveness = value; }

        public RigiditySensetivity<TReaction, TFeature, TState> RigiditySensetivity { get => rigiditySensetivity; private set => rigiditySensetivity = value; }

        public Selfcontrol<TReaction, TFeature, TState> Selfcontrol { get => selfcontrol; private set => selfcontrol = value; }

        public StraightforwardnessDiplomacy<TReaction, TFeature, TState> StraightforwardnessDiplomacy { get => straightforwardnessDiplomacy; private set => straightforwardnessDiplomacy = value; }

        public SubordinationDomination<TReaction, TFeature, TState> SubordinationDomination { get => subordinationDomination; private set => subordinationDomination = value; }

        public TimidityCourage<TReaction, TFeature, TState> TimidityCourage { get => timidityCourage; private set => timidityCourage = value; }

        public CharacterTraitBase<TReaction, TFeature, TState> this[int index]
        {
            get { return characterTraits[index]; }
            set { characterTraits[index] = value; }
        }

        public IEnumerator<CharacterTraitBase<TReaction, TFeature, TState>> GetEnumerator()=>
            characterTraits.GetEnumerator();

        public void Initiate(IRawCharacterInfoSource rawValues)
        {
            InitFromRawValues(rawValues);
        }

        private void InitFromRawValues(IRawCharacterInfoSource rawValues)
        {
            CalmnessAnxiety = CreateCharacter<LowAnxiety<TReaction, TFeature, TState>,
                MiddleAnxiety<TReaction, TFeature, TState>,
                HighAnxiety<TReaction, TFeature, TState>,
                CalmnessAnxiety<TReaction, TFeature, TState>>(rawValues.CalmnessAnxiety);
            ClosenessSociability = CreateCharacter<LowClosenessSociability<TReaction, TFeature, TState>,
                MiddleClosenessSociability<TReaction, TFeature, TState>,
                HighClosenessSociability<TReaction, TFeature, TState>,
                ClosenessSociability<TReaction, TFeature, TState>>(rawValues.ClosenessSociability);
            ConformismNonconformism = CreateCharacter<LowNonconformism<TReaction, TFeature, TState>,
                MiddleNonconformism<TReaction, TFeature, TState>,
                HighNonconformism<TReaction, TFeature, TState>,
                ConformismNonconformism<TReaction, TFeature, TState>>(rawValues.ConformismNonconformism);
            ConservatismRadicalism = CreateCharacter<LowRadicalism<TReaction, TFeature, TState>,
                MiddleRadicalism<TReaction, TFeature, TState>,
                HighRadicalism<TReaction, TFeature, TState>,
                ConservatismRadicalism<TReaction, TFeature, TState>>(rawValues.ConservatismRadicalism);
            CredulitySuspicion = CreateCharacter<LowSuspicion<TReaction, TFeature, TState>,
                MiddleSuspicion<TReaction, TFeature, TState>,
                HighSuspicion<TReaction, TFeature, TState>,
                CredulitySuspicion<TReaction, TFeature, TState>>(rawValues.CredulitySuspicion);
            EmotionalInstabilityStability = CreateCharacter<LowEmotionalStability<TReaction, TFeature, TState>,
                MiddleEmotionalStability<TReaction, TFeature, TState>,
                HighEmotionalStability<TReaction, TFeature, TState>,
                EmotionalInstabilityStability<TReaction, TFeature, TState>>(rawValues.EmotionalInstabilityStability);
            Intelligence = CreateCharacter<LowIntelligence<TReaction, TFeature, TState>,
                MiddleIntelligence<TReaction, TFeature, TState>,
                HighIntelligence<TReaction, TFeature, TState>,
                Intelligence<TReaction, TFeature, TState>>(rawValues.Intelligence);
            NormativityOfBehaviour = CreateCharacter<LowNormativityOfBehaviour<TReaction, TFeature, TState>,
                MiddleNormativityOfBehaviour<TReaction, TFeature, TState>,
                HighNormativityOfBehaviour<TReaction, TFeature, TState>,
                NormativityOfBehaviour<TReaction, TFeature, TState>>(rawValues.NormativityOfBehaviour);
            PracticalityDreaminess = CreateCharacter<LowDreaminess<TReaction, TFeature, TState>,
                MiddleDreaminess<TReaction, TFeature, TState>,
                HighDreaminess<TReaction, TFeature, TState>,
                PracticalityDreaminess<TReaction, TFeature, TState>>(rawValues.PracticalityDreaminess);
            RelaxationTension = CreateCharacter<LowTension<TReaction, TFeature, TState>,
                MiddleTension<TReaction, TFeature, TState>,
                HighTension<TReaction, TFeature, TState>,
                RelaxationTension<TReaction, TFeature, TState>>(rawValues.RelaxationTension);
            RestraintExpressiveness = CreateCharacter<LowExpressiveness<TReaction, TFeature, TState>,
                MiddleExpressiveness<TReaction, TFeature, TState>,
                HighExpressiveness<TReaction, TFeature, TState>,
                RestraintExpressiveness<TReaction, TFeature, TState>>(rawValues.RestraintExpressiveness);
            RigiditySensetivity = CreateCharacter<LowSensetivity<TReaction, TFeature, TState>,
                MiddleSensetivity<TReaction, TFeature, TState>,
                HighSensetivity<TReaction, TFeature, TState>,
                RigiditySensetivity<TReaction, TFeature, TState>>(rawValues.RigiditySensetivity);
            Selfcontrol = CreateCharacter<LowSelfcontrol<TReaction, TFeature, TState>,
                MiddleSelfcontrol<TReaction, TFeature, TState>,
                HighSelfcontrol<TReaction, TFeature, TState>,
                Selfcontrol<TReaction, TFeature, TState>>(rawValues.Selfcontrol);
            StraightforwardnessDiplomacy = CreateCharacter<LowDiplomacy<TReaction, TFeature, TState>,
                MiddleDiplomacy<TReaction, TFeature, TState>,
                HighDiplomacy<TReaction, TFeature, TState>,
                StraightforwardnessDiplomacy<TReaction, TFeature, TState>>(rawValues.StraightforwardnessDiplomacy);
            SubordinationDomination = CreateCharacter<LowDomination<TReaction, TFeature, TState>,
                MiddleDomination<TReaction, TFeature, TState>,
                HighDomination<TReaction, TFeature, TState>,
                SubordinationDomination<TReaction, TFeature, TState>>(rawValues.SubordinationDomination);
            TimidityCourage = CreateCharacter<LowCourage<TReaction, TFeature, TState>,
                MiddleCourage<TReaction, TFeature, TState>,
                HighCourage<TReaction, TFeature, TState>,
                TimidityCourage<TReaction, TFeature, TState>>(rawValues.TimidityCourage);
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