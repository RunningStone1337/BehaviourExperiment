using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using static UnityEditor.EditorGUI;
using UnityEngine;

//[CustomPropertyDrawer(typeof(MatrixDimension<>), true)]
public class MatrixDimensionDrawer : PropertyDrawer
{
    float horizontalSpace = 0.5f;
    float verticalSpace = 1f;
    float scroolbarWidth = 12f;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.width = EditorGUIUtility.currentViewWidth - scroolbarWidth;
        property.serializedObject.Update();
        var labelWidth = property.FindPropertyRelative("labelsWidth");
        var cellsHeight = property.FindPropertyRelative("cellsHeight");
        var scaleFloat = property.FindPropertyRelative("scallingValue");
        var dimensionName = property.FindPropertyRelative("dimensionName");
        var namesArr = property.FindPropertyRelative("columnsNames.vector");

        var lowCalmArr = property.FindPropertyRelative("lowCalmVector.vector");
        var midCalmArr = property.FindPropertyRelative("midCalmVector.vector");
        var highCalmArr = property.FindPropertyRelative("highCalmVector.vector");

        var lowConformVector = property.FindPropertyRelative("lowConformVector.vector");
        var midConformVector = property.FindPropertyRelative("midConformVector.vector");
        var highConformVector = property.FindPropertyRelative("highConformVector.vector");

        var lowCourageVector = property.FindPropertyRelative("lowCourageVector.vector");
        var midCourageVector = property.FindPropertyRelative("midCourageVector.vector");
        var highCourageVector = property.FindPropertyRelative("highCourageVector.vector");

        var lowDiplomVector = property.FindPropertyRelative("lowDiplomVector.vector");
        var midDiplomVector = property.FindPropertyRelative("midDiplomVector.vector");
        var highDiplomVector = property.FindPropertyRelative("highDiplomVector.vector");

        var lowDomintationVector = property.FindPropertyRelative("lowDomintationVector.vector");
        var midDomintationVector = property.FindPropertyRelative("midDomintationVector.vector");
        var highDomintationVector = property.FindPropertyRelative("highDomintationVector.vector");

        var lowDreamVector = property.FindPropertyRelative("lowDreamVector.vector");
        var midDreamVector = property.FindPropertyRelative("midDreamVector.vector");
        var highDreamVector = property.FindPropertyRelative("highDreamVector.vector");

        var lowEmStabVector = property.FindPropertyRelative("lowEmStabVector.vector");
        var midEmStabVector = property.FindPropertyRelative("midEmStabVector.vector");
        var highEmStabVector = property.FindPropertyRelative("highEmStabVector.vector");

        var lowExpressVector = property.FindPropertyRelative("lowExpressVector.vector");
        var midExpressVector = property.FindPropertyRelative("midExpressVector.vector");
        var highExpressVector = property.FindPropertyRelative("highExpressVector.vector");

        var lowIntellVector = property.FindPropertyRelative("lowIntellVector.vector");
        var midIntellVector = property.FindPropertyRelative("midIntellVector.vector");
        var highIntellVector = property.FindPropertyRelative("highIntellVector.vector");

        var lowNormativityVector = property.FindPropertyRelative("lowNormativityVector.vector");
        var midNormativityVector = property.FindPropertyRelative("midNormativityVector.vector");
        var highNormativityVector = property.FindPropertyRelative("highNormativityVector.vector");

        var lowRadicalVector = property.FindPropertyRelative("lowRadicalVector.vector");
        var midRadicalVector = property.FindPropertyRelative("midRadicalVector.vector");
        var highRadicalVector = property.FindPropertyRelative("highRadicalVector.vector");

        var lowSelfControlVector = property.FindPropertyRelative("lowSelfControlVector.vector");
        var midSelfControlVector = property.FindPropertyRelative("midSelfControlVector.vector");
        var highSelfControlVector = property.FindPropertyRelative("highSelfControlVector.vector");

        var lowSensetVector = property.FindPropertyRelative("lowSensetVector.vector");
        var midSensetVector = property.FindPropertyRelative("midSensetVector.vector");
        var highSensetVector = property.FindPropertyRelative("highSensetVector.vector");

        var lowSocialVector = property.FindPropertyRelative("lowSocialVector.vector");
        var midSocialVector = property.FindPropertyRelative("midSocialVector.vector");
        var highSocialVector = property.FindPropertyRelative("highSocialVector.vector");

        var lowSuspicionVector = property.FindPropertyRelative("lowSuspicionVector.vector");
        var midSuspicionVector = property.FindPropertyRelative("midSuspicionVector.vector");
        var highSuspicionVector = property.FindPropertyRelative("highSuspicionVector.vector");

        var lowTensionVector = property.FindPropertyRelative("lowTensionVector.vector");
        var midTensionVector = property.FindPropertyRelative("midTensionVector.vector");
        var highTensionVector = property.FindPropertyRelative("highTensionVector.vector");

        //var highValuesVectors = property.FindPropertyRelative("highValuesVectors");
        //var lowValuesVectors = property.FindPropertyRelative("lowValuesVectors");
        //var middleValuesVectors = property.FindPropertyRelative("middleValuesVectors");

        var currentRect = new Rect(0, position.y, position.width, EditorGUIUtility.singleLineHeight);

        BeginProperty(position, label, property);

        labelWidth.floatValue = FloatField(currentRect, new GUIContent("Labels width"), labelWidth.floatValue);
        currentRect = NextLine(currentRect, EditorGUIUtility.singleLineHeight);
        cellsHeight.floatValue = FloatField(currentRect, new GUIContent("Cells height"), cellsHeight.floatValue);
        currentRect = NextLine(currentRect, EditorGUIUtility.singleLineHeight);
        scaleFloat.floatValue = FloatField(currentRect, new GUIContent("Dimension scale"), scaleFloat.floatValue);
        currentRect = NextLine(currentRect, EditorGUIUtility.singleLineHeight);
        dimensionName.stringValue = TextField(currentRect, new GUIContent("Dimension name"), dimensionName.stringValue);
        currentRect = NextLine(currentRect, EditorGUIUtility.singleLineHeight);
        DrawArrayOneLine(currentRect, labelWidth.floatValue, EditorGUIUtility.singleLineHeight, string.Empty, namesArr);
        currentRect = NextLine(currentRect, EditorGUIUtility.singleLineHeight);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low sociability", lowSocialVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle sociability", midSocialVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High sociability", highSocialVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low anxiety", lowCalmArr);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle anxiety", midCalmArr);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High anxiety", highCalmArr);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low nonconformism", lowConformVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle nonconformism", midConformVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High nonconformism", highConformVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low radicalism", lowRadicalVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle radicalism", midRadicalVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High radicalism", highRadicalVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low suspicion", lowSuspicionVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle suspicion", midSuspicionVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High suspicion", highSuspicionVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low em. stab", lowEmStabVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle em. stab", midEmStabVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High em. stab", highEmStabVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low intelligence", lowIntellVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle intelligence", midIntellVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High intelligence", highIntellVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low norm. of behaviour", lowNormativityVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle norm. of behaviour", midNormativityVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High norm. of behaviour", highNormativityVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low dreaminess", lowDreamVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle dreaminess", midDreamVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High dreaminess", highDreamVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low tension", lowTensionVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle tension", midTensionVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High tension", highTensionVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low express", lowExpressVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle express", midExpressVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High express", highExpressVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low sensetivity", lowSensetVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle sensetivity", midSensetVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High sensetivity", highSensetVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low selfcontrol", lowSelfControlVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle selfcontrol", midSelfControlVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High selfcontrol", highSelfControlVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low diplomacy", lowDiplomVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle diplomacy", midDiplomVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High diplomacy", highDiplomVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low domination", lowDomintationVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle domination", midDomintationVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High domination", highDomintationVector);

        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Low courage", lowCourageVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "Middle courage", midCourageVector);
        currentRect = DrawArrayOneLine(currentRect, labelWidth.floatValue, cellsHeight.floatValue, "High courage", highCourageVector);

        EndProperty();
        property.serializedObject.ApplyModifiedProperties();
    }

    private Rect NextLine(Rect currentPosition, float lineHeight)
    {
        currentPosition.y += lineHeight + verticalSpace;
        currentPosition.x = 0;
        return currentPosition;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var totalLines = 53;
        var singleLines = 5;
        var flexLines = totalLines - singleLines;
        var cellsHeight = property.FindPropertyRelative("cellsHeight");

        //зависит от размеров дочерних элементов
        return singleLines * (EditorGUIUtility.singleLineHeight + verticalSpace) 
            + (cellsHeight.floatValue + verticalSpace) *(flexLines);
    }
    private Rect DrawArrayOneLine(Rect startPos, float labelWidth, float cellsHeight, string label, SerializedProperty arr)
    {
        if (!arr.isArray)
            throw new System.Exception($"Property {arr} isn't an array");

        var labelRect = startPos;
        labelRect.width = labelWidth;
        labelRect.height = cellsHeight;
        LabelField(labelRect, label);

        var arrLength = arr.arraySize;
        var cellsTotalWidth = startPos.width - labelWidth;
        var cellRect = startPos;
        cellRect.x = labelRect.width;
        cellRect.height = cellsHeight;
        cellRect.width = cellsTotalWidth / arrLength - horizontalSpace;
        for (int i = 0; i < arrLength; i++)
        {
            var prop = arr.GetArrayElementAtIndex(i);
            PropertyField(cellRect, prop, GUIContent.none);
            cellRect.x += cellRect.width + horizontalSpace;
        }
        return NextLine(startPos, cellsHeight);
    }
}
