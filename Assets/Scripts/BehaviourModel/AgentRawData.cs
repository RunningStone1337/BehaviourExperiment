using System;
using System.Collections.Generic;
using UI;

namespace BehaviourModel
{
    public enum NervousSystemType
    {
        Balanced,
        Braked,
        Excitable
    }
    [Serializable]
    public class AgentRawData
    {
        public int imageID;
        public int ImageID { get => imageID; }
        public string agentName;
        public string AgentName { get => agentName; }
        public bool sex;
        public bool Sex { get => sex; }
        public ushort age;
        public ushort Age { get => age; }
        public ushort weight;
        public ushort Weight { get => weight; }
        public ushort height;
        public ushort Height { get => height; }

        public ushort nsPower;
        public ushort NsPower { get => nsPower; }
        public ushort nsMoveability;
        public ushort NsMoveability { get => nsMoveability; }
        public ushort nsActivity;
        public ushort NsActivity { get => nsActivity; }
        public ushort nsReactivity;
        public ushort NsReactivity { get => nsReactivity; }
        public NervousSystemType nsType;
        public NervousSystemType NsType { get => nsType; }

        public ushort closenessSociability;
        public ushort ClosenessSociability { get => closenessSociability; }
        public ushort calmnessAnxiety;
        public ushort CalmnessAnxiety { get => calmnessAnxiety; }
        public ushort conformismNonconformism;
        public ushort ConformismNonconformism { get => conformismNonconformism; }
        public ushort conservatismRadicalism;
        public ushort ConservatismRadicalism { get => conservatismRadicalism; }
        public ushort credulitySuspicion;
        public ushort CredulitySuspicion { get => credulitySuspicion; }
        public ushort emotionalInstabilityStability;
        public ushort EmotionalInstabilityStability { get => emotionalInstabilityStability; }
        public ushort intelligence;
        public ushort Intelligence { get => intelligence; }
        public ushort normativityOfBehaviour;
        public ushort NormativityOfBehaviour { get => normativityOfBehaviour; }
        public ushort practicalityDreaminess;
        public ushort PracticalityDreaminess { get => practicalityDreaminess; }
        public ushort relaxationTension;
        public ushort RelaxationTension { get => relaxationTension; }
        public ushort restraintExpressiveness;
        public ushort RestraintExpressiveness { get => restraintExpressiveness; }
        public ushort rigiditySensetivity;
        public ushort RigiditySensetivity { get => rigiditySensetivity; }
        public ushort selfcontrol;
        public ushort Selfcontrol { get => selfcontrol; }
        public ushort straightforwardnessDiplomacy;
        public ushort StraightforwardnessDiplomacy { get => straightforwardnessDiplomacy; }
        public ushort subordinationDomination;
        public ushort SubordinationDomination { get => subordinationDomination; }
        public ushort timidityCourage;
        public ushort TimidityCourage { get => timidityCourage; }

        public List<FeatureBase> features;
        public void Initiate(AgentCreationScreen acs)
        {
            imageID = acs.AgentImageHandler.ImageID;
            agentName = acs.NameInputFieldButtonPair.InputField.text;
            sex = acs.SexDropButtonPair.DropdownValue == "ì";
            age = Convert.ToUInt16(ushort.Parse(acs.AgeDropButtonPair.DropdownValue));
            weight = Convert.ToUInt16(ushort.Parse(acs.WeightDropButtonPair.DropdownValue));
            height = Convert.ToUInt16(ushort.Parse(acs.HeightDropButtonPair.DropdownValue));

            nsPower = Convert.ToUInt16(acs.NervousSystemRect.NsPowerSlider.Value);
            nsMoveability = Convert.ToUInt16(acs.NervousSystemRect.NsMoveabilitySlider.Value);
            nsActivity = Convert.ToUInt16(acs.NervousSystemRect.NsActivitySlider.Value);
            nsReactivity = Convert.ToUInt16(acs.NervousSystemRect.NsReactivitySlider.Value);
            nsType = GetNSType(acs.NervousSystemRect.NsBalanceDropButtonPair.DropdownIndex);

            closenessSociability = Convert.ToUInt16(acs.CharacterRect.ClosenessSociabilitySlider.Value);
            calmnessAnxiety = Convert.ToUInt16(acs.CharacterRect.CalmnessAnxietySlider.Value);
            conformismNonconformism = Convert.ToUInt16(acs.CharacterRect.ConformismNonconformismSlider.Value);
            conservatismRadicalism = Convert.ToUInt16(acs.CharacterRect.ConservatismRadicalismSlider.Value);
            credulitySuspicion = Convert.ToUInt16(acs.CharacterRect.CredulitySuspicionSlider.Value);
            emotionalInstabilityStability = Convert.ToUInt16(acs.CharacterRect.EmotionalInstabilityStabilitySlider.Value);
            intelligence = Convert.ToUInt16(acs.CharacterRect.IntelligenceSlider.Value);
            normativityOfBehaviour = Convert.ToUInt16(acs.CharacterRect.NormativityOfBehaviourSlider.Value);
            practicalityDreaminess = Convert.ToUInt16(acs.CharacterRect.PracticalityDreaminessSlider.Value);
            relaxationTension = Convert.ToUInt16(acs.CharacterRect.RelaxationTensionSlider.Value);
            restraintExpressiveness = Convert.ToUInt16(acs.CharacterRect.RestraintExpressivenessSlider.Value);
            rigiditySensetivity = (ushort)acs.CharacterRect.RigiditySensetivitySlider.Value;
            selfcontrol = Convert.ToUInt16(acs.CharacterRect.SelfcontrolSlider.Value);
            straightforwardnessDiplomacy = Convert.ToUInt16(acs.CharacterRect.StraightforwardnessDiplomacySlider.Value);
            subordinationDomination = Convert.ToUInt16(acs.CharacterRect.SubordinationDominationSlider.Value);
            timidityCourage = Convert.ToUInt16(acs.CharacterRect.TimidityCourageSlider.Value);

            features = acs.FeaturesRect.SelectedFeatures;
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