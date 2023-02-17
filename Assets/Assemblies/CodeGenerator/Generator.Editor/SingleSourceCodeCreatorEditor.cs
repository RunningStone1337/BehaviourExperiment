using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SingleSourceCodeCreator))]
public class SingleSourceCodeCreatorEditor : SourceCodeGeneratorEditor
{
    protected SerializedProperty genericConstraintsProperty;
    protected SerializedProperty genericCreatedConstraintsProperty;
    protected SerializedProperty genericParamsProperty;
    private SingleSourceCodeCreator sscc;

    protected void OnEnable()
    {
        genericParamsProperty = serializedObject.FindProperty("derivedClassGenericParameters");
        genericConstraintsProperty = serializedObject.FindProperty("genericConstraints");
        genericCreatedConstraintsProperty = serializedObject.FindProperty("createdClassGenericParameters");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        sscc = (SingleSourceCodeCreator)target;
        sscc.derivedClassFromName = DrawStringFieldWithDefaultFiller("Derived from", sscc.derivedClassFromName, "object");
        EditorGUILayout.PropertyField(genericCreatedConstraintsProperty, true);
        EditorGUILayout.PropertyField(genericParamsProperty, true);
        EditorGUILayout.PropertyField(genericConstraintsProperty, true);
        serializedObject.ApplyModifiedProperties();
        if (GUILayout.Button("Create class"))
        {
            sscc.CreateClass();
            AssetDatabase.Refresh();
        }
    }
}