using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BundleSourceCodeCreator))]
public class BundleSourceCodeCreatorEditor : CustomEditorBase
{
    BundleSourceCodeCreator bscc;
    SerializedProperty creatorProperty;
    SerializedProperty classListProperty;
    private void OnEnable()
    {
        bscc = (BundleSourceCodeCreator)target;
        creatorProperty = serializedObject.FindProperty("creator");
        classListProperty = serializedObject.FindProperty("derivedFromClasses");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("This class uses single source code creator, assign a reference to the instance and setup.");
        EditorGUILayout.LabelField("All options except \"Derived from\" field will use to create classes.");
        //bscc.creator = DrawObjectField("Single creator", bscc.creator,true);
        EditorGUILayout.PropertyField(creatorProperty);
        EditorGUILayout.PropertyField(classListProperty);
        if (GUILayout.Button("Create classes"))
        {
            bscc.CreateClasses();
            AssetDatabase.Refresh();
        }
    }
}
