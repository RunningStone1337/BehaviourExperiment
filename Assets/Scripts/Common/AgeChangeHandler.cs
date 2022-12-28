using UI;

namespace Common
{
    public class AgeChangeHandler
    {
        private int newValue;
        private AgentCreationScreen agentCreationScreen;

        public AgeChangeHandler(int newValue, AgentCreationScreen agentCreationScreen)
        {
            this.newValue = newValue;
            this.agentCreationScreen = agentCreationScreen;
        }
        public void ResetWieghtAndHeightDropdowns()
        {
            ResetExtremeValues(agentCreationScreen.WeightDropButtonPair, agentCreationScreen.AgeWeightsHandler);
            ResetExtremeValues(agentCreationScreen.HeightDropButtonPair, agentCreationScreen.AgeHeightsHandler);
        }
        public void ResetCharacterExtremeValues()
        {
            switch (newValue)
            {
                case 6:
                    agentCreationScreen.CharacterRect.ClosenessSociabilitySlider.SetExtremes(3, 10);
                    agentCreationScreen.CharacterRect.CalmnessAnxietySlider.SetExtremes(3, 10);
                    agentCreationScreen.CharacterRect.ConformismNonconformismSlider.SetExtremes(1, 7);
                    agentCreationScreen.CharacterRect.ConservatismRadicalismSlider.SetExtremes(3, 10);
                    agentCreationScreen.CharacterRect.CredulitySuspicionSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.EmotionalInstabilityStabilitySlider.SetExtremes();
                    agentCreationScreen.CharacterRect.IntelligenceSlider.SetExtremes(1, 7);
                    agentCreationScreen.CharacterRect.NormativityOfBehaviourSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.PracticalityDreaminessSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.RelaxationTensionSlider.SetExtremes(3, 10);
                    agentCreationScreen.CharacterRect.RestraintExpressivenessSlider.SetExtremes(3, 10);
                    agentCreationScreen.CharacterRect.RigiditySensetivitySlider.SetExtremes(4, 10);
                    agentCreationScreen.CharacterRect.SelfcontrolSlider.SetExtremes(3, 10);
                    agentCreationScreen.CharacterRect.StraightforwardnessDiplomacySlider.SetExtremes(1, 7);
                    agentCreationScreen.CharacterRect.SubordinationDominationSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.TimidityCourageSlider.SetExtremes();
                    break;
                case 7:
                    agentCreationScreen.CharacterRect.ClosenessSociabilitySlider.SetExtremes(2, 10);
                    agentCreationScreen.CharacterRect.CalmnessAnxietySlider.SetExtremes(3, 10);
                    agentCreationScreen.CharacterRect.ConformismNonconformismSlider.SetExtremes(1, 8);
                    agentCreationScreen.CharacterRect.ConservatismRadicalismSlider.SetExtremes(2, 10);
                    agentCreationScreen.CharacterRect.CredulitySuspicionSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.EmotionalInstabilityStabilitySlider.SetExtremes();
                    agentCreationScreen.CharacterRect.IntelligenceSlider.SetExtremes(1, 8);
                    agentCreationScreen.CharacterRect.NormativityOfBehaviourSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.PracticalityDreaminessSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.RelaxationTensionSlider.SetExtremes(2, 10);
                    agentCreationScreen.CharacterRect.RestraintExpressivenessSlider.SetExtremes(2, 10);
                    agentCreationScreen.CharacterRect.RigiditySensetivitySlider.SetExtremes(3, 10);
                    agentCreationScreen.CharacterRect.SelfcontrolSlider.SetExtremes(2, 10);
                    agentCreationScreen.CharacterRect.StraightforwardnessDiplomacySlider.SetExtremes(1, 7);
                    agentCreationScreen.CharacterRect.SubordinationDominationSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.TimidityCourageSlider.SetExtremes();
                    break;
                case 8:
                    agentCreationScreen.CharacterRect.ClosenessSociabilitySlider.SetExtremes(2, 10);
                    agentCreationScreen.CharacterRect.CalmnessAnxietySlider.SetExtremes(2, 10);
                    agentCreationScreen.CharacterRect.ConformismNonconformismSlider.SetExtremes(1, 9);
                    agentCreationScreen.CharacterRect.ConservatismRadicalismSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.CredulitySuspicionSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.EmotionalInstabilityStabilitySlider.SetExtremes();
                    agentCreationScreen.CharacterRect.IntelligenceSlider.SetExtremes(1, 9);
                    agentCreationScreen.CharacterRect.NormativityOfBehaviourSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.PracticalityDreaminessSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.RelaxationTensionSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.RestraintExpressivenessSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.RigiditySensetivitySlider.SetExtremes(2, 10);
                    agentCreationScreen.CharacterRect.SelfcontrolSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.StraightforwardnessDiplomacySlider.SetExtremes(1, 8);
                    agentCreationScreen.CharacterRect.SubordinationDominationSlider.SetExtremes();
                    agentCreationScreen.CharacterRect.TimidityCourageSlider.SetExtremes();
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                    foreach (var s in agentCreationScreen.CharacterRect.CharacterSliders)
                        s.SetExtremes();
                    break;
                default:
                    break;
            }
        }

        public void ResetExtremeValues(DropdownButtonPair target, KeyValuesHandler diapazoneHandler)
        {
            var diap = diapazoneHandler.CreateDiapazonForKey(newValue);
            target.ClearDropdown();
            foreach (var v in diap)
                target.AddOption(v.ToString());
            target.ResetVisualDropdown();
        }
    }
}