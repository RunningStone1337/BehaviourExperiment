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
                    agentCreationScreen.ClosenessSociabilitySlider.SetExtremes(3, 10);
                    agentCreationScreen.CalmnessAnxietySlider.SetExtremes(3, 10);
                    agentCreationScreen.ConformismNonconformismSlider.SetExtremes(1, 7);
                    agentCreationScreen.ConservatismRadicalismSlider.SetExtremes(3, 10);
                    agentCreationScreen.CredulitySuspicionSlider.SetExtremes();
                    agentCreationScreen.EmotionalInstabilityStabilitySlider.SetExtremes();
                    agentCreationScreen.IntelligenceSlider.SetExtremes(1, 7);
                    agentCreationScreen.NormativityOfBehaviourSlider.SetExtremes();
                    agentCreationScreen.PracticalityDreaminessSlider.SetExtremes();
                    agentCreationScreen.RelaxationTensionSlider.SetExtremes(3, 10);
                    agentCreationScreen.RestraintExpressivenessSlider.SetExtremes(3, 10);
                    agentCreationScreen.RigiditySensetivitySlider.SetExtremes(4, 10);
                    agentCreationScreen.SelfcontrolSlider.SetExtremes(3, 10);
                    agentCreationScreen.StraightforwardnessDiplomacySlider.SetExtremes(1, 7);
                    agentCreationScreen.SubordinationDominationSlider.SetExtremes();
                    agentCreationScreen.TimidityCourageSlider.SetExtremes();
                    break;
                case 7:
                    agentCreationScreen.ClosenessSociabilitySlider.SetExtremes(2, 10);
                    agentCreationScreen.CalmnessAnxietySlider.SetExtremes(3, 10);
                    agentCreationScreen.ConformismNonconformismSlider.SetExtremes(1, 8);
                    agentCreationScreen.ConservatismRadicalismSlider.SetExtremes(2, 10);
                    agentCreationScreen.CredulitySuspicionSlider.SetExtremes();
                    agentCreationScreen.EmotionalInstabilityStabilitySlider.SetExtremes();
                    agentCreationScreen.IntelligenceSlider.SetExtremes(1, 8);
                    agentCreationScreen.NormativityOfBehaviourSlider.SetExtremes();
                    agentCreationScreen.PracticalityDreaminessSlider.SetExtremes();
                    agentCreationScreen.RelaxationTensionSlider.SetExtremes(2, 10);
                    agentCreationScreen.RestraintExpressivenessSlider.SetExtremes(2, 10);
                    agentCreationScreen.RigiditySensetivitySlider.SetExtremes(3, 10);
                    agentCreationScreen.SelfcontrolSlider.SetExtremes(2, 10);
                    agentCreationScreen.StraightforwardnessDiplomacySlider.SetExtremes(1, 7);
                    agentCreationScreen.SubordinationDominationSlider.SetExtremes();
                    agentCreationScreen.TimidityCourageSlider.SetExtremes();
                    break;
                case 8:
                    agentCreationScreen.ClosenessSociabilitySlider.SetExtremes(2, 10);
                    agentCreationScreen.CalmnessAnxietySlider.SetExtremes(2, 10);
                    agentCreationScreen.ConformismNonconformismSlider.SetExtremes(1, 9);
                    agentCreationScreen.ConservatismRadicalismSlider.SetExtremes();
                    agentCreationScreen.CredulitySuspicionSlider.SetExtremes();
                    agentCreationScreen.EmotionalInstabilityStabilitySlider.SetExtremes();
                    agentCreationScreen.IntelligenceSlider.SetExtremes(1, 9);
                    agentCreationScreen.NormativityOfBehaviourSlider.SetExtremes();
                    agentCreationScreen.PracticalityDreaminessSlider.SetExtremes();
                    agentCreationScreen.RelaxationTensionSlider.SetExtremes();
                    agentCreationScreen.RestraintExpressivenessSlider.SetExtremes();
                    agentCreationScreen.RigiditySensetivitySlider.SetExtremes(2, 10);
                    agentCreationScreen.SelfcontrolSlider.SetExtremes();
                    agentCreationScreen.StraightforwardnessDiplomacySlider.SetExtremes(1, 8);
                    agentCreationScreen.SubordinationDominationSlider.SetExtremes();
                    agentCreationScreen.TimidityCourageSlider.SetExtremes();
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                    foreach (var s in agentCreationScreen.CharacterSliders)
                        s.SetExtremes();
                    break;
                default:
                    break;
            }
        }

        public void ResetExtremeValues(DropdownButtonPair target, KeyDiapazoneHandler diapazoneHandler)
        {
            var diap = diapazoneHandler.CreateDiapazonForKey(newValue);
            target.ClearDropdown();
            foreach (var v in diap)
                target.AddDropdownOption(v.ToString());
            target.ResetVisualDropdown();
        }
    }
}