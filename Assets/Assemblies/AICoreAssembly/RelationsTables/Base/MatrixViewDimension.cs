using Sirenix.OdinInspector;
using UnityEngine;

public class MatrixViewDimension<TContent>: ViewDimensionBase<TContent>
{
    #region fields
    [SerializeField, ListDrawerSettings(IsReadOnly = true)]
    public override StringWrapper[] ColumnsNames { get => columnsNames; set => columnsNames = value; }
    #region calm
    [SerializeField, HideInInspector] protected TContent[,] calmMatrix;
    [ShowInInspector, TableMatrix(IsReadOnly = true), FoldoutGroup("Calmness")]
    public virtual TContent[,] CalmMatrix { get => calmMatrix; protected set => calmMatrix = value; }
    public bool IsOverrided()
    {
        return !GetType().GetProperty("CalmMatrix").DeclaringType.IsEquivalentTo(GetType());
    }
    #endregion
    #region conform
    [SerializeField, HideInInspector] protected TContent[,] conformMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Nonconformism")]
    public virtual TContent[,] NonconformMatrix { get => conformMatrix; protected set => conformMatrix = value; }
    #endregion
    #region courage
    [SerializeField, HideInInspector] protected TContent[,] courageMatrix;
    [ShowInInspector,   TableMatrix(IsReadOnly = true), FoldoutGroup("Courage")]
    public virtual TContent[,] CourageMatrix { get => courageMatrix; protected set => courageMatrix = value; }
    #endregion
    #region dipl
    [SerializeField, HideInInspector] protected TContent[,] diplomMatrix;
    [ShowInInspector, TableMatrix(IsReadOnly = true), FoldoutGroup("Diplomacy")]
    public virtual TContent[,] DiplomMatrix { get => diplomMatrix; protected set => diplomMatrix = value; }
    #endregion
    #region dom
    [SerializeField, HideInInspector] protected TContent[,] domintationMatrix;
    [ShowInInspector,   TableMatrix(IsReadOnly = true), FoldoutGroup("Domination")]
    public virtual TContent[,] DomintationMatrix { get => domintationMatrix;protected set => domintationMatrix = value; }
    #endregion
    #region dream
    [SerializeField, HideInInspector] protected TContent[,] dreamMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Dreaminess")]
    public virtual TContent[,] DreamMatrix { get => dreamMatrix; protected set => dreamMatrix = value; }
    #endregion
    #region stab
    [SerializeField, HideInInspector] protected TContent[,] emStabMatrix;
    [ShowInInspector, TableMatrix(IsReadOnly = true), FoldoutGroup("Emotional stability")]
    public virtual TContent[,] EmStabMatrix { get => emStabMatrix; protected set => emStabMatrix = value; }
    #endregion
    #region expr
    [SerializeField, HideInInspector] protected TContent[,] expressMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Expressivenes")]
    public virtual TContent[,] ExpressMatrix { get => expressMatrix; protected set => expressMatrix = value; } 
    #endregion
    #region intel
    [SerializeField, HideInInspector] protected TContent[,] intellMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Intelligence")]
    public virtual TContent[,] IntellMatrix { get => intellMatrix; protected set => intellMatrix = value; }
    #endregion
    #region norm
    [SerializeField, HideInInspector] protected TContent[,] normativityMatrix;
    [ShowInInspector,   TableMatrix(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")]
    public virtual TContent[,] NormativityMatrix { get => normativityMatrix; protected set => normativityMatrix = value; }
    #endregion
    #region radi
    [SerializeField, HideInInspector] protected TContent[,] radicalMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Radicalism")]
    public virtual TContent[,] RadicalMatrix { get => radicalMatrix; protected set => radicalMatrix = value; }
    #endregion
    #region self
    [SerializeField, HideInInspector] protected TContent[,] selfControlMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Selfcontrol")]
    public virtual TContent[,] SelfControlMatrix { get => selfControlMatrix; protected set => selfControlMatrix = value; }
    #endregion
    #region senset
    [SerializeField, HideInInspector] protected TContent[,] sensetMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Sensetivity")]
    public virtual TContent[,] SensetMatrix { get => sensetMatrix; protected set => sensetMatrix = value; }
    #endregion
    #region soc
    [SerializeField, HideInInspector] protected TContent[,] socialMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Sociability")]
    public virtual TContent[,] SocialMatrix { get => socialMatrix; protected set => socialMatrix = value; }
    #endregion
    #region susp
    [SerializeField, HideInInspector] protected TContent[,] suspicionMatrix;
    [ShowInInspector, TableMatrix(IsReadOnly = true), FoldoutGroup("Suspicion")]
    public virtual TContent[,] SuspicionMatrix { get => suspicionMatrix; protected set => suspicionMatrix = value; }
    #endregion
    #region tens
    [SerializeField, HideInInspector] protected TContent[,] tensionMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Tension")]
    public virtual TContent[,] TensionMatrix { get => tensionMatrix; protected set => tensionMatrix = value; }
    #endregion
    #endregion

    public MatrixViewDimension():base()
    {

    }
    public override void InitVectors(int colsCount)
    {
        int matrixRowsCount = 3;
        columnsNames = new StringWrapper[colsCount];
        for (int i = 0; i < columnsNames.Length; i++)
            columnsNames[i] = new StringWrapper();

        calmMatrix = new TContent[colsCount, matrixRowsCount];
        conformMatrix = new TContent[colsCount, matrixRowsCount];
        courageMatrix = new TContent[colsCount, matrixRowsCount];
        diplomMatrix = new TContent[colsCount, matrixRowsCount];
        domintationMatrix = new TContent[colsCount, matrixRowsCount];
        dreamMatrix = new TContent[colsCount, matrixRowsCount];
        emStabMatrix = new TContent[colsCount, matrixRowsCount];
        expressMatrix = new TContent[colsCount, matrixRowsCount];
        intellMatrix = new TContent[colsCount, matrixRowsCount];
        normativityMatrix = new TContent[colsCount, matrixRowsCount];
        radicalMatrix = new TContent[colsCount, matrixRowsCount];
        selfControlMatrix = new TContent[colsCount, matrixRowsCount];
        sensetMatrix = new TContent[colsCount, matrixRowsCount];
        socialMatrix = new TContent[colsCount, matrixRowsCount];
        suspicionMatrix = new TContent[colsCount, matrixRowsCount];
        tensionMatrix = new TContent[colsCount, matrixRowsCount];

    }
   

    public void InitVectors(MatrixViewDimension<TContent> referenceMatrix)
    {
        referenceMatrix.ColumnsNames.CopyTo(ref columnsNames);
        referenceMatrix.calmMatrix.CopyTo(ref calmMatrix);
        referenceMatrix.conformMatrix.CopyTo(ref conformMatrix);
        referenceMatrix.courageMatrix.CopyTo(ref courageMatrix);
        referenceMatrix.diplomMatrix.CopyTo(ref diplomMatrix);
        referenceMatrix.domintationMatrix.CopyTo(ref domintationMatrix);
        referenceMatrix.dreamMatrix.CopyTo(ref dreamMatrix);
        referenceMatrix.emStabMatrix.CopyTo(ref emStabMatrix);
        referenceMatrix.expressMatrix.CopyTo(ref expressMatrix);
        referenceMatrix.intellMatrix.CopyTo(ref intellMatrix);
        referenceMatrix.normativityMatrix.CopyTo(ref normativityMatrix);
        referenceMatrix.radicalMatrix.CopyTo(ref radicalMatrix);
        referenceMatrix.selfControlMatrix.CopyTo(ref selfControlMatrix);
        referenceMatrix.sensetMatrix.CopyTo(ref sensetMatrix);
        referenceMatrix.socialMatrix.CopyTo(ref socialMatrix);
        referenceMatrix.suspicionMatrix.CopyTo(ref suspicionMatrix);
        referenceMatrix.tensionMatrix.CopyTo(ref tensionMatrix);      
    }


    public override TContent[] HighAnxietyVector {
        get => calmMatrix.GetRowFromMatrix(2);
        set => calmMatrix.InsertRow(value, 2);
    }
   

    public override TContent[] HighCourageVector
    {
        get => courageMatrix.GetRowFromMatrix(2);
        set => courageMatrix.InsertRow(value, 2);
    }
    public override TContent[] HighDiplomVector
    {
        get => diplomMatrix.GetRowFromMatrix(2);
        set => diplomMatrix.InsertRow(value, 2);
    }
    public override TContent[] HighDomintationVector
    {
        get => domintationMatrix.GetRowFromMatrix(2);
        set => domintationMatrix.InsertRow(value, 2);
    }
    public override TContent[] HighDreamVector
    {
        get => dreamMatrix.GetRowFromMatrix(2);
        set => dreamMatrix.InsertRow(value, 2);
    }
    public override TContent[] HighEmStabVector
    {
        get => emStabMatrix.GetRowFromMatrix(2);
        set => emStabMatrix.InsertRow(value, 2);
    }
    public override TContent[] HighExpressVector
    {
        get => expressMatrix.GetRowFromMatrix(2);
        set => expressMatrix.InsertRow(value, 2);
    }
    public override TContent[] HighIntellVector
    {
        get => intellMatrix.GetRowFromMatrix(2);
        set => intellMatrix.InsertRow(value, 2);
    }
    public override TContent[] HighNonconformVector
    {
        get => conformMatrix.GetRowFromMatrix(2);
        set => conformMatrix.InsertRow(value, 2);
    }

    public override TContent[] HighNormativityVector
    {
        get => normativityMatrix.GetRowFromMatrix(2);
        set => normativityMatrix.InsertRow(value, 2);
    }

    public override TContent[] HighRadicalVector
    {
        get => radicalMatrix.GetRowFromMatrix(2);
        set => radicalMatrix.InsertRow(value, 2);
    }

    public override TContent[] HighSelfControlVector
    {
        get => selfControlMatrix.GetRowFromMatrix(2);
        set => selfControlMatrix.InsertRow(value, 2);
    }

    public override TContent[] HighSensetVector
    {
        get => sensetMatrix.GetRowFromMatrix(2);
        set => sensetMatrix.InsertRow(value, 2);
    }

    public override TContent[] HighSocialVector
    {
        get => socialMatrix.GetRowFromMatrix(2);
        set => socialMatrix.InsertRow(value, 2);
    }

    public override TContent[] HighSuspicionVector
    {
        get => suspicionMatrix.GetRowFromMatrix(2);
        set => suspicionMatrix.InsertRow(value, 2);
    }

    public override TContent[] HighTensionVector
    {
        get => tensionMatrix.GetRowFromMatrix(2);
        set => tensionMatrix.InsertRow(value, 2);
    }


    public override TContent[] LowAnxietyVector
    {
        get => calmMatrix.GetRowFromMatrix(0);
        set => calmMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowCourageVector {
        get => courageMatrix.GetRowFromMatrix(0);
        set => courageMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowDiplomVector {
        get => diplomMatrix.GetRowFromMatrix(0);
        set => diplomMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowDomintationVector {
        get => domintationMatrix.GetRowFromMatrix(0);
        set => domintationMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowDreamVector {
        get => dreamMatrix.GetRowFromMatrix(0);
        set => dreamMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowEmStabVector {
        get => emStabMatrix.GetRowFromMatrix(0);
        set => emStabMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowExpressVector {
        get => expressMatrix.GetRowFromMatrix(0);
        set => expressMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowIntellVector {
        get => intellMatrix.GetRowFromMatrix(0);
        set => intellMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowNonconformVector {
        get => conformMatrix.GetRowFromMatrix(0);
        set => conformMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowNormativityVector {
        get => normativityMatrix.GetRowFromMatrix(0);
        set => normativityMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowRadicalVector {
        get => radicalMatrix.GetRowFromMatrix(0);
        set => radicalMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowSelfControlVector {
        get => selfControlMatrix.GetRowFromMatrix(0);
        set => selfControlMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowSensetVector {
        get => sensetMatrix.GetRowFromMatrix(0);
        set => sensetMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowSocialVector {
        get => socialMatrix.GetRowFromMatrix(0);
        set => socialMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowSuspicionVector {
        get => suspicionMatrix.GetRowFromMatrix(0);
        set => suspicionMatrix.InsertRow(value, 0);
    }

    public override TContent[] LowTensionVector {
        get => tensionMatrix.GetRowFromMatrix(0);
        set => tensionMatrix.InsertRow(value, 0);
    }


    public override TContent[] MidAnxietyVector
    {
        get => calmMatrix.GetRowFromMatrix(1);
        set => calmMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidCourageVector
    {
        get => courageMatrix.GetRowFromMatrix(1);
        set => courageMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidDiplomVector
    {
        get => diplomMatrix.GetRowFromMatrix(1);
        set => diplomMatrix.InsertRow(value, 1);
    }


    public override TContent[] MidDomintationVector
    {
        get => domintationMatrix.GetRowFromMatrix(1);
        set => domintationMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidDreamVector
    {
        get => dreamMatrix.GetRowFromMatrix(1);
        set => dreamMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidEmStabVector
    {
        get => emStabMatrix.GetRowFromMatrix(1);
        set => emStabMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidExpressVector
    {
        get => expressMatrix.GetRowFromMatrix(1);
        set => expressMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidIntellVector
    {
        get => intellMatrix.GetRowFromMatrix(1);
        set => intellMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidNonconformVector
    {
        get => conformMatrix.GetRowFromMatrix(1);
        set => conformMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidNormativityVector
    {
        get => normativityMatrix.GetRowFromMatrix(1);
        set => normativityMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidRadicalVector
    {
        get => radicalMatrix.GetRowFromMatrix(1);
        set => radicalMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidSelfControlVector
    {
        get => selfControlMatrix.GetRowFromMatrix(1);
        set => selfControlMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidSensetVector
    {
        get => sensetMatrix.GetRowFromMatrix(1);
        set => sensetMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidSocialVector
    {
        get => socialMatrix.GetRowFromMatrix(1);
        set => socialMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidSuspicionVector
    {
        get => suspicionMatrix.GetRowFromMatrix(1);
        set => suspicionMatrix.InsertRow(value, 1);
    }

    public override TContent[] MidTensionVector
    {
        get => tensionMatrix.GetRowFromMatrix(1);
        set => tensionMatrix.InsertRow(value, 1);
    }
   

    public MatrixViewDimension(int colsCount)
    {
        InitVectors(colsCount);
    }

    public MatrixViewDimension(MatrixViewDimension<TContent> referenceMatrix)
    {
        InitVectors(referenceMatrix);
        PageName = referenceMatrix.PageName;
    }
   

    public override void ExtendVectors(int newVectorsLength)
    {
        calmMatrix = calmMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        conformMatrix = conformMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        courageMatrix = courageMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        diplomMatrix = diplomMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        domintationMatrix = domintationMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        dreamMatrix = dreamMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        emStabMatrix = emStabMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        expressMatrix = expressMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        intellMatrix = intellMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        normativityMatrix = normativityMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        radicalMatrix = radicalMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        selfControlMatrix = selfControlMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        sensetMatrix = sensetMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        socialMatrix = socialMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        suspicionMatrix = suspicionMatrix.TryExtendArrayWithCopy(3, newVectorsLength);
        tensionMatrix = tensionMatrix.TryExtendArrayWithCopy(3, newVectorsLength);

        ColumnsNames = ColumnsNames.TryExtendArray(newVectorsLength);
    }
    

    public override void ReduceVectors(int vectorsLength)
    {
        calmMatrix = calmMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        conformMatrix = conformMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        courageMatrix = courageMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        diplomMatrix = diplomMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        domintationMatrix = domintationMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        dreamMatrix = dreamMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        emStabMatrix = emStabMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        expressMatrix = expressMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        intellMatrix = intellMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        normativityMatrix = normativityMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        radicalMatrix = radicalMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        selfControlMatrix = selfControlMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        sensetMatrix = sensetMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        socialMatrix = socialMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        suspicionMatrix = suspicionMatrix.TryReduceArrayWithCopy(3, vectorsLength);
        tensionMatrix = tensionMatrix.TryReduceArrayWithCopy(3, vectorsLength);

        ColumnsNames = ColumnsNames.TryReduceArray(vectorsLength);
    }   
}
