using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMatrixViewDimension<T> : MatrixViewDimension<T>
where T : new()
{
    public ClassMatrixViewDimension() : base()
    {

    }
    public override void InitVectors(int colsCount)
    {
        base.InitVectors(colsCount);

        calmMatrix.FillDefault();
        conformMatrix.FillDefault();
        courageMatrix.FillDefault();
        diplomMatrix.FillDefault();
        domintationMatrix.FillDefault();
        dreamMatrix.FillDefault();
        emStabMatrix.FillDefault();
        expressMatrix.FillDefault();
        intellMatrix.FillDefault();
        normativityMatrix.FillDefault();
        radicalMatrix.FillDefault();
        selfControlMatrix.FillDefault();
        sensetMatrix.FillDefault();
        socialMatrix.FillDefault();
        suspicionMatrix.FillDefault();
        tensionMatrix.FillDefault();

    }
    public override void ExtendVectors(int newVectorsLength)
    {
        base.ExtendVectors(newVectorsLength);

        calmMatrix.FillEmptys();
        conformMatrix.FillEmptys();
        courageMatrix.FillEmptys();
        diplomMatrix.FillEmptys();
        domintationMatrix.FillEmptys();
        dreamMatrix.FillEmptys();
        emStabMatrix.FillEmptys();
        expressMatrix.FillEmptys();
        intellMatrix.FillEmptys();
        normativityMatrix.FillEmptys();
        radicalMatrix.FillEmptys();
        selfControlMatrix.FillEmptys();
        sensetMatrix.FillEmptys();
        socialMatrix.FillEmptys();
        suspicionMatrix.FillEmptys();
        tensionMatrix.FillEmptys();

        ColumnsNames.FillEmptys();
    }
}
