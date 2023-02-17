//using System;
//using UnityEditor;
//using UnityEngine;
//using static UnityEditor.EditorGUILayout;

//public abstract class CharacterToPhenomTableEditor<T> : CustomEditorBase
//{
//    private CharacterToPhenomTableBase<T> cr;
//    protected static MatrixDimension<T> copyMatrix;
//    static bool confirmPressed;
//    static Action onPress;
//    protected abstract void DrawArrayInRow(string rowLabel, T[] arr);

//    protected void DrawFullColumnNames(MatrixDimension<T> dim)
//    {
//        var l = dim.ColumnsNames.Length;
//        for (int i = 0; i < l; i++)
//        {
//            dim.ColumnsNames[i] = DrawStringFieldWithDefaultFiller($"Column {i}", dim.ColumnsNames[i], $"Col {i}");
//        }
//    }

//    protected void DrawShortColumnNames(MatrixDimension<T> currDim)
//    {
//        BeginHorizontal("box");
//        var l = currDim.ColumnsNames.Length;
//        GUILayout.Space(cr.labelsWidth);
//        for (int i = 0; i < l; i++)
//        {
//            LabelField(currDim.ColumnsNames[i], GUILayout.Width(cr.cellWidth));
//        }
//        EndHorizontal();
//    }

//    protected void DrawVectors(MatrixDimension<T> dim)
//    {
//        DrawArrayInRow("Low sociabilty", dim.LowSocialVector.Vector);
//        DrawArrayInRow("Mid sociabilty", dim.MidSocialVector.Vector);
//        DrawArrayInRow("High sociabilty", dim.HighSocialVector.Vector);
//        Space();
//        DrawArrayInRow("Low anxiety", dim.LowAnxietyVector.Vector);
//        DrawArrayInRow("Mid anxiety", dim.MidAnxietyVector.Vector);
//        DrawArrayInRow("High anxiety", dim.HighAnxietyVector.Vector);
//        Space();

//        DrawArrayInRow("Low noncinfirmism", dim.LowNonconformVector.Vector);
//        DrawArrayInRow("Mid noncinfirmism", dim.MidNonconformVector.Vector);
//        DrawArrayInRow("High noncinfirmism", dim.HighNonconformVector.Vector);
//        Space();

//        DrawArrayInRow("Low radicalism", dim.LowRadicalVector.Vector);
//        DrawArrayInRow("Mid radicalism", dim.MidRadicalVector.Vector);
//        DrawArrayInRow("High radicalism", dim.HighRadicalVector.Vector);
//        Space();

//        DrawArrayInRow("Low suspicion", dim.LowSuspicionVector.Vector);
//        DrawArrayInRow("Mid suspicion", dim.MidSuspicionVector.Vector);
//        DrawArrayInRow("High suspicion", dim.HighSuspicionVector.Vector);
//        Space();

//        DrawArrayInRow("Low emotion stabil", dim.LowEmStabVector.Vector);
//        DrawArrayInRow("Mid emotion stabil", dim.MidEmStabVector.Vector);
//        DrawArrayInRow("High emotion stabil", dim.HighEmStabVector.Vector);
//        Space();

//        DrawArrayInRow("Low intelligence", dim.LowIntellVector.Vector);
//        DrawArrayInRow("Mid intelligence", dim.MidIntellVector.Vector);
//        DrawArrayInRow("High intelligence", dim.HighIntellVector.Vector);
//        Space();

//        DrawArrayInRow("Low norm of behaviour", dim.LowNormativityVector.Vector);
//        DrawArrayInRow("Mid norm of behaviour", dim.MidNormativityVector.Vector);
//        DrawArrayInRow("High norm of behaviour", dim.HighNormativityVector.Vector);
//        Space();

//        DrawArrayInRow("Low dreaminess", dim.LowDreamVector.Vector);
//        DrawArrayInRow("Mid dreaminess", dim.MidDreamVector.Vector);
//        DrawArrayInRow("High dreaminess", dim.HighDreamVector.Vector);
//        Space();

//        DrawArrayInRow("Low tension", dim.LowTensionVector.Vector);
//        DrawArrayInRow("Mid tension", dim.MidTensionVector.Vector);
//        DrawArrayInRow("High tension", dim.HighTensionVector.Vector);
//        Space();

//        DrawArrayInRow("Low expressiveness", dim.LowExpressVector.Vector);
//        DrawArrayInRow("Mid expressiveness", dim.MidExpressVector.Vector);
//        DrawArrayInRow("High expressiveness", dim.HighExpressVector.Vector);
//        Space();

//        DrawArrayInRow("Low sensetivity", dim.LowSensetVector.Vector);
//        DrawArrayInRow("Mid sensetivity", dim.MidSensetVector.Vector);
//        DrawArrayInRow("High sensetivity", dim.HighSensetVector.Vector);
//        Space();

//        DrawArrayInRow("Low selfcontrol", dim.LowSelfControlVector.Vector);
//        DrawArrayInRow("Mid selfcontrol", dim.MidSelfControlVector.Vector);
//        DrawArrayInRow("High selfcontrol", dim.HighSelfControlVector.Vector);
//        Space();

//        DrawArrayInRow("Low diplomacy", dim.LowDiplomVector.Vector);
//        DrawArrayInRow("Mid diplomacy", dim.MidDiplomVector.Vector);
//        DrawArrayInRow("High diplomacy", dim.HighDiplomVector.Vector);
//        Space();

//        DrawArrayInRow("Low domination", dim.LowDomintationVector.Vector);
//        DrawArrayInRow("Mid domination", dim.MidDomintationVector.Vector);
//        DrawArrayInRow("High domination", dim.HighDomintationVector.Vector);
//        Space();

//        DrawArrayInRow("Low courage", dim.LowCourageVector.Vector);
//        DrawArrayInRow("Mid courage", dim.MidCourageVector.Vector);
//        DrawArrayInRow("High courage", dim.HighCourageVector.Vector);
//        Space();
//    }

//    protected virtual void OnEnable()
//    {
//        cr = (CharacterToPhenomTableBase<T>)target;
//    }

//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//        LabelField("Table props", EditorStyles.boldLabel);
//        cr.TableDescription = DrawStringFieldWithDefaultFiller("Table description", cr.TableDescription, "none");
//        cr.cellWidth = DrawObjectField("Matrix cell width px", cr.cellWidth);
//        cr.labelsWidth = DrawObjectField("Matrix labels width px", cr.labelsWidth);
//        cr.TableDimensions = DrawAddSubtractButtonsForValue($"Table dimensions count {cr.TableDimensions}", cr.TableDimensions, 1, 1024);
//        cr.ColumnsCount = DrawAddSubtractButtonsForValue($"Table columns count {cr.ColumnsCount}", cr.ColumnsCount, 1, 1024);
//        cr.TableScallingValue = Mathf.Clamp(DrawObjectField("Table scalling value", cr.TableScallingValue), 0f, 10f);
//        Space();
//        cr.DisplayedDimensionIndex = DrawAddSubtractButtonsForValue($"Table dimension index {cr.DisplayedDimensionIndex}", cr.DisplayedDimensionIndex, 0, cr.TableDimensions - 1);
//        cr.DisplayedDimension = cr.Dimensions[cr.DisplayedDimensionIndex];
//        LabelField("Current dim props", EditorStyles.boldLabel);
//        Space();
//        DrawCurrentMatrix();

//        CopyPasteValuesBlock();

//        CheckDirty();
//    }

//    private void CopyPasteValuesBlock()
//    {
//        BeginHorizontal("box");
//        if (GUILayout.Button("Copy dimension"))
//        {
//            copyMatrix = new MatrixDimension<T>(cr.Dimensions[cr.currentDimensionIndex]);
//        }
//        if (GUILayout.Button("Paste copied dimension"))
//        {
//            confirmPressed = !confirmPressed;
//            if (copyMatrix != null)
//                onPress = () => { cr.Dimensions[cr.currentDimensionIndex] = new MatrixDimension<T>(copyMatrix); };

//        }
//        if (GUILayout.Button("Clear dimension"))
//        {
//            confirmPressed = !confirmPressed;
//            onPress = () => { cr.Dimensions[cr.currentDimensionIndex] = new MatrixDimension<T>(cr.ColumnsCount); };
//        }
//        EndHorizontal();
//        if (confirmPressed)
//        {
//            if (GUILayout.Button("Sure?"))
//            {
//                onPress?.Invoke();
//                confirmPressed = false;
//                onPress = null;
//            }
//        }
//    }


//    protected virtual void DrawCurrentMatrix()
//    {
//        var dim = cr.DisplayedDimension;
//        dim.ScallingValue = Mathf.Clamp(DrawObjectField("This dim scalling value", dim.ScallingValue),0f,10f);
//        dim.DimensionName = DrawStringFieldWithDefaultFiller("Dimension name", dim.DimensionName, "name");
//        DrawShortColumnNames(dim);
//        DrawVectors(dim);
//        DrawFullColumnNames(dim);
//    }
//}