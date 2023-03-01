using System;
using UnityEngine;

[Serializable]
public abstract class ArraysViewDimensionBase<TContent> : ViewDimensionBase<TContent>
{
    [SerializeField, HideInInspector]
    protected TContent[] lowCalmVector;
    [SerializeField, HideInInspector]
    protected TContent[] midCalmVector;
    [SerializeField, HideInInspector]
    protected TContent[] highCalmVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowCourageVector;
    [SerializeField, HideInInspector]
    protected TContent[] midCourageVector;
    [SerializeField, HideInInspector]
    protected TContent[] highCourageVector;


    [SerializeField, HideInInspector]
    protected TContent[] lowDiplomVector;
    [SerializeField, HideInInspector]
    protected TContent[] midDiplomVector;
    [SerializeField, HideInInspector]
    protected TContent[] highDiplomVector;


    [SerializeField, HideInInspector]
    protected TContent[] lowDomintationVector;
    [SerializeField, HideInInspector]
    protected TContent[] midDomintationVector;
    [SerializeField, HideInInspector]
    protected TContent[] highDomintationVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowDreamVector;
    [SerializeField, HideInInspector]
    protected TContent[] midDreamVector;
    [SerializeField, HideInInspector]
    protected TContent[] highDreamVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowEmStabVector;
    [SerializeField, HideInInspector]
    protected TContent[] midEmStabVector;
    [SerializeField, HideInInspector]
    protected TContent[] highEmStabVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowExpressVector;
    [SerializeField, HideInInspector]
    protected TContent[] midExpressVector;
    [SerializeField, HideInInspector]
    protected TContent[] highExpressVector;


    [SerializeField, HideInInspector]
    protected TContent[] lowIntellVector;
    [SerializeField, HideInInspector]
    protected TContent[] midIntellVector;
    [SerializeField, HideInInspector]
    protected TContent[] highIntellVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowConformVector;
    [SerializeField, HideInInspector]
    protected TContent[] midConformVector;
    [SerializeField, HideInInspector]
    protected TContent[] highConformVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowNormativityVector;
    [SerializeField, HideInInspector]
    protected TContent[] midNormativityVector;
    [SerializeField, HideInInspector]
    protected TContent[] highNormativityVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowRadicalVector;
    [SerializeField, HideInInspector]
    protected TContent[] midRadicalVector;
    [SerializeField, HideInInspector]
    protected TContent[] highRadicalVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowSelfControlVector;
    [SerializeField, HideInInspector]
    protected TContent[] midSelfControlVector;
    [SerializeField, HideInInspector]
    protected TContent[] highSelfControlVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowSensetVector;
    [SerializeField, HideInInspector]
    protected TContent[] midSensetVector;
    [SerializeField, HideInInspector]
    protected TContent[] highSensetVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowSocialVector;
    [SerializeField, HideInInspector]
    protected TContent[] midSocialVector;
    [SerializeField, HideInInspector]
    protected TContent[] highSocialVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowSuspicionVector;
    [SerializeField, HideInInspector]
    protected TContent[] midSuspicionVector;
    [SerializeField, HideInInspector]
    protected TContent[] highSuspicionVector;

    [SerializeField, HideInInspector]
    protected TContent[] lowTensionVector;
    [SerializeField, HideInInspector]
    protected TContent[] midTensionVector;
    [SerializeField, HideInInspector]
    protected TContent[] highTensionVector;

    public override void InitVectors(int colsCount)
    {
        columnsNames = new StringWrapper[colsCount];
        highCalmVector = new TContent[colsCount];
        highConformVector = new TContent[colsCount];
        highCourageVector = new TContent[colsCount];
        highDiplomVector = new TContent[colsCount];
        highDomintationVector = new TContent[colsCount];
        highDreamVector = new TContent[colsCount];
        highEmStabVector = new TContent[colsCount];
        highExpressVector = new TContent[colsCount];
        highIntellVector = new TContent[colsCount];
        highNormativityVector = new TContent[colsCount];
        highRadicalVector = new TContent[colsCount];
        highSelfControlVector = new TContent[colsCount];
        highSensetVector = new TContent[colsCount];
        highSocialVector = new TContent[colsCount];
        highSuspicionVector = new TContent[colsCount];
        highTensionVector = new TContent[colsCount];
        lowCalmVector = new TContent[colsCount];
        lowConformVector = new TContent[colsCount];
        lowCourageVector = new TContent[colsCount];
        lowDiplomVector = new TContent[colsCount];
        lowDomintationVector = new TContent[colsCount];
        lowDreamVector = new TContent[colsCount];
        lowEmStabVector = new TContent[colsCount];
        lowExpressVector = new TContent[colsCount];
        lowIntellVector = new TContent[colsCount];
        lowNormativityVector = new TContent[colsCount];
        lowRadicalVector = new TContent[colsCount];
        lowSelfControlVector = new TContent[colsCount];
        lowSensetVector = new TContent[colsCount];
        lowSocialVector = new TContent[colsCount];
        lowSuspicionVector = new TContent[colsCount];
        lowTensionVector = new TContent[colsCount];
        midCalmVector = new TContent[colsCount];
        midConformVector = new TContent[colsCount];
        midCourageVector = new TContent[colsCount];
        midDiplomVector = new TContent[colsCount];
        midDomintationVector = new TContent[colsCount];
        midDreamVector = new TContent[colsCount];
        midEmStabVector = new TContent[colsCount];
        midExpressVector = new TContent[colsCount];
        midIntellVector = new TContent[colsCount];
        midNormativityVector = new TContent[colsCount];
        midRadicalVector = new TContent[colsCount];
        midSelfControlVector = new TContent[colsCount];
        midSensetVector = new TContent[colsCount];
        midSocialVector = new TContent[colsCount];
        midSuspicionVector = new TContent[colsCount];
        midTensionVector = new TContent[colsCount];
        //ResetLowValuesList();
        //ResetMidValuesList();
        //ResetHighValuesList();
    }
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
}
