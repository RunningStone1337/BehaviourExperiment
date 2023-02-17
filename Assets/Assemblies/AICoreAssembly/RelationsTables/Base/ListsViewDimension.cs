using BehaviourModel;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ListsViewDimension<T>: ViewDimensionBase<T>
{
   
    #region fields
    
    [SerializeField, ListDrawerSettings(IsReadOnly = true)]
    private StringWrapper[] columnsNames;
    #region calm
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Calmness")] private T[] lowCalmVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Calmness")] private T[] midCalmVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Calmness")] private T[] highCalmVector;
    #endregion
    #region conform
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Nonconformism")] private T[] lowConformVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Nonconformism")] private T[] midConformVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Nonconformism")] private T[] highConformVector;
    #endregion
    #region courage
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Courage")] private T[] lowCourageVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Courage")] private T[] midCourageVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Courage")] private T[] highCourageVector;
    #endregion
    #region dipl
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Diplomacy")] private T[] lowDiplomVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Diplomacy")] private T[] midDiplomVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Diplomacy")] private T[] highDiplomVector;
    #endregion
    #region dom
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Domination")] private T[] lowDomintationVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Domination")] private T[] midDomintationVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Domination")] private T[] highDomintationVector;
    #endregion
    #region dream
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Dreaminess")] private T[] lowDreamVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Dreaminess")] private T[] midDreamVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Dreaminess")] private T[] highDreamVector;
    #endregion
    #region stab
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Emotional stability")] private T[] lowEmStabVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Emotional stability")] private T[] midEmStabVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Emotional stability")] private T[] highEmStabVector;
    #endregion
    #region expr
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Expressivenes")] private T[] lowExpressVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Expressivenes")] private T[] midExpressVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Expressivenes")] private T[] highExpressVector;
    #endregion
    #region intel
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Intelligence")] private T[] lowIntellVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Intelligence")] private T[] midIntellVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Intelligence")] private T[] highIntellVector;
    #endregion
    #region norm
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")] private T[] lowNormativityVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")] private T[] midNormativityVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")] private T[] highNormativityVector;
    #endregion
    #region radi
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Radicalism")] private T[] lowRadicalVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Radicalism")] private T[] midRadicalVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Radicalism")] private T[] highRadicalVector;
    #endregion
    #region self
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Selfcontrol")] private T[] lowSelfControlVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Selfcontrol")] private T[] midSelfControlVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Selfcontrol")] private T[] highSelfControlVector;
    #endregion
    #region senset
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sensetivity")] private T[] lowSensetVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sensetivity")] private T[] midSensetVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sensetivity")] private T[] highSensetVector;
    #endregion
    #region soc
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sociability")] private T[] lowSocialVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sociability")] private T[] midSocialVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Sociability")] private T[] highSocialVector;
    #endregion
    #region susp
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Suspicion")] private T[] lowSuspicionVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Suspicion")] private T[] midSuspicionVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Suspicion")] private T[] highSuspicionVector;
    #endregion
    #region tens
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Tension")] private T[] lowTensionVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Tension")] private T[] midTensionVector;
    [SerializeField, ListDrawerSettings(IsReadOnly = true), FoldoutGroup("Tension")] private T[] highTensionVector;
    #endregion

    #endregion
    
    public override void ReduceVectors(int vectorsLength)
    {
        LowAnxietyVector = LowAnxietyVector.TryReduceArray(vectorsLength);
        LowNonconformVector = LowNonconformVector.TryReduceArray(vectorsLength);
        LowCourageVector = LowCourageVector.TryReduceArray(vectorsLength);
        LowDiplomVector = LowDiplomVector.TryReduceArray(vectorsLength);
        LowDomintationVector = LowDomintationVector.TryReduceArray(vectorsLength);
        LowDreamVector = LowDreamVector.TryReduceArray(vectorsLength);
        LowEmStabVector = LowEmStabVector.TryReduceArray(vectorsLength);
        LowExpressVector = LowExpressVector.TryReduceArray(vectorsLength);
        LowIntellVector = LowIntellVector.TryReduceArray(vectorsLength);
        LowNormativityVector = LowNormativityVector.TryReduceArray(vectorsLength);
        LowRadicalVector = LowRadicalVector.TryReduceArray(vectorsLength);
        LowSelfControlVector = LowSelfControlVector.TryReduceArray(vectorsLength);
        LowSensetVector = LowSensetVector.TryReduceArray(vectorsLength);
        LowSocialVector = LowSocialVector.TryReduceArray(vectorsLength);
        LowSuspicionVector = LowSuspicionVector.TryReduceArray(vectorsLength);
        LowTensionVector = LowTensionVector.TryReduceArray(vectorsLength);
        //ResetLowValuesList();

        MidAnxietyVector = MidAnxietyVector.TryReduceArray(vectorsLength);
        MidNonconformVector = MidNonconformVector.TryReduceArray(vectorsLength);
        MidCourageVector = MidCourageVector.TryReduceArray(vectorsLength);
        MidDiplomVector = MidDiplomVector.TryReduceArray(vectorsLength);
        MidDomintationVector = MidDomintationVector.TryReduceArray(vectorsLength);
        MidDreamVector = MidDreamVector.TryReduceArray(vectorsLength);
        MidEmStabVector = MidEmStabVector.TryReduceArray(vectorsLength);
        MidExpressVector = MidExpressVector.TryReduceArray(vectorsLength);
        MidIntellVector = MidIntellVector.TryReduceArray(vectorsLength);
        MidNormativityVector = MidNormativityVector.TryReduceArray(vectorsLength);
        MidRadicalVector = MidRadicalVector.TryReduceArray(vectorsLength);
        MidSelfControlVector = MidSelfControlVector.TryReduceArray(vectorsLength);
        MidSensetVector = MidSensetVector.TryReduceArray(vectorsLength);
        MidSocialVector = MidSocialVector.TryReduceArray(vectorsLength);
        MidSuspicionVector = MidSuspicionVector.TryReduceArray(vectorsLength);
        MidTensionVector = MidTensionVector.TryReduceArray(vectorsLength);
        //ResetMidValuesList();

        HighAnxietyVector = HighAnxietyVector.TryReduceArray(vectorsLength);
        HighNonconformVector = HighNonconformVector.TryReduceArray(vectorsLength);
        HighCourageVector = HighCourageVector.TryReduceArray(vectorsLength);
        HighDiplomVector = HighDiplomVector.TryReduceArray(vectorsLength);
        HighDomintationVector = HighDomintationVector.TryReduceArray(vectorsLength);
        HighDreamVector = HighDreamVector.TryReduceArray(vectorsLength);
        HighEmStabVector = HighEmStabVector.TryReduceArray(vectorsLength);
        HighExpressVector = HighExpressVector.TryReduceArray(vectorsLength);
        HighIntellVector = HighIntellVector.TryReduceArray(vectorsLength);
        HighNormativityVector = HighNormativityVector.TryReduceArray(vectorsLength);
        HighRadicalVector = HighRadicalVector.TryReduceArray(vectorsLength);
        HighSelfControlVector = HighSelfControlVector.TryReduceArray(vectorsLength);
        HighSensetVector = HighSensetVector.TryReduceArray(vectorsLength);
        HighSocialVector = HighSocialVector.TryReduceArray(vectorsLength);
        HighSuspicionVector = HighSuspicionVector.TryReduceArray(vectorsLength);
        HighTensionVector = HighTensionVector.TryReduceArray(vectorsLength);
        //ResetHighValuesList();

        ColumnsNames = ColumnsNames.TryReduceArray(vectorsLength);
    }
public override void ExtendVectors(int newVectorsLength)
    {
        LowAnxietyVector = LowAnxietyVector.TryExtendArray(newVectorsLength);
        LowNonconformVector = LowNonconformVector.TryExtendArray(newVectorsLength);
        LowCourageVector = LowCourageVector.TryExtendArray(newVectorsLength);
        LowDiplomVector = LowDiplomVector.TryExtendArray(newVectorsLength);
        LowDomintationVector = LowDomintationVector.TryExtendArray(newVectorsLength);
        LowDreamVector = LowDreamVector.TryExtendArray(newVectorsLength);
        LowEmStabVector = LowEmStabVector.TryExtendArray(newVectorsLength);
        LowExpressVector = LowExpressVector.TryExtendArray(newVectorsLength);
        LowIntellVector = LowIntellVector.TryExtendArray(newVectorsLength);
        LowNormativityVector = LowNormativityVector.TryExtendArray(newVectorsLength);
        LowRadicalVector = LowRadicalVector.TryExtendArray(newVectorsLength);
        LowSelfControlVector = LowSelfControlVector.TryExtendArray(newVectorsLength);
        LowSensetVector = LowSensetVector.TryExtendArray(newVectorsLength);
        LowSocialVector = LowSocialVector.TryExtendArray(newVectorsLength);
        LowSuspicionVector = LowSuspicionVector.TryExtendArray(newVectorsLength);
        LowTensionVector = LowTensionVector.TryExtendArray(newVectorsLength);
        //ResetLowValuesList();

        MidAnxietyVector = MidAnxietyVector.TryExtendArray(newVectorsLength);
        MidNonconformVector = MidNonconformVector.TryExtendArray(newVectorsLength);
        MidCourageVector = MidCourageVector.TryExtendArray(newVectorsLength);
        MidDiplomVector = MidDiplomVector.TryExtendArray(newVectorsLength);
        MidDomintationVector = MidDomintationVector.TryExtendArray(newVectorsLength);
        MidDreamVector = MidDreamVector.TryExtendArray(newVectorsLength);
        MidEmStabVector = MidEmStabVector.TryExtendArray(newVectorsLength);
        MidExpressVector = MidExpressVector.TryExtendArray(newVectorsLength);
        MidIntellVector = MidIntellVector.TryExtendArray(newVectorsLength);
        MidNormativityVector = MidNormativityVector.TryExtendArray(newVectorsLength);
        MidRadicalVector = MidRadicalVector.TryExtendArray(newVectorsLength);
        MidSelfControlVector = MidSelfControlVector.TryExtendArray(newVectorsLength);
        MidSensetVector = MidSensetVector.TryExtendArray(newVectorsLength);
        MidSocialVector = MidSocialVector.TryExtendArray(newVectorsLength);
        MidSuspicionVector = MidSuspicionVector.TryExtendArray(newVectorsLength);
        MidTensionVector = MidTensionVector.TryExtendArray(newVectorsLength);
        //ResetMidValuesList();

        HighAnxietyVector = HighAnxietyVector.TryExtendArray(newVectorsLength);
        HighNonconformVector = HighNonconformVector.TryExtendArray(newVectorsLength);
        HighCourageVector = HighCourageVector.TryExtendArray(newVectorsLength);
        HighDiplomVector = HighDiplomVector.TryExtendArray(newVectorsLength);
        HighDomintationVector = HighDomintationVector.TryExtendArray(newVectorsLength);
        HighDreamVector = HighDreamVector.TryExtendArray(newVectorsLength);
        HighEmStabVector = HighEmStabVector.TryExtendArray(newVectorsLength);
        HighExpressVector = HighExpressVector.TryExtendArray(newVectorsLength);
        HighIntellVector = HighIntellVector.TryExtendArray(newVectorsLength);
        HighNormativityVector = HighNormativityVector.TryExtendArray(newVectorsLength);
        HighRadicalVector = HighRadicalVector.TryExtendArray(newVectorsLength);
        HighSelfControlVector = HighSelfControlVector.TryExtendArray(newVectorsLength);
        HighSensetVector = HighSensetVector.TryExtendArray(newVectorsLength);
        HighSocialVector = HighSocialVector.TryExtendArray(newVectorsLength);
        HighSuspicionVector = HighSuspicionVector.TryExtendArray(newVectorsLength);
        HighTensionVector = HighTensionVector.TryExtendArray(newVectorsLength);
        //ResetHighValuesList();

        ColumnsNames = ColumnsNames.TryExtendArray(newVectorsLength);
    }
    public ListsViewDimension():base()
    {

    }
    public override void InitVectors(int colsCount)
    {
        columnsNames = new StringWrapper[colsCount];
        highCalmVector = new T[colsCount];
        highConformVector = new T[colsCount];
        highCourageVector = new T[colsCount];
        highDiplomVector = new T[colsCount];
        highDomintationVector = new T[colsCount];
        highDreamVector = new T[colsCount];
        highEmStabVector = new T[colsCount];
        highExpressVector = new T[colsCount];
        highIntellVector = new T[colsCount];
        highNormativityVector = new T[colsCount];
        highRadicalVector = new T[colsCount];
        highSelfControlVector = new T[colsCount];
        highSensetVector = new T[colsCount];
        highSocialVector = new T[colsCount];
        highSuspicionVector = new T[colsCount];
        highTensionVector = new T[colsCount];
        lowCalmVector = new T[colsCount];
        lowConformVector = new T[colsCount];
        lowCourageVector = new T[colsCount];
        lowDiplomVector = new T[colsCount];
        lowDomintationVector = new T[colsCount];
        lowDreamVector = new T[colsCount];
        lowEmStabVector = new T[colsCount];
        lowExpressVector = new T[colsCount];
        lowIntellVector = new T[colsCount];
        lowNormativityVector = new T[colsCount];
        lowRadicalVector = new T[colsCount];
        lowSelfControlVector = new T[colsCount];
        lowSensetVector = new T[colsCount];
        lowSocialVector = new T[colsCount];
        lowSuspicionVector = new T[colsCount];
        lowTensionVector = new T[colsCount];
        midCalmVector = new T[colsCount];
        midConformVector = new T[colsCount];
        midCourageVector = new T[colsCount];
        midDiplomVector = new T[colsCount];
        midDomintationVector = new T[colsCount];
        midDreamVector = new T[colsCount];
        midEmStabVector = new T[colsCount];
        midExpressVector = new T[colsCount];
        midIntellVector = new T[colsCount];
        midNormativityVector = new T[colsCount];
        midRadicalVector = new T[colsCount];
        midSelfControlVector = new T[colsCount];
        midSensetVector = new T[colsCount];
        midSocialVector = new T[colsCount];
        midSuspicionVector = new T[colsCount];
        midTensionVector = new T[colsCount];
        //ResetLowValuesList();
        //ResetMidValuesList();
        //ResetHighValuesList();
    }
    


    private void InitVectors(ListsViewDimension<T> referenceMatrix)
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

        //ResetLowValuesList();
        //ResetMidValuesList();
        //ResetHighValuesList();
    }


    public override StringWrapper[] ColumnsNames { get => columnsNames; set => columnsNames = value; }
    public override T[] HighAnxietyVector { get => highCalmVector; set => highCalmVector = value; }
    public override T[] HighCourageVector { get => highCourageVector; set => highCourageVector = value; }
    public override T[] HighDiplomVector { get => highDiplomVector; set => highDiplomVector = value; }
    public override T[] HighDomintationVector { get => highDomintationVector; set => highDomintationVector = value; }
    public override T[] HighDreamVector { get => highDreamVector; set => highDreamVector = value; }
    public override T[] HighEmStabVector { get => highEmStabVector; set => highEmStabVector = value; }
    public override T[] HighExpressVector { get => highExpressVector; set => highExpressVector = value; }
    public override T[] HighIntellVector { get => highIntellVector; set => highIntellVector = value; }
    public override T[] HighNonconformVector { get => highConformVector; set => highConformVector = value; }

    public override T[] HighNormativityVector { get => highNormativityVector; set => highNormativityVector = value; }

    public  override  T[] HighRadicalVector { get => highRadicalVector; set => highRadicalVector = value; }

    public  override  T[] HighSelfControlVector { get => highSelfControlVector; set => highSelfControlVector = value; }

    public  override  T[] HighSensetVector { get => highSensetVector; set => highSensetVector = value; }

    public  override  T[] HighSocialVector { get => highSocialVector; set => highSocialVector = value; }

    public  override  T[] HighSuspicionVector { get => highSuspicionVector; set => highSuspicionVector = value; }

    public  override  T[] HighTensionVector { get => highTensionVector; set => highTensionVector = value; }


    public  override  T[] LowAnxietyVector { get => lowCalmVector; set => lowCalmVector = value; }

    public  override  T[] LowCourageVector { get => lowCourageVector; set => lowCourageVector = value; }

    public  override  T[] LowDiplomVector { get => lowDiplomVector; set => lowDiplomVector = value; }

    public  override  T[] LowDomintationVector { get => lowDomintationVector; set => lowDomintationVector = value; }

    public  override  T[] LowDreamVector { get => lowDreamVector; set => lowDreamVector = value; }

    public  override  T[] LowEmStabVector { get => lowEmStabVector; set => lowEmStabVector = value; }

    public  override  T[] LowExpressVector { get => lowExpressVector; set => lowExpressVector = value; }

    public  override  T[] LowIntellVector { get => lowIntellVector; set => lowIntellVector = value; }

    public  override  T[] LowNonconformVector { get => lowConformVector; set => lowConformVector = value; }

    public  override  T[] LowNormativityVector { get => lowNormativityVector; set => lowNormativityVector = value; }

    public  override  T[] LowRadicalVector { get => lowRadicalVector; set => lowRadicalVector = value; }

    public  override  T[] LowSelfControlVector { get => lowSelfControlVector; set => lowSelfControlVector = value; }

    public  override  T[] LowSensetVector { get => lowSensetVector; set => lowSensetVector = value; }

    public  override  T[] LowSocialVector { get => lowSocialVector; set => lowSocialVector = value; }

    public  override  T[] LowSuspicionVector { get => lowSuspicionVector; set => lowSuspicionVector = value; }

    public  override  T[] LowTensionVector { get => lowTensionVector; set => lowTensionVector = value; }


    public  override  T[] MidAnxietyVector { get => midCalmVector; set => midCalmVector = value; }

    public  override  T[] MidCourageVector { get => midCourageVector; set => midCourageVector = value; }

    public  override  T[] MidDiplomVector { get => midDiplomVector; set => midDiplomVector = value; }


    public  override  T[] MidDomintationVector { get => midDomintationVector; set => midDomintationVector = value; }

    public  override  T[] MidDreamVector { get => midDreamVector; set => midDreamVector = value; }

    public  override  T[] MidEmStabVector { get => midEmStabVector; set => midEmStabVector = value; }

    public  override  T[] MidExpressVector { get => midExpressVector; set => midExpressVector = value; }

    public  override  T[] MidIntellVector { get => midIntellVector; set => midIntellVector = value; }

    public  override  T[] MidNonconformVector { get => midConformVector; set => midConformVector = value; }

    public  override  T[] MidNormativityVector { get => midNormativityVector; set => midNormativityVector = value; }

    public  override  T[] MidRadicalVector { get => midRadicalVector; set => midRadicalVector = value; }

    public  override  T[] MidSelfControlVector { get => midSelfControlVector; set => midSelfControlVector = value; }

    public  override  T[] MidSensetVector { get => midSensetVector; set => midSensetVector = value; }

    public  override  T[] MidSocialVector { get => midSocialVector; set => midSocialVector = value; }

    public  override  T[] MidSuspicionVector { get => midSuspicionVector; set => midSuspicionVector = value; }

    public  override  T[] MidTensionVector { get => midTensionVector; set => midTensionVector = value; }
   

    public ListsViewDimension(int colsCount)
    {
        InitVectors(colsCount);
    }

    public ListsViewDimension(ListsViewDimension<T> referenceMatrix)
    {
        InitVectors(referenceMatrix);
        DimensionName = referenceMatrix.DimensionName;
    }



    
   
}