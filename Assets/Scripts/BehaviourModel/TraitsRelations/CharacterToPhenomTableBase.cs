using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class CharacterToPhenomTableBase<T> : PhenomenonRelationTable
    {
        [SerializeField] T[] lowSocialVector;
        public T[] LowSocialVector { get => lowSocialVector; set => lowSocialVector = value; }
        [SerializeField] T[] midSocialVector;
        public T[] MidSocialVector { get => midSocialVector; set => midSocialVector = value; }
        [SerializeField] T[] highSocialVector;
        public T[] HighSocialVector { get => highSocialVector; set => highSocialVector = value; }

        [SerializeField] T[] lowCalmVector;
        public T[] LowAnxietyVector { get => lowCalmVector; set => lowCalmVector = value; }
        [SerializeField] T[] midCalmVector;
        public T[] MidAnxietyVector { get => midCalmVector; set => midCalmVector = value; }
        [SerializeField] T[] highCalmVector;
        public T[] HighAnxietyVector { get => highCalmVector; set => highCalmVector = value; }

        [SerializeField] T[] lowConformVector;
        public T[] LowNonconformVector { get => lowConformVector; set => lowConformVector = value; }
        [SerializeField] T[] midConformVector;
        public T[] MidNonconformVector { get => midConformVector; set => midConformVector = value; }
        [SerializeField] T[] highConformVector;
        public T[] HighNonconformVector { get => highConformVector; set => highConformVector = value; }

        [SerializeField] T[] lowRadicalVector;
        public T[] LowRadicalVector { get => lowRadicalVector; set => lowRadicalVector = value; }
        [SerializeField] T[] midRadicalVector;
        public T[] MidRadicalVector { get => midRadicalVector; set => midRadicalVector = value; }
        [SerializeField] T[] highRadicalVector;
        public T[] HighRadicalVector { get => highRadicalVector; set => highRadicalVector = value; }

        [SerializeField] T[] lowSuspicionVector;
        public T[] LowSuspicionVector { get => lowSuspicionVector; set => lowSuspicionVector = value; }
        [SerializeField] T[] midSuspicionVector;
        public T[] MidSuspicionVector { get => midSuspicionVector; set => midSuspicionVector = value; }
        [SerializeField] T[] highSuspicionVector;
        public T[] HighSuspicionVector { get => highSuspicionVector; set => highSuspicionVector = value; }

        [SerializeField] T[] lowEmStabVector;
        public T[] LowEmStabVector { get => lowEmStabVector; set => lowEmStabVector = value; }
        [SerializeField] T[] midEmStabVector;
        public T[] MidEmStabVector { get => midEmStabVector; set => midEmStabVector = value; }
        [SerializeField] T[] highEmStabVector;
        public T[] HighEmStabVector { get => highEmStabVector; set => highEmStabVector = value; }

        [SerializeField] T[] lowIntellVector;
        public T[] LowIntellVector { get => lowIntellVector; set => lowIntellVector = value; }
        [SerializeField] T[] midIntellVector;
        public T[] MidIntellVector { get => midIntellVector; set => midIntellVector = value; }
        [SerializeField] T[] highIntellVector;
        public T[] HighIntellVector { get => highIntellVector; set => highIntellVector = value; }

        [SerializeField] T[] lowNormativityVector;
        public T[] LowNormativityVector { get => lowNormativityVector; set => lowNormativityVector = value; }
        [SerializeField] T[] midNormativityVector;
        public T[] MidNormativityVector { get => midNormativityVector; set => midNormativityVector = value; }
        [SerializeField] T[] highNormativityVector;
        public T[] HighNormativityVector { get => highNormativityVector; set => highNormativityVector = value; }

        [SerializeField] T[] lowDreamVector;
        public T[] LowDreamVector { get => lowDreamVector; set => lowDreamVector = value; }
        [SerializeField] T[] midDreamVector;
        public T[] MidDreamVector { get => midDreamVector; set => midDreamVector = value; }
        [SerializeField] T[] highDreamVector;
        public T[] HighDreamVector { get => highDreamVector; set => highDreamVector = value; }

        [SerializeField] T[] lowExpressVector;
        public T[] LowExpressVector { get => lowExpressVector; set => lowExpressVector = value; }
        [SerializeField] T[] midExpressVector;
        public T[] MidExpressVector { get => midExpressVector; set => midExpressVector = value; }
        [SerializeField] T[] highExpressVector;
        public T[] HighExpressVector { get => highExpressVector; set => highExpressVector = value; }

        [SerializeField] T[] lowTensionVector;
        public T[] LowTensionVector { get => lowTensionVector; set => lowTensionVector = value; }
        [SerializeField] T[] midTensionVector;
        public T[] MidTensionVector { get => midTensionVector; set => midTensionVector = value; }
        [SerializeField] T[] highTensionVector;
        public T[] HighTensionVector { get => highTensionVector; set => highTensionVector = value; }

        [SerializeField] T[] lowSensetVector;
        public T[] LowSensetVector { get => lowSensetVector; set => lowSensetVector = value; }
        [SerializeField] T[] midSensetVector;
        public T[] MidSensetVector { get => midSensetVector; set => midSensetVector = value; }
        [SerializeField] T[] highSensetVector;
        public T[] HighSensetVector { get => highSensetVector; set => highSensetVector = value; }

        [SerializeField] T[] lowSelfControlVector;
        public T[] LowSelfControlVector { get => lowSelfControlVector; set => lowSelfControlVector = value; }
        [SerializeField] T[] midSelfControlVector;
        public T[] MidSelfControlVector { get => midSelfControlVector; set => midSelfControlVector = value; }
        [SerializeField] T[] highSelfControlVector;
        public T[] HighSelfControlVector { get => highSelfControlVector; set => highSelfControlVector = value; }

        [SerializeField] T[] lowDiplomVector;
        public T[] LowDiplomVector { get => lowDiplomVector; set => lowDiplomVector = value; }
        [SerializeField] T[] midDiplomVector;
        public T[] MidDiplomVector { get => midDiplomVector; set => midDiplomVector = value; }
        [SerializeField] T[] highDiplomVector;
        public T[] HighDiplomVector { get => highDiplomVector; set => highDiplomVector = value; }

        [SerializeField] T[] lowDomintationVector;
        public T[] LowDomintationVector { get => lowDomintationVector; set => lowDomintationVector = value; }
        [SerializeField] T[] midDomintationVector;
        public T[] MidDomintationVector { get => midDomintationVector; set => midDomintationVector = value; }
        [SerializeField] T[] highDomintationVector;
        public T[] HighDomintationVector { get => highDomintationVector; set => highDomintationVector = value; }

        [SerializeField] T[] lowCourageVector;
        public T[] LowCourageVector { get => lowCourageVector; set => lowCourageVector = value; }
        [SerializeField] T[] midCourageVector;
        public T[] MidCourageVector { get => midCourageVector; set => midCourageVector = value; }
        [SerializeField] T[] highCourageVector;
        public T[] HighCourageVector { get => highCourageVector; set => highCourageVector = value; }
        [SerializeField] List<T[]> lowValuesVectors;
        [SerializeField] List<T[]> highValuesVectors;
        [SerializeField] List<T[]> middleValuesVectors;
        [SerializeField] string[] columnsNames;
        public List<T[]> LowValuesVectors { get => lowValuesVectors; set => lowValuesVectors = value; }
        public List<T[]> HighValuesVectors { get => highValuesVectors; set => highValuesVectors = value; }
        public List<T[]> MiddleValuesVectors { get => middleValuesVectors; set => middleValuesVectors = value; }
        public string[] ColumnsNames { get => columnsNames; set => columnsNames = value; }

        public void ResetLowValuesList()
        {
            lowValuesVectors = new List<T[]>()
            {
                lowCalmVector,
                lowConformVector,
                lowCourageVector,
                lowDiplomVector,
                lowDomintationVector,
                lowDreamVector,
                lowEmStabVector,
                lowExpressVector,
                lowIntellVector,
                lowNormativityVector,
                lowRadicalVector,
                lowSelfControlVector,
                lowSensetVector,
                lowSocialVector,
                lowSuspicionVector,
                lowTensionVector
            };
        }

        public void ResetMidValuesList()
        {
            middleValuesVectors = new List<T[]>()
            {
                midCalmVector,
                midConformVector,
                midCourageVector,
                midDiplomVector,
                midDomintationVector,
                midDreamVector,
                midEmStabVector,
                midExpressVector,
                midIntellVector,
                midNormativityVector,
                midRadicalVector,
                midSelfControlVector,
                midSensetVector,
                midSocialVector,
                midSuspicionVector,
                midTensionVector
            };
        }

        public void ResetHighValuesList()
        {
            highValuesVectors = new List<T[]>()
            {
                highCalmVector,
                highConformVector,
                highCourageVector,
                highDiplomVector,
                highDomintationVector,
                highDreamVector,
                highEmStabVector,
                highExpressVector,
                highIntellVector,
                highNormativityVector,
                highRadicalVector,
                highSelfControlVector,
                highSensetVector,
                highSocialVector,
                highSuspicionVector,
                highTensionVector
            };
        }
    }
}