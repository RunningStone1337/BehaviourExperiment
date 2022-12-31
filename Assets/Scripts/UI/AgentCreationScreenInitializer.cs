using BehaviourModel;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;

namespace UI
{
    public class AgentCreationScreenInitializer
    {
        private AgentCreationScreen acs;

        public AgentCreationScreenInitializer(AgentCreationScreen agentCreationScreen)
        {
            acs = agentCreationScreen;
        }

        public void SetDefaultControlsValues<T>() where T : AgentBase
        {
            acs.AgentImageHandler.Image.sprite = acs.AgentImageHandler.DefaultImage;
            acs.NameInputFieldButtonPair.Text = string.Empty;
            GetMinMaxAges<T>(out int minAge, out _);
            acs.AgeDropButtonPair.DropdownValue = minAge.ToString();
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

        public void SetControlsValues<T>(AgentRawData rawData) where T : AgentBase
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
            ResetMinMaxAges<T>();
            var age = acs.SelectedAge;
            var ageChangeHandler = new AgeChangeHandler(age, acs);
            ageChangeHandler.ResetCharacterExtremeValues();
            ageChangeHandler.ResetWieghtAndHeightDropdowns();
        }

        private void ResetMinMaxAges<T>() where T : AgentBase
        {
            GetMinMaxAges<T>(out int minAge, out int maxAge);
            ResetMinMaxAges(minAge, maxAge);
        }

        private void ResetMinMaxAges(int minAge, int maxAge)
        {
            acs.AgeDropButtonPair.ClearDropdown();
            for (int age = minAge; age <= maxAge; age++)
                acs.AgeDropButtonPair.AddOption(age.ToString(), age);
        }

        private void GetMinMaxAges<T>(out int minAge, out int maxAge) where T : AgentBase
        {
            if (typeof(T).Equals<PupilAgent>())
            {
                minAge = acs.PupilsAgeHandler.Values[0].x;
                maxAge = acs.PupilsAgeHandler.Values[0].y;
            }
            else if (typeof(T).Equals<TeacherAgent>())
            {
                minAge = acs.TeachersAgeHandler.Values[0].x;
                maxAge = acs.TeachersAgeHandler.Values[0].y;
            }
            else throw new Exception($"Unexpected type {typeof(T)}");
        }
    }
}