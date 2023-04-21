using Sirenix.OdinInspector;
using System;

namespace BehaviourModel
{
    [Serializable]
    public class TableListViewDimension<TContent> : ArraysViewDimensionBase<TContent>
    {
        #region fields
        [ShowInInspector, ListDrawerSettings(IsReadOnly = true)]
        public override StringWrapper[] ColumnsNames { get => columnsNames; set => columnsNames = value; }

        #region calm
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true),  ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Calmness")]
        public override TContent[] LowAnxietyVector { get => lowCalmVector; set => lowCalmVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Calmness")]
        public override TContent[] MidAnxietyVector { get => midCalmVector; set => midCalmVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Calmness")]
        public override TContent[] HighAnxietyVector { get => highCalmVector; set => highCalmVector = value; }

        #endregion
        #region conform

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Nonconformism")]
        public override TContent[] LowNonconformVector { get => lowConformVector; set => lowConformVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Nonconformism")]
        public override TContent[] MidNonconformVector { get => midConformVector; set => midConformVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Nonconformism")]
        public override TContent[] HighNonconformVector { get => highConformVector; set => highConformVector = value; }
        #endregion
        #region courage
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Courage")]
        public override TContent[] LowCourageVector { get => lowCourageVector; set => lowCourageVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Courage")]
        public override TContent[] MidCourageVector { get => midCourageVector; set => midCourageVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Courage")]
        public override TContent[] HighCourageVector { get => highCourageVector; set => highCourageVector = value; }

        #endregion
        #region dipl
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Diplomacy")]
        public override TContent[] LowDiplomVector { get => lowDiplomVector; set => lowDiplomVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Diplomacy")]
        public override TContent[] MidDiplomVector { get => midDiplomVector; set => midDiplomVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Diplomacy")]
        public override TContent[] HighDiplomVector { get => highDiplomVector; set => highDiplomVector = value; }

        #endregion
        #region dom     

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Domination")]
        public override TContent[] LowDomintationVector { get => lowDomintationVector; set => lowDomintationVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Domination")]
        public override TContent[] MidDomintationVector { get => midDomintationVector; set => midDomintationVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Domination")]
        public override TContent[] HighDomintationVector { get => highDomintationVector; set => highDomintationVector = value; }
        #endregion
        #region dream

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Dreaminess")]
        public override TContent[] LowDreamVector { get => lowDreamVector; set => lowDreamVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Dreaminess")]
        public override TContent[] MidDreamVector { get => midDreamVector; set => midDreamVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Dreaminess")]
        public override TContent[] HighDreamVector { get => highDreamVector; set => highDreamVector = value; }
        #endregion
        #region stab

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Emotional stability")]
        public override TContent[] LowEmStabVector { get => lowEmStabVector; set => lowEmStabVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Emotional stability")]
        public override TContent[] MidEmStabVector { get => midEmStabVector; set => midEmStabVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Emotional stability")]
        public override TContent[] HighEmStabVector { get => highEmStabVector; set => highEmStabVector = value; }
        #endregion
        #region expr

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Expressivenes")]
        public override TContent[] LowExpressVector { get => lowExpressVector; set => lowExpressVector = value; }

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Expressivenes")]
        public override TContent[] MidExpressVector { get => midExpressVector; set => midExpressVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Expressivenes")]
        public override TContent[] HighExpressVector { get => highExpressVector; set => highExpressVector = value; }
        #endregion
        #region intel

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Intelligence")]
        public override TContent[] LowIntellVector { get => lowIntellVector; set => lowIntellVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Intelligence")]
        public override TContent[] MidIntellVector { get => midIntellVector; set => midIntellVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Intelligence")]
        public override TContent[] HighIntellVector { get => highIntellVector; set => highIntellVector = value; }
        #endregion
        #region norm

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")]
        public override TContent[] LowNormativityVector { get => lowNormativityVector; set => lowNormativityVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")]
        public override TContent[] MidNormativityVector { get => midNormativityVector; set => midNormativityVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")]
        public override TContent[] HighNormativityVector { get => highNormativityVector; set => highNormativityVector = value; }
        #endregion
        #region radi


        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Radicalism")]
        public override TContent[] LowRadicalVector { get => lowRadicalVector; set => lowRadicalVector = value; }

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Radicalism")]
        public override TContent[] MidRadicalVector { get => midRadicalVector; set => midRadicalVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Radicalism")]
        public override TContent[] HighRadicalVector { get => highRadicalVector; set => highRadicalVector = value; }
        #endregion
        #region self

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Selfcontrol")]
        public override TContent[] LowSelfControlVector { get => lowSelfControlVector; set => lowSelfControlVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Selfcontrol")]
        public override TContent[] MidSelfControlVector { get => midSelfControlVector; set => midSelfControlVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Selfcontrol")]
        public override TContent[] HighSelfControlVector { get => highSelfControlVector; set => highSelfControlVector = value; }
        #endregion
        #region senset

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sensetivity")]
        public override TContent[] LowSensetVector { get => lowSensetVector; set => lowSensetVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sensetivity")]
        public override TContent[] MidSensetVector { get => midSensetVector; set => midSensetVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sensetivity")]
        public override TContent[] HighSensetVector { get => highSensetVector; set => highSensetVector = value; }
        #endregion
        #region soc

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sociability")]
        public override TContent[] LowSocialVector { get => lowSocialVector; set => lowSocialVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sociability")]
        public override TContent[] MidSocialVector { get => midSocialVector; set => midSocialVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sociability")]
        public override TContent[] HighSocialVector { get => highSocialVector; set => highSocialVector = value; }
        #endregion
        #region susp

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Suspicion")]
        public override TContent[] LowSuspicionVector { get => lowSuspicionVector; set => lowSuspicionVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Suspicion")]
        public override TContent[] MidSuspicionVector { get => midSuspicionVector; set => midSuspicionVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Suspicion")]
        public override TContent[] HighSuspicionVector { get => highSuspicionVector; set => highSuspicionVector = value; }
        #endregion
        #region tens

        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Tension")]
        public override TContent[] LowTensionVector { get => lowTensionVector; set => lowTensionVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Tension")]
        public override TContent[] MidTensionVector { get => midTensionVector; set => midTensionVector = value; }
        [ShowInInspector, TableList(AlwaysExpanded = false, NumberOfItemsPerPage = 1, ShowPaging = true), ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Tension")]
        public override TContent[] HighTensionVector { get => highTensionVector; set => highTensionVector = value; }
        #endregion

        #endregion
        public TableListViewDimension():base()
        {

        }
    }
}
