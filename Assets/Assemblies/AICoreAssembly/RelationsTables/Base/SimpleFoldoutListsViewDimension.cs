using Sirenix.OdinInspector;
using System;

[Serializable]
public class SimpleFoldoutListsViewDimension<TContent>: ArraysViewDimensionBase<TContent>
{
    #region fields
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true)]
    public override StringWrapper[] ColumnsNames { get => columnsNames; set => columnsNames = value; }
    
    #region calm
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Calmness")]
    public override TContent[] LowAnxietyVector { get => lowCalmVector; set => lowCalmVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Calmness")]
    public override TContent[] MidAnxietyVector { get => midCalmVector; set => midCalmVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Calmness")]
    public override TContent[] HighAnxietyVector { get => highCalmVector; set => highCalmVector = value; }
   
    #endregion
    #region conform
   
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Nonconformism")]
    public override TContent[] LowNonconformVector { get => lowConformVector; set => lowConformVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Nonconformism")]
    public override TContent[] MidNonconformVector { get => midConformVector; set => midConformVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Nonconformism")]
    public override TContent[] HighNonconformVector { get => highConformVector; set => highConformVector = value; }
    #endregion
    #region courage
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Courage")]
    public override TContent[] LowCourageVector { get => lowCourageVector; set => lowCourageVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Courage")]
    public override TContent[] MidCourageVector { get => midCourageVector; set => midCourageVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Courage")]
    public override TContent[] HighCourageVector { get => highCourageVector; set => highCourageVector = value; }

    #endregion
    #region dipl
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Diplomacy")]
    public override TContent[] LowDiplomVector { get => lowDiplomVector; set => lowDiplomVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Diplomacy")]
    public override TContent[] MidDiplomVector { get => midDiplomVector; set => midDiplomVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Diplomacy")]
    public override TContent[] HighDiplomVector { get => highDiplomVector; set => highDiplomVector = value; }
    
    #endregion
    #region dom     

    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Domination")]
    public override TContent[] LowDomintationVector { get => lowDomintationVector; set => lowDomintationVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Domination")]
    public override TContent[] MidDomintationVector { get => midDomintationVector; set => midDomintationVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Domination")]
    public override TContent[] HighDomintationVector { get => highDomintationVector; set => highDomintationVector = value; }
    #endregion
    #region dream
    
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Dreaminess")] 
    public override TContent[] LowDreamVector { get => lowDreamVector; set => lowDreamVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Dreaminess")]
    public override TContent[] MidDreamVector { get => midDreamVector; set => midDreamVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Dreaminess")]
    public override TContent[] HighDreamVector { get => highDreamVector; set => highDreamVector = value; }
    #endregion
    #region stab
    
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Emotional stability")]
    public override TContent[] LowEmStabVector { get => lowEmStabVector; set => lowEmStabVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Emotional stability")]
    public override TContent[] MidEmStabVector { get => midEmStabVector; set => midEmStabVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Emotional stability")]
    public override TContent[] HighEmStabVector { get => highEmStabVector; set => highEmStabVector = value; }
    #endregion
    #region expr
   
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Expressivenes")]
    public override TContent[] LowExpressVector { get => lowExpressVector; set => lowExpressVector = value; }

    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Expressivenes")]
    public override TContent[] MidExpressVector { get => midExpressVector; set => midExpressVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Expressivenes")]
    public override TContent[] HighExpressVector { get => highExpressVector; set => highExpressVector = value; }
    #endregion
    #region intel
   
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Intelligence")]
    public override TContent[] LowIntellVector { get => lowIntellVector; set => lowIntellVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Intelligence")]
    public override TContent[] MidIntellVector { get => midIntellVector; set => midIntellVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Intelligence")]
    public override TContent[] HighIntellVector { get => highIntellVector; set => highIntellVector = value; }
    #endregion
    #region norm
    
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")]
    public override TContent[] LowNormativityVector { get => lowNormativityVector; set => lowNormativityVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")]
    public override TContent[] MidNormativityVector { get => midNormativityVector; set => midNormativityVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")]
    public override TContent[] HighNormativityVector { get => highNormativityVector; set => highNormativityVector = value; }
    #endregion
    #region radi
    

    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Radicalism")]
    public override TContent[] LowRadicalVector { get => lowRadicalVector; set => lowRadicalVector = value; }

    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Radicalism")]
    public override TContent[] MidRadicalVector { get => midRadicalVector; set => midRadicalVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Radicalism")] 
    public override TContent[] HighRadicalVector { get => highRadicalVector; set => highRadicalVector = value; }
    #endregion
    #region self
    
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Selfcontrol")]
    public override TContent[] LowSelfControlVector { get => lowSelfControlVector; set => lowSelfControlVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Selfcontrol")] 
    public override TContent[] MidSelfControlVector { get => midSelfControlVector; set => midSelfControlVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Selfcontrol")]
    public override TContent[] HighSelfControlVector { get => highSelfControlVector; set => highSelfControlVector = value; }
    #endregion
    #region senset
    
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sensetivity")] 
    public override TContent[] LowSensetVector { get => lowSensetVector; set => lowSensetVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sensetivity")] 
    public override TContent[] MidSensetVector { get => midSensetVector; set => midSensetVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sensetivity")]
    public override TContent[] HighSensetVector { get => highSensetVector; set => highSensetVector = value; }
    #endregion
    #region soc
   
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sociability")]
    public override TContent[] LowSocialVector { get => lowSocialVector; set => lowSocialVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sociability")] 
    public override TContent[] MidSocialVector { get => midSocialVector; set => midSocialVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sociability")] 
    public override TContent[] HighSocialVector { get => highSocialVector; set => highSocialVector = value; }
    #endregion
    #region susp
   
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Suspicion")]
    public override TContent[] LowSuspicionVector { get => lowSuspicionVector; set => lowSuspicionVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Suspicion")]
    public override TContent[] MidSuspicionVector { get => midSuspicionVector; set => midSuspicionVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Suspicion")]
    public override TContent[] HighSuspicionVector { get => highSuspicionVector; set => highSuspicionVector = value; }
    #endregion
    #region tens
    
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Tension")]
    public override TContent[] LowTensionVector { get => lowTensionVector; set => lowTensionVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Tension")]
    public override TContent[] MidTensionVector { get => midTensionVector; set => midTensionVector = value; }
    [ShowInInspector, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Tension")] 
    public override TContent[] HighTensionVector { get => highTensionVector; set => highTensionVector = value; }
    #endregion
    #endregion
   
    public SimpleFoldoutListsViewDimension():base()
    {
    }
   
    private void InitVectors(SimpleFoldoutListsViewDimension<TContent> referenceMatrix)
    {
        referenceMatrix.ColumnsNames.CopyTo(ref columnsNames);
        referenceMatrix.highCalmVector.CopyTo(ref highCalmVector);
        referenceMatrix.highConformVector.CopyTo(ref highConformVector);
        referenceMatrix.highCourageVector.CopyTo(ref highCourageVector);
        referenceMatrix.highDiplomVector.CopyTo(ref highDiplomVector);
        referenceMatrix.highDomintationVector.CopyTo(ref highDomintationVector);
        referenceMatrix.highDreamVector.CopyTo(ref highDreamVector);
        referenceMatrix.highEmStabVector.CopyTo(ref highEmStabVector);
        referenceMatrix.highExpressVector.CopyTo(ref highExpressVector);
        referenceMatrix.highIntellVector.CopyTo(ref highIntellVector);
        referenceMatrix.highNormativityVector.CopyTo(ref highNormativityVector);
        referenceMatrix.highRadicalVector.CopyTo(ref highRadicalVector);
        referenceMatrix.highSelfControlVector.CopyTo(ref highSelfControlVector);
        referenceMatrix.highSensetVector.CopyTo(ref highSensetVector );
        referenceMatrix.highSocialVector.CopyTo(ref highSocialVector );
        referenceMatrix.highSuspicionVector.CopyTo(ref highSuspicionVector );
        referenceMatrix.highTensionVector.CopyTo(ref highTensionVector );

        referenceMatrix.lowCalmVector.CopyTo(ref lowCalmVector );
        referenceMatrix.lowConformVector.CopyTo(ref lowConformVector );
        referenceMatrix.lowCourageVector.CopyTo(ref lowCourageVector );
        referenceMatrix.lowDiplomVector.CopyTo(ref lowDiplomVector );
        referenceMatrix.lowDomintationVector.CopyTo(ref lowDomintationVector );
        referenceMatrix.lowDreamVector.CopyTo(ref lowDreamVector );
        referenceMatrix.lowEmStabVector.CopyTo(ref lowEmStabVector );
        referenceMatrix.lowExpressVector.CopyTo(ref lowExpressVector );
        referenceMatrix.lowIntellVector.CopyTo(ref lowIntellVector );
        referenceMatrix.lowNormativityVector.CopyTo(ref lowNormativityVector );
        referenceMatrix.lowRadicalVector.CopyTo(ref lowRadicalVector );
        referenceMatrix.lowSelfControlVector.CopyTo(ref lowSelfControlVector );
        referenceMatrix.lowSensetVector.CopyTo(ref lowSensetVector );
        referenceMatrix.lowSocialVector.CopyTo(ref lowSocialVector );
        referenceMatrix.lowSuspicionVector.CopyTo(ref lowSuspicionVector );
        referenceMatrix.lowTensionVector.CopyTo(ref lowTensionVector );

        referenceMatrix.midCalmVector.CopyTo(ref midCalmVector );
        referenceMatrix.midConformVector.CopyTo(ref midConformVector );
        referenceMatrix.midCourageVector.CopyTo(ref midCourageVector );
        referenceMatrix.midDiplomVector.CopyTo(ref midDiplomVector );
        referenceMatrix.midDomintationVector.CopyTo(ref midDomintationVector );
        referenceMatrix.midDreamVector.CopyTo(ref midDreamVector );
        referenceMatrix.midEmStabVector.CopyTo(ref midEmStabVector );
        referenceMatrix.midExpressVector.CopyTo(ref midExpressVector );
        referenceMatrix.midIntellVector.CopyTo(ref midIntellVector );
        referenceMatrix.midNormativityVector.CopyTo(ref midNormativityVector );
        referenceMatrix.midRadicalVector.CopyTo(ref midRadicalVector );
        referenceMatrix.midSelfControlVector.CopyTo(ref midSelfControlVector );
        referenceMatrix.midSensetVector.CopyTo(ref midSensetVector );
        referenceMatrix.midSocialVector.CopyTo(ref midSocialVector );
        referenceMatrix.midSuspicionVector.CopyTo(ref midSuspicionVector );
        referenceMatrix.midTensionVector.CopyTo(ref midTensionVector );
    }
    
    public SimpleFoldoutListsViewDimension(int colsCount)
    {
        InitVectors(colsCount);
    }
}