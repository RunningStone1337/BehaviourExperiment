using System;
using System.Collections.Generic;
using UI;

namespace BehaviourModel
{
    [Serializable]
    public abstract class HumanRawData
    {
        public ushort age;
        public string agentName;
        public string agentType;
        public ushort calmnessAnxiety;
        public ushort closenessSociability;
        public ushort conformismNonconformism;
        public ushort conservatismRadicalism;
        public ushort credulitySuspicion;
        public ushort emotionalInstabilityStability;
        public List<FeatureBase> features;
        public ushort height;
        public int imageID;
        public ushort intelligence;
        public ushort normativityOfBehaviour;
        public ushort nsActivity;
        public ushort nsMoveability;
        public ushort nsPower;
        public ushort nsReactivity;
        public NervousBalanceType nsType;
        public ushort practicalityDreaminess;
        public ushort relaxationTension;
        public ushort restraintExpressiveness;
        public ushort rigiditySensetivity;
        public ushort selfcontrol;
        public SexBase sex;
        public ushort straightforwardnessDiplomacy;
        public ushort subordinationDomination;
        public ushort timidityCourage;
        public ushort weight;
        public ushort Age { get => age; }
        public string AgentName { get => agentName; }
        public string AgentType => agentType;
        public ushort CalmnessAnxiety { get => calmnessAnxiety; }
        public ushort ClosenessSociability { get => closenessSociability; }
        public ushort ConformismNonconformism { get => conformismNonconformism; }
        public ushort ConservatismRadicalism { get => conservatismRadicalism; }
        public ushort CredulitySuspicion { get => credulitySuspicion; }
        public ushort EmotionalInstabilityStability { get => emotionalInstabilityStability; }
        public ushort Height { get => height; }
        public int ImageID { get => imageID; }
        public ushort Intelligence { get => intelligence; }
        public ushort NormativityOfBehaviour { get => normativityOfBehaviour; }
        public ushort NsActivity { get => nsActivity; }
        public ushort NsMoveability { get => nsMoveability; }
        public ushort NsPower { get => nsPower; }
        public ushort NsReactivity { get => nsReactivity; }
        public NervousBalanceType NsType { get => nsType; }
        public ushort PracticalityDreaminess { get => practicalityDreaminess; }
        public ushort RelaxationTension { get => relaxationTension; }
        public ushort RestraintExpressiveness { get => restraintExpressiveness; }
        public ushort RigiditySensetivity { get => rigiditySensetivity; }
        public ushort Selfcontrol { get => selfcontrol; }
        public SexBase Sex { get => sex; }
        public ushort StraightforwardnessDiplomacy { get => straightforwardnessDiplomacy; }
        public ushort SubordinationDomination { get => subordinationDomination; }
        public ushort TimidityCourage { get => timidityCourage; }
        public ushort Weight { get => weight; }

        public virtual void Initiate(AgentCreationScreen acs)
        {
            imageID = acs.AgentImageHandler.ImageID;
            agentName = acs.NameInputFieldButtonPair.InputField.text;
            agentType = acs.CreatedType.AssemblyQualifiedName;
            sex = acs.SexRect.SelectedSex;
            age = Convert.ToUInt16(ushort.Parse(acs.AgeDropButtonPair.DropdownValue));
            weight = Convert.ToUInt16(ushort.Parse(acs.WeightDropButtonPair.DropdownValue));
            height = Convert.ToUInt16(ushort.Parse(acs.HeightDropButtonPair.DropdownValue));

            nsPower = Convert.ToUInt16(acs.NervousSystemRect.NsPowerSlider.Value);
            nsMoveability = Convert.ToUInt16(acs.NervousSystemRect.NsMoveabilitySlider.Value);
            nsActivity = Convert.ToUInt16(acs.NervousSystemRect.NsActivitySlider.Value);
            nsReactivity = Convert.ToUInt16(acs.NervousSystemRect.NsReactivitySlider.Value);
            nsType = (NervousBalanceType)acs.NervousSystemRect.NsBalanceRect.BalanceDropdownButtonPair.SelectedOptionValue;

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

            features = new List<FeatureBase>(acs.FeaturesRect.SelectedFeatures);
        }
    }
}