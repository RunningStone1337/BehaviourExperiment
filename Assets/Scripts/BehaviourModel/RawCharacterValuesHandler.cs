using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BehaviourModel
{
    public class RawCharacterValuesHandler : MonoBehaviour, IRawCharacterInfoSource
    {
        [SerializeField] [Range(1, 10)] int calmnessAnxiety;
        [SerializeField] [Range(1, 10)] int closenessSociability;
        [SerializeField] [Range(1, 10)] int conformismNonconformism;
        [SerializeField] [Range(1, 10)] int conservatismRadicalism;
        [SerializeField] [Range(1, 10)] int credulitySuspicion;
        [SerializeField] [Range(1, 10)] int emotionalInstabilityStability;
        [SerializeField] [Range(1, 10)] int intelligence;
        [SerializeField] [Range(1, 10)] int normativityOfBehaviour;
        [SerializeField] [Range(1, 10)] int practicalityDreaminess;
        [SerializeField] [Range(1, 10)] int relaxationTension;
        [SerializeField] [Range(1, 10)] int restraintExpressiveness;
        [SerializeField] [Range(1, 10)] int rigiditySensetivity;
        [SerializeField] [Range(1, 10)] int selfcontrol;
        [SerializeField] [Range(1, 10)] int straightforwardnessDiplomacy;
        [SerializeField] [Range(1, 10)] int subordinationDomination;
        [SerializeField] [Range(1, 10)] int timidityCourage;
        public int CalmnessAnxiety { get => calmnessAnxiety; set => calmnessAnxiety = Mathf.Clamp(value,1, 10); }
        public int ClosenessSociability { get => closenessSociability; set => closenessSociability = Mathf.Clamp(value, 1, 10); }
        public int ConformismNonconformism { get => conformismNonconformism; set => conformismNonconformism = Mathf.Clamp(value, 1, 10); }
        public int ConservatismRadicalism { get => conservatismRadicalism; set => conservatismRadicalism = Mathf.Clamp(value, 1, 10); }
        public int CredulitySuspicion { get => credulitySuspicion; set => credulitySuspicion = Mathf.Clamp(value, 1, 10); }
        public int EmotionalInstabilityStability { get => emotionalInstabilityStability; set => emotionalInstabilityStability = Mathf.Clamp(value, 1, 10); }
        public int Intelligence { get => intelligence; set => intelligence = Mathf.Clamp(value, 1, 10); }
        public int NormativityOfBehaviour { get => normativityOfBehaviour; set => normativityOfBehaviour = Mathf.Clamp(value, 1, 10); }
        public int PracticalityDreaminess { get => practicalityDreaminess; set => practicalityDreaminess = Mathf.Clamp(value, 1, 10); }
        public int RelaxationTension { get => relaxationTension; set => relaxationTension = Mathf.Clamp(value, 1, 10); }
        public int RestraintExpressiveness { get => restraintExpressiveness; set => restraintExpressiveness = Mathf.Clamp(value, 1, 10); }
        public int RigiditySensetivity { get => rigiditySensetivity; set => rigiditySensetivity = Mathf.Clamp(value, 1, 10); }
        public int Selfcontrol { get => selfcontrol; set => selfcontrol = Mathf.Clamp(value, 1, 10); }
        public int StraightforwardnessDiplomacy { get => straightforwardnessDiplomacy; set => straightforwardnessDiplomacy = Mathf.Clamp(value, 1, 10); }
        public int SubordinationDomination { get => subordinationDomination; set => subordinationDomination = Mathf.Clamp(value, 1, 10); }
        public int TimidityCourage { get => timidityCourage; set => timidityCourage = Mathf.Clamp(value, 1, 10); }
        public void Randomize()
        {
            CalmnessAnxiety = Random.Range(1, 11);
            ClosenessSociability = Random.Range(1, 11);
            ConformismNonconformism = Random.Range(1, 11);
            ConservatismRadicalism = Random.Range(1, 11);
            CredulitySuspicion = Random.Range(1, 11);
            EmotionalInstabilityStability = Random.Range(1, 11);
            Intelligence = Random.Range(1, 11);
            NormativityOfBehaviour = Random.Range(1, 11);
            PracticalityDreaminess = Random.Range(1, 11);
            RelaxationTension = Random.Range(1, 11);
            RestraintExpressiveness = Random.Range(1, 11);
            RigiditySensetivity = Random.Range(1, 11);
            Selfcontrol = Random.Range(1, 11);
            StraightforwardnessDiplomacy = Random.Range(1, 11);
            SubordinationDomination = Random.Range(1, 11);
            TimidityCourage = Random.Range(1, 11);
        }

    }
}