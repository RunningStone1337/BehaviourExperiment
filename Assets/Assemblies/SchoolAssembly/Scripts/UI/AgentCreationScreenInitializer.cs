using BehaviourModel;
using System;

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

     
        public AgentCreationScreenInitializer(AgentCreationScreen agentCreationScreen)
        {
            acs = agentCreationScreen;
        }

        public void RandomizeControlsValues()
        {
            acs.SexRect.PushButton();
            acs.NameInputFieldButtonPair.PushButton();

            var chRect = acs.CharacterRect;
            chRect.RandomizeControlsValues();

            var features = acs.FeaturesRect;
            features.RandomizeControlsValues();
        }

        public void SetControlsValues(HumanRawData rawData)
        {
            acs.AgentImageHandler.SetImageByID(rawData.ImageID);
            acs.NameInputFieldButtonPair.Text = rawData.AgentName;
            acs.SexRect.SelectedSex = rawData.Sex;

            var chRect = acs.CharacterRect;
            chRect.SetControlsValues(rawData);

            var features = acs.FeaturesRect;
            features.SetControlsValues(rawData);
        }

        public void SetDefaultControlsValues()
        {
            acs.AgentImageHandler.SetDefaultImage();
            acs.NameInputFieldButtonPair.Text = string.Empty;
          

            var chRect = acs.CharacterRect;
            chRect.SetDefaultValues();

            var features = acs.FeaturesRect;
            features.SetDefaultValues();

        }
    }
}