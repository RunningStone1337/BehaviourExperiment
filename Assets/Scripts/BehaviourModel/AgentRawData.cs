using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public enum NervousSystemType
    {
        Balanced,
        Braked,
        Excitable
    }
    public class AgentRawData : MonoBehaviour
    {
        ushort imageID;
        public ushort ImageID { get => imageID; }
        string agentName;
        public string AgentName { get => agentName; }
        bool sex;
        public bool Sex { get => sex; }
        ushort age;
        public ushort Age { get => age; }
        ushort weight;
        public ushort Weight { get => weight; }
        ushort height;
        public ushort Height { get => height; }

        ushort nsPower;
        public ushort NsPower { get => nsPower; }
        ushort nsMoveability;
        public ushort NsMoveability { get => nsMoveability; }
        ushort nsActivity;
        public ushort NsActivity { get => nsActivity; }
        ushort nsReactivity;
        public ushort NsReactivity { get => nsReactivity; }
        NervousSystemType nsType;
        public NervousSystemType NsType { get => nsType; }

        ushort closenessSociability;
        public ushort ClosenessSociability { get => closenessSociability; }
        ushort calmnessAnxiety;
        public ushort CalmnessAnxiety { get => calmnessAnxiety; }
        ushort conformismNonconformism;
        public ushort ConformismNonconformism { get => conformismNonconformism; }
        ushort conservatismRadicalism;
        public ushort ConservatismRadicalism { get => conservatismRadicalism; }
        ushort credulitySuspicion;
        public ushort CredulitySuspicion { get => credulitySuspicion; }
        ushort emotionalInstabilityStability;
        public ushort EmotionalInstabilityStability { get => emotionalInstabilityStability; }
        ushort intelligence;
        public ushort Intelligence { get => intelligence; }
        ushort normativityOfBehaviour;
        public ushort NormativityOfBehaviour { get => normativityOfBehaviour; }
        ushort practicalityDreaminess;
        public ushort PracticalityDreaminess { get => practicalityDreaminess; }
        ushort relaxationTension;
        public ushort RelaxationTension { get => relaxationTension; }
        ushort restraintExpressiveness;
        public ushort RestraintExpressiveness { get => restraintExpressiveness; }
        ushort rigiditySensetivity;
        public ushort RigiditySensetivity { get => rigiditySensetivity; }
        ushort selfcontrol;
        public ushort Selfcontrol { get => selfcontrol; }
        ushort straightforwardnessDiplomacy;
        public ushort StraightforwardnessDiplomacy { get => straightforwardnessDiplomacy; }
        ushort subordinationDomination;
        public ushort SubordinationDomination { get => subordinationDomination; }
        ushort timidityCourage;
        public ushort TimidityCourage { get => timidityCourage; }

        //интересы
        public void Initiate(AgentCreationScreen acs)
        {
            imageID = (ushort)acs.AgentImageHandler.ImageID;
            agentName = acs.NameInputFieldButtonPair.InputField.text;
            sex = acs.SexDropButtonPair.DropdownValue == "м";
            age = ushort.Parse(acs.AgeDropButtonPair.DropdownValue);
            weight = ushort.Parse(acs.WeightDropButtonPair.DropdownValue);
            height = ushort.Parse(acs.HeightDropButtonPair.DropdownValue);

            nsPower = (ushort)acs.NsPowerSlider.Value;
            nsMoveability = (ushort)acs.NsMoveabilitySlider.Value;
            nsActivity = (ushort)acs.NsActivitySlider.Value;
            nsReactivity = (ushort)acs.NsReactivitySlider.Value;
            nsType = GetNSType(acs.NsBalanceDropButtonPair.DropdownIndex);

            closenessSociability = (ushort)acs.ClosenessSociabilitySlider.Value;
            calmnessAnxiety = (ushort)acs.CalmnessAnxietySlider.Value;
            conformismNonconformism = (ushort)acs.ConformismNonconformismSlider.Value;
            conservatismRadicalism = (ushort)acs.ConservatismRadicalismSlider.Value;
            credulitySuspicion = (ushort)acs.CredulitySuspicionSlider.Value;
            emotionalInstabilityStability = (ushort)acs.EmotionalInstabilityStabilitySlider.Value;
            intelligence = (ushort)acs.IntelligenceSlider.Value;
            normativityOfBehaviour = (ushort)acs.NormativityOfBehaviourSlider.Value;
            practicalityDreaminess = (ushort)acs.PracticalityDreaminessSlider.Value;
            relaxationTension = (ushort)acs.RelaxationTensionSlider.Value;
            restraintExpressiveness = (ushort)acs.RestraintExpressivenessSlider.Value;
            rigiditySensetivity = (ushort)acs.RigiditySensetivitySlider.Value;
            selfcontrol = (ushort)acs.SelfcontrolSlider.Value;
            straightforwardnessDiplomacy = (ushort)acs.StraightforwardnessDiplomacySlider.Value;
            subordinationDomination = (ushort)acs.SubordinationDominationSlider.Value;
            timidityCourage = (ushort)acs.TimidityCourageSlider.Value;
        }

        private NervousSystemType GetNSType(int dropdownIndex)
        {
            if (dropdownIndex == 0)
                return NervousSystemType.Balanced;
            if (dropdownIndex == 1)
                return NervousSystemType.Excitable;
            if (dropdownIndex == 2)
                return NervousSystemType.Braked;
            throw new Exception($"Unexpected indexValue {dropdownIndex}");
        }
    }
}