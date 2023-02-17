using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUI;

[CustomPropertyDrawer(typeof(OneLineAttribute))]
public class OneLineDrawer : PropertyDrawer
{
    float horizontalSpace = 0.5f;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!property.isArray)
            throw new System.Exception($"Property {property} isn't an array");

        var attr = attribute as OneLineAttribute;
        var labelRect = position;
        labelRect.width = attr.labelWidth;
        if (attr.labelText != null)
            label.text = attr.labelText;
        LabelField(labelRect, label);

        var arrLength = property.arraySize;
        var cellsTotalWidth = position.width - labelRect.width;
        var cellRect = position;
        cellRect.x = labelRect.width;
        cellRect.width = cellsTotalWidth / arrLength - horizontalSpace;
        for (int i = 0; i < arrLength; i++)
        {
            var prop = property.GetArrayElementAtIndex(i);
            PropertyField(cellRect, prop, GUIContent.none);
            cellRect.x += cellRect.width + horizontalSpace;
        }
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
}
