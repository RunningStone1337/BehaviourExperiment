using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class AgentCreationScreenInitializer
    {
        private AgentCreationScreen acs;

        public AgentCreationScreenInitializer(AgentCreationScreen agentCreationScreen)
        {
            acs = agentCreationScreen;
        }

        internal void SetDefaultControlsValues()
        {
            acs.AgentImageHandler.Image.sprite = acs.AgentImageHandler.DefaultImage;
            acs.NameInputFieldButtonPair.Text = string.Empty;
            acs.AgeDropButtonPair.DropdownValue = acs.MinAge.ToString();
            acs.OnAgeSelectionChanged();
            acs.NsPowerSlider.SetMinValue();
            acs.NsMoveabilitySlider.SetMinValue();
            acs.NsBalanceDropButtonPair.DropdownIndex = 0;
            acs.NsActivitySlider.SetMinValue();
            acs.NsReactivitySlider.SetMinValue();

            var chRect = acs.CharacterRect;
            chRect.ClosenessSociabilitySlider.SetMinValue(); 
            chRect.CalmnessAnxietySlider.SetMinValue();
            chRect.ConformismNonconformismSlider.SetMinValue();
            chRect.ConservatismRadicalismSlider.SetMinValue();
            chRect.CredulitySuspicionSlider.SetMinValue();
            chRect.EmotionalInstabilityStabilitySlider.SetMinValue();
            chRect.IntelligenceSlider.SetMinValue();
            chRect.NormativityOfBehaviourSlider.SetMinValue();
            chRect.PracticalityDreaminessSlider.SetMinValue();
            chRect.RelaxationTensionSlider.SetMinValue();
            chRect.RestraintExpressivenessSlider.SetMinValue();
            chRect.RigiditySensetivitySlider.SetMinValue();
            chRect.SelfcontrolSlider.SetMinValue();
            chRect.StraightforwardnessDiplomacySlider.SetMinValue();
            chRect.SubordinationDominationSlider.SetMinValue();
            chRect.TimidityCourageSlider.SetMinValue();
        }

        public void RandomizeControlsValues()
        {
            acs.SexDropButtonPair.PushButton();
            acs.NameInputFieldButtonPair.PushButton();
            acs.AgeDropButtonPair.PushButton();
            acs.WeightDropButtonPair.PushButton();
            acs.HeightDropButtonPair.PushButton();
            acs.NsPowerSlider.PushButton();
            acs.NsMoveabilitySlider.PushButton();
            acs.NsActivitySlider.PushButton();
            acs.NsReactivitySlider.PushButton();
            acs.NsBalanceDropButtonPair.PushButton();
            var chRect = acs.CharacterRect.CharacterSliders;

            foreach (var s in chRect)
                s.PushButton();
        }

        public void SetControlsValues(AgentRawData rawData)
        {
            acs.AgentImageHandler.Image.sprite = acs.AgentImageHandler.GetImage(rawData.ImageID);
            acs.NameInputFieldButtonPair.Text = rawData.AgentName;
            acs.SexDropButtonPair.DropdownValue = rawData.Sex ? "ì" : "æ";
            acs.AgeDropButtonPair.DropdownValue = rawData.Age.ToString();
            acs.WeightDropButtonPair.DropdownValue = rawData.Weight.ToString();
            acs.HeightDropButtonPair.DropdownValue = rawData.Height.ToString();
            acs.NsPowerSlider.Value = rawData.NsPower;
            acs.NsMoveabilitySlider.Value = rawData.NsMoveability;
            acs.NsBalanceDropButtonPair.DropdownIndex = (int)rawData.NsType;
            acs.NsActivitySlider.Value = rawData.NsActivity;
            acs.NsReactivitySlider.Value = rawData.NsReactivity;

            var chRect = acs.CharacterRect;
            chRect.ClosenessSociabilitySlider.Value = rawData.ClosenessSociability;
            chRect.CalmnessAnxietySlider.Value = rawData.CalmnessAnxiety;
            chRect.ConformismNonconformismSlider.Value = rawData.ConformismNonconformism;
            chRect.ConservatismRadicalismSlider.Value = rawData.ConservatismRadicalism;
            chRect.CredulitySuspicionSlider.Value = rawData.CredulitySuspicion;
            chRect.EmotionalInstabilityStabilitySlider.Value = rawData.EmotionalInstabilityStability;
            chRect.IntelligenceSlider.Value = rawData.Intelligence;
            chRect.NormativityOfBehaviourSlider.Value = rawData.NormativityOfBehaviour;
            chRect.PracticalityDreaminessSlider.Value = rawData.PracticalityDreaminess;
            chRect.RelaxationTensionSlider.Value = rawData.RelaxationTension;
            chRect.RestraintExpressivenessSlider.Value = rawData.RestraintExpressiveness;
            chRect.RigiditySensetivitySlider.Value = rawData.RigiditySensetivity;
            chRect.SelfcontrolSlider.Value = rawData.Selfcontrol;
            chRect.StraightforwardnessDiplomacySlider.Value = rawData.StraightforwardnessDiplomacy;
            chRect.SubordinationDominationSlider.Value = rawData.SubordinationDomination;
            chRect.TimidityCourageSlider.Value = rawData.TimidityCourage;
        }
    }
}