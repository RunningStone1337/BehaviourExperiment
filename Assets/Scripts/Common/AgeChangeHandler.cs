using BehaviourModel;
using Extensions;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Common
{
    public class AgeChangeHandler<T> where T : AgentBase
    {
        private AgentCreationScreen acs;
        private int newValue;

        public AgeChangeHandler(int newValue, AgentCreationScreen agentCreationScreen)
        {
            this.newValue = newValue;
            acs = agentCreationScreen;
        }

        public void ResetCharacterExtremeValues()
        {
            var cr = acs.CharacterRect;
            switch (newValue)
            {
                case 6:
                    cr.ClosenessSociabilitySlider.SetExtremes(3, 10);
                    cr.CalmnessAnxietySlider.SetExtremes(3, 10);
                    cr.ConformismNonconformismSlider.SetExtremes(1, 7);
                    cr.ConservatismRadicalismSlider.SetExtremes(3, 10);
                    cr.CredulitySuspicionSlider.SetExtremes();
                    cr.EmotionalInstabilityStabilitySlider.SetExtremes();
                    cr.IntelligenceSlider.SetExtremes(1, 7);
                    cr.NormativityOfBehaviourSlider.SetExtremes();
                    cr.PracticalityDreaminessSlider.SetExtremes();
                    cr.RelaxationTensionSlider.SetExtremes(3, 10);
                    cr.RestraintExpressivenessSlider.SetExtremes(3, 10);
                    cr.RigiditySensetivitySlider.SetExtremes(4, 10);
                    cr.SelfcontrolSlider.SetExtremes(3, 10);
                    cr.StraightforwardnessDiplomacySlider.SetExtremes(1, 7);
                    cr.SubordinationDominationSlider.SetExtremes();
                    cr.TimidityCourageSlider.SetExtremes();
                    break;

                case 7:
                    cr.ClosenessSociabilitySlider.SetExtremes(2, 10);
                    cr.CalmnessAnxietySlider.SetExtremes(3, 10);
                    cr.ConformismNonconformismSlider.SetExtremes(1, 8);
                    cr.ConservatismRadicalismSlider.SetExtremes(2, 10);
                    cr.CredulitySuspicionSlider.SetExtremes();
                    cr.EmotionalInstabilityStabilitySlider.SetExtremes();
                    cr.IntelligenceSlider.SetExtremes(1, 8);
                    cr.NormativityOfBehaviourSlider.SetExtremes();
                    cr.PracticalityDreaminessSlider.SetExtremes();
                    cr.RelaxationTensionSlider.SetExtremes(2, 10);
                    cr.RestraintExpressivenessSlider.SetExtremes(2, 10);
                    cr.RigiditySensetivitySlider.SetExtremes(3, 10);
                    cr.SelfcontrolSlider.SetExtremes(2, 10);
                    cr.StraightforwardnessDiplomacySlider.SetExtremes(1, 7);
                    cr.SubordinationDominationSlider.SetExtremes();
                    cr.TimidityCourageSlider.SetExtremes();
                    break;

                case 8:
                    cr.ClosenessSociabilitySlider.SetExtremes(2, 10);
                    cr.CalmnessAnxietySlider.SetExtremes(2, 10);
                    cr.ConformismNonconformismSlider.SetExtremes(1, 9);
                    cr.ConservatismRadicalismSlider.SetExtremes();
                    cr.CredulitySuspicionSlider.SetExtremes();
                    cr.EmotionalInstabilityStabilitySlider.SetExtremes();
                    cr.IntelligenceSlider.SetExtremes(1, 9);
                    cr.NormativityOfBehaviourSlider.SetExtremes();
                    cr.PracticalityDreaminessSlider.SetExtremes();
                    cr.RelaxationTensionSlider.SetExtremes();
                    cr.RestraintExpressivenessSlider.SetExtremes();
                    cr.RigiditySensetivitySlider.SetExtremes(2, 10);
                    cr.SelfcontrolSlider.SetExtremes();
                    cr.StraightforwardnessDiplomacySlider.SetExtremes(1, 8);
                    cr.SubordinationDominationSlider.SetExtremes();
                    cr.TimidityCourageSlider.SetExtremes();
                    break;

                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                default:
                    var sl = acs.CharacterRect.CharacterSliders;
                    foreach (var s in sl)
                        s.SetExtremes();
                    break;
            }
        }

        public void ResetExtremeValues(DropdownButtonPair target, List<int> diap)
        {
            target.ClearDropdown();
            foreach (var v in diap)
                target.AddOption(v.ToString(), v);
            target.ResetVisualDropdown();
        }

        public void ResetWeightAndHeightDropdowns()
        {
            var weightDrop = acs.WeightDropButtonPair;
            var heightDrop = acs.HeightDropButtonPair;
            List<int> diapW, diapH;
            if (typeof(T).Equals<PupilAgent>())
            {
                diapW = acs.PupilAgeWeightsHandler.GetDiapazoneYZForXValue(newValue);
                diapH = acs.PupilAgeHeightsHandler.GetDiapazoneYZForXValue(newValue);
            }
            else if (typeof(T).Equals<TeacherAgent>())
            {
                diapW = new Vector2Int(60, 120).GetDiapazoneBetweenXY();
                diapH = new Vector2Int(150, 210).GetDiapazoneBetweenXY();
            }
            else throw new System.Exception($"Unexpected type {typeof(T).FullName}");
            ResetExtremeValues(weightDrop, diapW);
            ResetExtremeValues(heightDrop, diapH);
        }
    }
}