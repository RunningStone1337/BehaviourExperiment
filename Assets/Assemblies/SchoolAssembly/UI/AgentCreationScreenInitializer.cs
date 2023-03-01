using BehaviourModel;
using Common;
using System;
using System.Collections.Generic;

namespace UI
{
    public class AgentCreationScreenInitializer
    {
        private AgentCreationScreen acs;

        private void GetMinMaxAges(out int minAge, out int maxAge)
        {
            if (acs.CreatedType.Equals<PupilAgent>())
            {
                minAge = acs.PupilsAgeHandler.Values[0].x;
                maxAge = acs.PupilsAgeHandler.Values[0].y;
            }
            else if (acs.CreatedType.Equals<TeacherAgent>())
            {
                minAge = acs.TeachersAgeHandler.Values[0].x;
                maxAge = acs.TeachersAgeHandler.Values[0].y;
            }
            else throw new Exception($"Unexpected type {acs.CreatedType}");
        }

        private void ResetAgeDrop(Type type)
        {
            List<int> diap;
            if (type.Equals<PupilAgent>())
                diap = acs.PupilsAgeHandler.Values[0].GetDiapazoneBetweenXY();
            else if (type.Equals<TeacherAgent>())
                diap = acs.TeachersAgeHandler.Values[0].GetDiapazoneBetweenXY();
            else throw new Exception($"Unexpected type {acs.CreatedType.FullName}");
            acs.AgeDropButtonPair.ClearDropdown();
            foreach (var val in diap)
                acs.AgeDropButtonPair.AddOption(val.ToString(), val);
        }

        private void ResetAgeDrop(string typeName) =>
            ResetAgeDrop(Type.GetType(typeName));

        private void ResetBehaviourPatternsRect(Type type)
        {
            if (type.Equals<PupilAgent>())
                acs.PrefferedBehaviourRect.Deactivate();
            else
                acs.PrefferedBehaviourRect.Activate();
        }

        private void ResetBehaviourPatternsRect(string typeName)
        {
            ResetBehaviourPatternsRect(Type.GetType(typeName));
        }

        private void ResetMinMaxAges()
        {
            GetMinMaxAges(out int minAge, out int maxAge);
            ResetMinMaxAges(minAge, maxAge);
        }

        private void ResetMinMaxAges(int minAge, int maxAge)
        {
            acs.AgeDropButtonPair.ClearDropdown();
            for (int age = minAge; age <= maxAge; age++)
                acs.AgeDropButtonPair.AddOption(age.ToString(), age);
        }

        public AgentCreationScreenInitializer(AgentCreationScreen agentCreationScreen)
        {
            acs = agentCreationScreen;
        }

        public void RandomizeControlsValues()
        {
            acs.SexRect.PushButton();
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

            var model = acs.PrefferedBehaviourRect;
            model.RandomizeControlsValues();
        }

        public void SetControlsValues(HumanRawData rawData)
        {
            acs.AgentImageHandler.Image.sprite = acs.AgentImageHandler.GetImage(rawData.ImageID);
            acs.NameInputFieldButtonPair.Text = rawData.AgentName;
            acs.SexRect.SelectedSex = rawData.Sex;
            ResetAgeDrop(rawData.AgentType);
            acs.AgeDropButtonPair.DropdownValue = rawData.Age.ToString();
            acs.WeightDropButtonPair.DropdownValue = rawData.Weight.ToString();
            acs.HeightDropButtonPair.DropdownValue = rawData.Height.ToString();

            var nshandler = acs.NervousSystemRect;
            nshandler.SetControlsValues(rawData);

            var chRect = acs.CharacterRect;
            chRect.SetControlsValues(rawData);

            var features = acs.FeaturesRect;
            features.SetControlsValues(rawData);
            ResetMinMaxAges();
            var age = acs.SelectedAge;
            var ageChangeHandler = new AgeChangeHandler(age, acs);
            ageChangeHandler.ResetCharacterExtremeValues();
            ageChangeHandler.ResetWeightAndHeightDropdowns();

            ResetBehaviourPatternsRect(rawData.AgentType);
        }

        public void SetDefaultControlsValues()
        {
            acs.AgentImageHandler.Image.sprite = acs.AgentImageHandler.DefaultImage;
            acs.NameInputFieldButtonPair.Text = string.Empty;
            GetMinMaxAges(out int minAge, out _);
            ResetAgeDrop(acs.CreatedType);
            acs.AgeDropButtonPair.DropdownValue = minAge.ToString();
            var ageChangeHandler = new AgeChangeHandler(minAge, acs);
            ageChangeHandler.ResetCharacterExtremeValues();
            ageChangeHandler.ResetWeightAndHeightDropdowns();

            var nshandler = acs.NervousSystemRect;
            nshandler.SetDefaultValues();

            var chRect = acs.CharacterRect;
            chRect.SetDefaultValues();

            var features = acs.FeaturesRect;
            features.SetDefaultValues();

            ResetBehaviourPatternsRect(acs.CreatedType);
        }
    }
}