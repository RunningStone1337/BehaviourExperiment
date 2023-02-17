using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BundleAssemblySelectionCodeCreator))]
public class BundleAssemblySelectionCodeCreatorEditor : CustomEditorBase
{
    BundleAssemblySelectionCodeCreator bscc;
    SerializedProperty creatorProperty;
    Assembly[] assemblies;
    Type[] types;
    private void OnEnable()
    {
        bscc = (BundleAssemblySelectionCodeCreator)target;
        creatorProperty = serializedObject.FindProperty("creator");
        assemblies = AppDomain.CurrentDomain.GetUserCreatedAssemblies();//ограничить список сборок нужными
        //types = assemblies[bscc.assemblyIndex].GetTypes().Where(x=>x.IsClass || x.IsInterface).ToArray();
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("This class uses assembly selection source code creator, assign a reference to the instance ");
        EditorGUILayout.LabelField("and setup. All options except \"Derived from class\" enum and \"Derived from class assembly\" ");
        EditorGUILayout.LabelField("enum will use to create classes.");
        EditorGUILayout.PropertyField(creatorProperty);

        var options = assemblies.AssemblyToString();
        bscc.assemblyIndex = EditorGUILayout.Popup("Derived from class assembly", bscc.assemblyIndex, options);

        types = assemblies[bscc.assemblyIndex].GetTypes().Where(x => x.IsClass || x.IsInterface).ToArray();
        (bscc.TypesFullNames, bscc.Indexes, bscc.derivedFromClasses) =
            DrawTypesSelectors(types.ToList(), bscc.TypesFullNames, bscc.Indexes, bscc.derivedFromClasses);
        bscc.derivedFromClasses = SubstringNames(bscc.derivedFromClasses);
        serializedObject.ApplyModifiedProperties();
        if (GUILayout.Button("Create classes"))
        {
            bscc.CreateClasses();
            AssetDatabase.Refresh();
        }
    }

    private List<string> SubstringNames(List<string> derivedFromClasses)
    {
        for (int i = 0; i < derivedFromClasses.Count; i++)
        {
            //if (bscc.Indexes[i] > types.Length)
            //    bscc.Indexes[i] = default;
            var str = derivedFromClasses[i];
            if (str == null)
                continue;
            if (str.Contains('`'))
                derivedFromClasses[i] = str.Substring(0, str.IndexOf('`'));
            else
                derivedFromClasses[i] = str;
        }
        return derivedFromClasses;
    }
}
