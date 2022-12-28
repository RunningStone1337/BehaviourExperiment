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

        public void SetDefaultControlsValues()
        {
            acs.AgentImageHandler.Image.sprite = acs.AgentImageHandler.DefaultImage;
            acs.NameInputFieldButtonPair.Text = string.Empty;
            acs.AgeDropButtonPair.DropdownValue = acs.MinAge.ToString();
            acs.OnAgeSelectionChanged();

            var nshandler = acs.NervousSystemRect;
            nshandler.SetDefaultValues();            

            var chRect = acs.CharacterRect;
            chRect.SetDefaultValues();

            var features = acs.FeaturesRect;
            features.SetDefaultValues();
        }

        public void RandomizeControlsValues()
        {
            acs.SexDropButtonPair.PushButton();
            acs.NameInputFieldButtonPair.PushButton();
            acs.AgeDropButtonPair.PushButton();
            acs.WeightDropButtonPair.PushButton();
            acs.HeightDropButtonPair.PushButton();

            var nshandler = acs.NervousSystemRect;
            nshandler.RandomizeControlsValues();
            
            var chRect = acs.CharacterRect;
            chRect.RandomizeControlsValues();

            var features = acs.FeaturesRect;
            features.RandomizeControlsValues();
        }

        public void SetControlsValues(AgentRawData rawData)
        {
            acs.AgentImageHandler.Image.sprite = acs.AgentImageHandler.GetImage(rawData.ImageID);
            acs.NameInputFieldButtonPair.Text = rawData.AgentName;
            acs.SexDropButtonPair.DropdownValue = rawData.Sex ? "ì" : "æ";
            acs.AgeDropButtonPair.DropdownValue = rawData.Age.ToString();
            acs.WeightDropButtonPair.DropdownValue = rawData.Weight.ToString();
            acs.HeightDropButtonPair.DropdownValue = rawData.Height.ToString();

            var nshandler = acs.NervousSystemRect;
            nshandler.SetControlsValues(rawData);           

            var chRect = acs.CharacterRect;
            chRect.SetControlsValues(rawData);

            var features = acs.FeaturesRect;
            features.SetControlsValues(rawData);
        }
    }
}