using System;
using System.Collections.Generic;
using UI;

namespace BehaviourModel
{
    [Serializable]
    public abstract class HumanRawData:IAgentInitData<FeatureBase>
    {
        public string agentName;
        public string agentType;
        public ushort calmnessAnxiety;
        public ushort closenessSociability;
        public ushort conformismNonconformism;
        public ushort conservatismRadicalism;
        public ushort credulitySuspicion;
        public ushort emotionalInstabilityStability;
        public List<FeatureBase> features;
        public int imageID;
        public ushort intelligence;
        public ushort normativityOfBehaviour;
        public ushort practicalityDreaminess;
        public ushort relaxationTension;
        public ushort restraintExpressiveness;
        public ushort rigiditySensetivity;
        public ushort selfcontrol;
        public SexBase sex;
        public ushort straightforwardnessDiplomacy;
        public ushort subordinationDomination;
        public ushort timidityCourage;
        public string AgentName { get => agentName; }
        public string AgentType => agentType;
        public int CalmnessAnxiety { get => calmnessAnxiety; set => calmnessAnxiety = Convert.ToUInt16(value); }
        public int ClosenessSociability { get => closenessSociability; set => closenessSociability = Convert.ToUInt16(value); }
        public int ConformismNonconformism { get => conformismNonconformism; set => conformismNonconformism = Convert.ToUInt16(value); }
        public int ConservatismRadicalism { get => conservatismRadicalism; set => conservatismRadicalism = Convert.ToUInt16(value); }
        public int CredulitySuspicion { get => credulitySuspicion; set => credulitySuspicion = Convert.ToUInt16(value); }
        public int EmotionalInstabilityStability { get => emotionalInstabilityStability; set => emotionalInstabilityStability = Convert.ToUInt16(value); }
        public int ImageID { get => imageID; }
        public int Intelligence { get => intelligence; set => intelligence = Convert.ToUInt16(value); }
        public int NormativityOfBehaviour { get => normativityOfBehaviour; set => normativityOfBehaviour = Convert.ToUInt16(value); }
        public int PracticalityDreaminess { get => practicalityDreaminess; set => practicalityDreaminess = Convert.ToUInt16(value); }
        public int RelaxationTension { get => relaxationTension; set => relaxationTension = Convert.ToUInt16(value); }
        public int RestraintExpressiveness { get => restraintExpressiveness; set => restraintExpressiveness = Convert.ToUInt16(value); }
        public int RigiditySensetivity { get => rigiditySensetivity; set => rigiditySensetivity = Convert.ToUInt16(value); }
        public int Selfcontrol { get => selfcontrol; set => selfcontrol = Convert.ToUInt16(value); }
        public SexBase Sex { get => sex; }
        public int StraightforwardnessDiplomacy { get => straightforwardnessDiplomacy; set => straightforwardnessDiplomacy = Convert.ToUInt16(value); }
        public int SubordinationDomination { get => subordinationDomination; set => subordinationDomination = Convert.ToUInt16(value); }
        public int TimidityCourage { get => timidityCourage; set => timidityCourage = Convert.ToUInt16(value); }
        public List<FeatureBase> Features { get => features; set => features = value; }

        public virtual void Initiate(AgentCreationScreen acs)
        {
            imageID = acs.AgentImageHandler.ImageID;
            agentName = acs.NameInputFieldButtonPair.InputField.text;
            agentType = acs.CreatedType.AssemblyQualifiedName;
            sex = acs.SexRect.SelectedSex;
           
            var builder = acs.CharacterRect.CharacterBuilder;
            closenessSociability = Convert.ToUInt16(builder.ClosenessSociability);
            calmnessAnxiety = Convert.ToUInt16(builder.CalmnessAnxiety);
            conformismNonconformism = Convert.ToUInt16(builder.ConformismNonconformism);
            conservatismRadicalism = Convert.ToUInt16(builder.ConservatismRadicalism);
            credulitySuspicion = Convert.ToUInt16(builder.CredulitySuspicion);
            emotionalInstabilityStability = Convert.ToUInt16(builder.EmotionalInstabilityStability);
            intelligence = Convert.ToUInt16(builder.Intelligence);
            normativityOfBehaviour = Convert.ToUInt16(builder.NormativityOfBehaviour);
            practicalityDreaminess = Convert.ToUInt16(builder.PracticalityDreaminess);
            relaxationTension = Convert.ToUInt16(builder.RelaxationTension);
            restraintExpressiveness = Convert.ToUInt16(builder.RestraintExpressiveness);
            rigiditySensetivity = Convert.ToUInt16(builder.RigiditySensetivity);
            selfcontrol = Convert.ToUInt16(builder.Selfcontrol);
            straightforwardnessDiplomacy = Convert.ToUInt16(builder.StraightforwardnessDiplomacy);
            subordinationDomination = Convert.ToUInt16(builder.SubordinationDomination);
            timidityCourage = Convert.ToUInt16(builder.TimidityCourage);

            features = new List<FeatureBase>(acs.FeaturesRect.SelectedFeatures);
        }
    }
}