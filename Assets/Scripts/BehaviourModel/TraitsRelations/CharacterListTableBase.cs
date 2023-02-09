using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class CharacterListTableBase<T> : PhenomenonRelationTable 
    {
        [SerializeField] List<T> lowSocialVector;
        public List<T> LowSocialVector { get => lowSocialVector; set => lowSocialVector = value; }
        [SerializeField] List<T> midSocialVector;
        public List<T> MidSocialVector { get => midSocialVector; set => midSocialVector = value; }
        [SerializeField] List<T> highSocialVector;
        public List<T> HighSocialVector { get => highSocialVector; set => highSocialVector = value; }
        [Space]
        [SerializeField] List<T> lowAnxietyVector;
        public List<T> LowAnxietyVector { get => lowAnxietyVector; set => lowAnxietyVector = value; }
        [SerializeField] List<T> midAnxietyVector;
        public List<T> MidAnxietyVector { get => midAnxietyVector; set => midAnxietyVector = value; }
        [SerializeField] List<T> highAnxietyVector;
        public List<T> HighAnxietyVector { get => highAnxietyVector; set => highAnxietyVector = value; }
        [Space]

        [SerializeField] List<T> lowNonconformVector;
        public List<T> LowNonconformVector { get => lowNonconformVector; set => lowNonconformVector = value; }
        [SerializeField] List<T> midNonconformVector;
        public List<T> MidNonconformVector { get => midNonconformVector; set => midNonconformVector = value; }
        [SerializeField] List<T> highNonconformVector;
        public List<T> HighNonconformVector { get => highNonconformVector; set => highNonconformVector = value; }
        [Space]

        [SerializeField] List<T> lowRadicalVector;
        public List<T> LowRadicalVector { get => lowRadicalVector; set => lowRadicalVector = value; }
        [SerializeField] List<T> midRadicalVector;
        public List<T> MidRadicalVector { get => midRadicalVector; set => midRadicalVector = value; }
        [SerializeField] List<T> highRadicalVector;
        public List<T> HighRadicalVector { get => highRadicalVector; set => highRadicalVector = value; }
        [Space]

        [SerializeField] List<T> lowSuspicionVector;
        public List<T> LowSuspicionVector { get => lowSuspicionVector; set => lowSuspicionVector = value; }
        [SerializeField] List<T> midSuspicionVector;
        public List<T> MidSuspicionVector { get => midSuspicionVector; set => midSuspicionVector = value; }
        [SerializeField] List<T> highSuspicionVector;
        public List<T> HighSuspicionVector { get => highSuspicionVector; set => highSuspicionVector = value; }
        [Space]

        [SerializeField] List<T> lowEmStabVector;
        public List<T> LowEmStabVector { get => lowEmStabVector; set => lowEmStabVector = value; }
        [SerializeField] List<T> midEmStabVector;
        public List<T> MidEmStabVector { get => midEmStabVector; set => midEmStabVector = value; }
        [SerializeField] List<T> highEmStabVector;
        public List<T> HighEmStabVector { get => highEmStabVector; set => highEmStabVector = value; }
        [Space]

        [SerializeField] List<T> lowIntellVector;
        public List<T> LowIntellVector { get => lowIntellVector; set => lowIntellVector = value; }
        [SerializeField] List<T> midIntellVector;
        public List<T> MidIntellVector { get => midIntellVector; set => midIntellVector = value; }
        [SerializeField] List<T> highIntellVector;
        public List<T> HighIntellVector { get => highIntellVector; set => highIntellVector = value; }
        [Space]

        [SerializeField] List<T> lowNormativityVector;
        public List<T> LowNormativityVector { get => lowNormativityVector; set => lowNormativityVector = value; }
        [SerializeField] List<T> midNormativityVector;
        public List<T> MidNormativityVector { get => midNormativityVector; set => midNormativityVector = value; }
        [SerializeField] List<T> highNormativityVector;
        public List<T> HighNormativityVector { get => highNormativityVector; set => highNormativityVector = value; }
        [Space]

        [SerializeField] List<T> lowDreamVector;
        public List<T> LowDreamVector { get => lowDreamVector; set => lowDreamVector = value; }
        [SerializeField] List<T> midDreamVector;
        public List<T> MidDreamVector { get => midDreamVector; set => midDreamVector = value; }
        [SerializeField] List<T> highDreamVector;
        public List<T> HighDreamVector { get => highDreamVector; set => highDreamVector = value; }
        [Space]

        [SerializeField] List<T> lowExpressVector;
        public List<T> LowExpressVector { get => lowExpressVector; set => lowExpressVector = value; }
        [SerializeField] List<T> midExpressVector;
        public List<T> MidExpressVector { get => midExpressVector; set => midExpressVector = value; }
        [SerializeField] List<T> highExpressVector;
        public List<T> HighExpressVector { get => highExpressVector; set => highExpressVector = value; }
        [Space]

        [SerializeField] List<T> lowTensionVector;
        public List<T> LowTensionVector { get => lowTensionVector; set => lowTensionVector = value; }
        [SerializeField] List<T> midTensionVector;
        public List<T> MidTensionVector { get => midTensionVector; set => midTensionVector = value; }
        [SerializeField] List<T> highTensionVector;
        public List<T> HighTensionVector { get => highTensionVector; set => highTensionVector = value; }
        [Space]

        [SerializeField] List<T> lowSensetVector;
        public List<T> LowSensetVector { get => lowSensetVector; set => lowSensetVector = value; }
        [SerializeField] List<T> midSensetVector;
        public List<T> MidSensetVector { get => midSensetVector; set => midSensetVector = value; }
        [SerializeField] List<T> highSensetVector;
        public List<T> HighSensetVector { get => highSensetVector; set => highSensetVector = value; }
        [Space]

        [SerializeField] List<T> lowSelfControlVector;
        public List<T> LowSelfControlVector { get => lowSelfControlVector; set => lowSelfControlVector = value; }
        [SerializeField] List<T> midSelfControlVector;
        public List<T> MidSelfControlVector { get => midSelfControlVector; set => midSelfControlVector = value; }
        [SerializeField] List<T> highSelfControlVector;
        public List<T> HighSelfControlVector { get => highSelfControlVector; set => highSelfControlVector = value; }
        [Space]

        [SerializeField] List<T> lowDiplomVector;
        public List<T> LowDiplomVector { get => lowDiplomVector; set => lowDiplomVector = value; }
        [SerializeField] List<T> midDiplomVector;
        public List<T> MidDiplomVector { get => midDiplomVector; set => midDiplomVector = value; }
        [SerializeField] List<T> highDiplomVector;
        public List<T> HighDiplomVector { get => highDiplomVector; set => highDiplomVector = value; }
        [Space]

        [SerializeField] List<T> lowDomintationVector;
        public List<T> LowDomintationVector { get => lowDomintationVector; set => lowDomintationVector = value; }
        [SerializeField] List<T> midDomintationVector;
        public List<T> MidDomintationVector { get => midDomintationVector; set => midDomintationVector = value; }
        [SerializeField] List<T> highDomintationVector;
        public List<T> HighDomintationVector { get => highDomintationVector; set => highDomintationVector = value; }
        [Space]

        [SerializeField] List<T> lowCourageVector;
        public List<T> LowCourageVector { get => lowCourageVector; set => lowCourageVector = value; }
        [SerializeField] List<T> midCourageVector;
        public List<T> MidCourageVector { get => midCourageVector; set => midCourageVector = value; }
        [SerializeField] List<T> highCourageVector;
        public List<T> HighCourageVector { get => highCourageVector; set => highCourageVector = value; }
        //[SerializeField] List<List<T>> lowValuesVectors;
        //[SerializeField] List<List<T>> highValuesVectors;
        //[SerializeField] List<List<T>> middleValuesVectors;
        //[SerializeField] string[] columnsNames;
        //public List<List<T>> LowValuesVectors { get => lowValuesVectors; set => lowValuesVectors = value; }
        //public List<List<T>> HighValuesVectors { get => highValuesVectors; set => highValuesVectors = value; }
        //public List<List<T>> MiddleValuesVectors { get => middleValuesVectors; set => middleValuesVectors = value; }
        //public string[] ColumnsNames { get => columnsNames; set => columnsNames = value; }
    }
}