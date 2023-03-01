using BehaviourModel;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixViewDimension<T>: ViewDimensionBase<T>
{
    #region fields
    [SerializeField, ListDrawerSettings(IsReadOnly = true)]
    public override StringWrapper[] ColumnsNames { get => columnsNames; set => columnsNames = value; }
    //private StringWrapper[] columnsNames;
    #region calm
    [SerializeField, HideInInspector] protected T[,] calmMatrix;
    [ShowInInspector, TableMatrix(IsReadOnly = true), FoldoutGroup("Calmness")]
    public virtual T[,] CalmMatrix { get => calmMatrix; protected set => calmMatrix = value; }
    public bool IsOverrided()
    {
        var t = GetType();
        return !GetType().GetProperty("CalmMatrix").DeclaringType.IsEquivalentTo(GetType());
    }
    #endregion
    #region conform
    [SerializeField, HideInInspector] protected T[,] conformMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Nonconformism")]
    public virtual T[,] NonconformMatrix { get => conformMatrix; protected set => conformMatrix = value; }
    #endregion
    #region courage
    [SerializeField, HideInInspector] protected T[,] courageMatrix;
    [ShowInInspector,   TableMatrix(IsReadOnly = true), FoldoutGroup("Courage")]
    public virtual T[,] CourageMatrix { get => courageMatrix; protected set => courageMatrix = value; }
    #endregion
    #region dipl
    [SerializeField, HideInInspector] protected T[,] diplomMatrix;
    [ShowInInspector, TableMatrix(IsReadOnly = true), FoldoutGroup("Diplomacy")]
    public virtual T[,] DiplomMatrix { get => diplomMatrix; protected set => diplomMatrix = value; }
    #endregion
    #region dom
    [SerializeField, HideInInspector] protected T[,] domintationMatrix;
    [ShowInInspector,   TableMatrix(IsReadOnly = true), FoldoutGroup("Domination")]
    public virtual T[,] DomintationMatrix { get => domintationMatrix;protected set => domintationMatrix = value; }
    #endregion
    #region dream
    [SerializeField, HideInInspector] protected T[,] dreamMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Dreaminess")]
    public virtual T[,] DreamMatrix { get => dreamMatrix; protected set => dreamMatrix = value; }
    #endregion
    #region stab
    [SerializeField, HideInInspector] protected T[,] emStabMatrix;
    [ShowInInspector, TableMatrix(IsReadOnly = true), FoldoutGroup("Emotional stability")]
    public virtual T[,] EmStabMatrix { get => emStabMatrix; protected set => emStabMatrix = value; }
    #endregion
    #region expr
    [SerializeField, HideInInspector] protected T[,] expressMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Expressivenes")]
    public virtual T[,] ExpressMatrix { get => expressMatrix; protected set => expressMatrix = value; } 
    #endregion
    #region intel
    [SerializeField, HideInInspector] protected T[,] intellMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Intelligence")]
    public virtual T[,] IntellMatrix { get => intellMatrix; protected set => intellMatrix = value; }
    #endregion
    #region norm
    [SerializeField, HideInInspector] protected T[,] normativityMatrix;
    [ShowInInspector,   TableMatrix(IsReadOnly = true), FoldoutGroup("Normativity of behaviour")]
    public virtual T[,] NormativityMatrix { get => normativityMatrix; protected set => normativityMatrix = value; }
    #endregion
    #region radi
    [SerializeField, HideInInspector] protected T[,] radicalMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Radicalism")]
    public virtual T[,] RadicalMatrix { get => radicalMatrix; protected set => radicalMatrix = value; }
    #endregion
    #region self
    [SerializeField, HideInInspector] protected T[,] selfControlMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Selfcontrol")]
    public virtual T[,] SelfControlMatrix { get => selfControlMatrix; protected set => selfControlMatrix = value; }
    #endregion
    #region senset
    [SerializeField, HideInInspector] protected T[,] sensetMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Sensetivity")]
    public virtual T[,] SensetMatrix { get => sensetMatrix; protected set => sensetMatrix = value; }
    #endregion
    #region soc
    [SerializeField, HideInInspector] protected T[,] socialMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Sociability")]
    public virtual T[,] SocialMatrix { get => socialMatrix; protected set => socialMatrix = value; }
    #endregion
    #region susp
    [SerializeField, HideInInspector] protected T[,] suspicionMatrix;
    [ShowInInspector, TableMatrix(IsReadOnly = true), FoldoutGroup("Suspicion")]
    public virtual T[,] SuspicionMatrix { get => suspicionMatrix; protected set => suspicionMatrix = value; }
    #endregion
    #region tens
    [SerializeField, HideInInspector] protected T[,] tensionMatrix;
    [ShowInInspector,  TableMatrix(IsReadOnly = true), FoldoutGroup("Tension")]
    public virtual T[,] TensionMatrix { get => tensionMatrix; protected set => tensionMatrix = value; }
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

        calmMatrix = new T[colsCount, matrixRowsCount];
        conformMatrix = new T[colsCount, matrixRowsCount];
        courageMatrix = new T[colsCount, matrixRowsCount];
        diplomMatrix = new T[colsCount, matrixRowsCount];
        domintationMatrix = new T[colsCount, matrixRowsCount];
        dreamMatrix = new T[colsCount, matrixRowsCount];
        emStabMatrix = new T[colsCount, matrixRowsCount];
        expressMatrix = new T[colsCount, matrixRowsCount];
        intellMatrix = new T[colsCount, matrixRowsCount];
        normativityMatrix = new T[colsCount, matrixRowsCount];
        radicalMatrix = new T[colsCount, matrixRowsCount];
        selfControlMatrix = new T[colsCount, matrixRowsCount];
        sensetMatrix = new T[colsCount, matrixRowsCount];
        socialMatrix = new T[colsCount, matrixRowsCount];
        suspicionMatrix = new T[colsCount, matrixRowsCount];
        tensionMatrix = new T[colsCount, matrixRowsCount];

    }
   

    public void InitVectors(MatrixViewDimension<T> referenceMatrix)
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


    public override T[] HighAnxietyVector {
        get => calmMatrix.GetRowFromMatrix(2);
        set => calmMatrix.InsertRow(value, 2);
    }
   

    public override T[] HighCourageVector
    {
        get => courageMatrix.GetRowFromMatrix(2);
        set => courageMatrix.InsertRow(value, 2);
    }
    public override T[] HighDiplomVector
    {
        get => diplomMatrix.GetRowFromMatrix(2);
        set => diplomMatrix.InsertRow(value, 2);
    }
    public override T[] HighDomintationVector
    {
        get => domintationMatrix.GetRowFromMatrix(2);
        set => domintationMatrix.InsertRow(value, 2);
    }
    public override T[] HighDreamVector
    {
        get => dreamMatrix.GetRowFromMatrix(2);
        set => dreamMatrix.InsertRow(value, 2);
    }
    public override T[] HighEmStabVector
    {
        get => emStabMatrix.GetRowFromMatrix(2);
        set => emStabMatrix.InsertRow(value, 2);
    }
    public override T[] HighExpressVector
    {
        get => expressMatrix.GetRowFromMatrix(2);
        set => expressMatrix.InsertRow(value, 2);
    }
    public override T[] HighIntellVector
    {
        get => intellMatrix.GetRowFromMatrix(2);
        set => intellMatrix.InsertRow(value, 2);
    }
    public override T[] HighNonconformVector
    {
        get => conformMatrix.GetRowFromMatrix(2);
        set => conformMatrix.InsertRow(value, 2);
    }

    public override T[] HighNormativityVector
    {
        get => normativityMatrix.GetRowFromMatrix(2);
        set => normativityMatrix.InsertRow(value, 2);
    }

    public override T[] HighRadicalVector
    {
        get => radicalMatrix.GetRowFromMatrix(2);
        set => radicalMatrix.InsertRow(value, 2);
    }

    public override T[] HighSelfControlVector
    {
        get => selfControlMatrix.GetRowFromMatrix(2);
        set => selfControlMatrix.InsertRow(value, 2);
    }

    public override T[] HighSensetVector
    {
        get => sensetMatrix.GetRowFromMatrix(2);
        set => sensetMatrix.InsertRow(value, 2);
    }

    public override T[] HighSocialVector
    {
        get => socialMatrix.GetRowFromMatrix(2);
        set => socialMatrix.InsertRow(value, 2);
    }

    public override T[] HighSuspicionVector
    {
        get => suspicionMatrix.GetRowFromMatrix(2);
        set => suspicionMatrix.InsertRow(value, 2);
    }

    public override T[] HighTensionVector
    {
        get => tensionMatrix.GetRowFromMatrix(2);
        set => tensionMatrix.InsertRow(value, 2);
    }


    public override T[] LowAnxietyVector
    {
        get => calmMatrix.GetRowFromMatrix(0);
        set => calmMatrix.InsertRow(value, 0);
    }

    public override T[] LowCourageVector {
        get => courageMatrix.GetRowFromMatrix(0);
        set => courageMatrix.InsertRow(value, 0);
    }

    public override T[] LowDiplomVector {
        get => diplomMatrix.GetRowFromMatrix(0);
        set => diplomMatrix.InsertRow(value, 0);
    }

    public override T[] LowDomintationVector {
        get => domintationMatrix.GetRowFromMatrix(0);
        set => domintationMatrix.InsertRow(value, 0);
    }

    public override T[] LowDreamVector {
        get => dreamMatrix.GetRowFromMatrix(0);
        set => dreamMatrix.InsertRow(value, 0);
    }

    public override T[] LowEmStabVector {
        get => emStabMatrix.GetRowFromMatrix(0);
        set => emStabMatrix.InsertRow(value, 0);
    }

    public override T[] LowExpressVector {
        get => expressMatrix.GetRowFromMatrix(0);
        set => expressMatrix.InsertRow(value, 0);
    }

    public override T[] LowIntellVector {
        get => intellMatrix.GetRowFromMatrix(0);
        set => intellMatrix.InsertRow(value, 0);
    }

    public override T[] LowNonconformVector {
        get => conformMatrix.GetRowFromMatrix(0);
        set => conformMatrix.InsertRow(value, 0);
    }

    public override T[] LowNormativityVector {
        get => normativityMatrix.GetRowFromMatrix(0);
        set => normativityMatrix.InsertRow(value, 0);
    }

    public override T[] LowRadicalVector {
        get => radicalMatrix.GetRowFromMatrix(0);
        set => radicalMatrix.InsertRow(value, 0);
    }

    public override T[] LowSelfControlVector {
        get => selfControlMatrix.GetRowFromMatrix(0);
        set => selfControlMatrix.InsertRow(value, 0);
    }

    public override T[] LowSensetVector {
        get => sensetMatrix.GetRowFromMatrix(0);
        set => sensetMatrix.InsertRow(value, 0);
    }

    public override T[] LowSocialVector {
        get => socialMatrix.GetRowFromMatrix(0);
        set => socialMatrix.InsertRow(value, 0);
    }

    public override T[] LowSuspicionVector {
        get => suspicionMatrix.GetRowFromMatrix(0);
        set => suspicionMatrix.InsertRow(value, 0);
    }

    public override T[] LowTensionVector {
        get => tensionMatrix.GetRowFromMatrix(0);
        set => tensionMatrix.InsertRow(value, 0);
    }


    public override T[] MidAnxietyVector
    {
        get => calmMatrix.GetRowFromMatrix(1);
        set => calmMatrix.InsertRow(value, 1);
    }

    public override T[] MidCourageVector
    {
        get => courageMatrix.GetRowFromMatrix(1);
        set => courageMatrix.InsertRow(value, 1);
    }

    public override T[] MidDiplomVector
    {
        get => diplomMatrix.GetRowFromMatrix(1);
        set => diplomMatrix.InsertRow(value, 1);
    }


    public override T[] MidDomintationVector
    {
        get => domintationMatrix.GetRowFromMatrix(1);
        set => domintationMatrix.InsertRow(value, 1);
    }

    public override T[] MidDreamVector
    {
        get => dreamMatrix.GetRowFromMatrix(1);
        set => dreamMatrix.InsertRow(value, 1);
    }

    public override T[] MidEmStabVector
    {
        get => emStabMatrix.GetRowFromMatrix(1);
        set => emStabMatrix.InsertRow(value, 1);
    }

    public override T[] MidExpressVector
    {
        get => expressMatrix.GetRowFromMatrix(1);
        set => expressMatrix.InsertRow(value, 1);
    }

    public override T[] MidIntellVector
    {
        get => intellMatrix.GetRowFromMatrix(1);
        set => intellMatrix.InsertRow(value, 1);
    }

    public override T[] MidNonconformVector
    {
        get => conformMatrix.GetRowFromMatrix(1);
        set => conformMatrix.InsertRow(value, 1);
    }

    public override T[] MidNormativityVector
    {
        get => normativityMatrix.GetRowFromMatrix(1);
        set => normativityMatrix.InsertRow(value, 1);
    }

    public override T[] MidRadicalVector
    {
        get => radicalMatrix.GetRowFromMatrix(1);
        set => radicalMatrix.InsertRow(value, 1);
    }

    public override T[] MidSelfControlVector
    {
        get => selfControlMatrix.GetRowFromMatrix(1);
        set => selfControlMatrix.InsertRow(value, 1);
    }

    public override T[] MidSensetVector
    {
        get => sensetMatrix.GetRowFromMatrix(1);
        set => sensetMatrix.InsertRow(value, 1);
    }

    public override T[] MidSocialVector
    {
        get => socialMatrix.GetRowFromMatrix(1);
        set => socialMatrix.InsertRow(value, 1);
    }

    public override T[] MidSuspicionVector
    {
        get => suspicionMatrix.GetRowFromMatrix(1);
        set => suspicionMatrix.InsertRow(value, 1);
    }

    public override T[] MidTensionVector
    {
        get => tensionMatrix.GetRowFromMatrix(1);
        set => tensionMatrix.InsertRow(value, 1);
    }
   

    public MatrixViewDimension(int colsCount)
    {
        InitVectors(colsCount);
    }

    public MatrixViewDimension(MatrixViewDimension<T> referenceMatrix)
    {
        InitVectors(referenceMatrix);
        DimensionName = referenceMatrix.DimensionName;
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
        //добавление объектов
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
