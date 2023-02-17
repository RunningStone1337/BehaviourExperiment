using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AssemblySelectionCodeCreator))]
public class AssemblySelectionCodeCreatorEditor : CustomEditorBase
{
    private AssemblySelectionCodeCreator ascc;
    protected SerializedProperty genericCreatedConstraintsProperty;
    private SerializedProperty genericConstraintsProperty;
    private SerializedProperty genericParamsProperty;
    Assembly[] assemblies;
    Type[] types;
    private void OnEnable()
    {
        ascc = (AssemblySelectionCodeCreator)target;
        genericParamsProperty = serializedObject.FindProperty("derivedClassGenericParameters");
        genericConstraintsProperty = serializedObject.FindProperty("genericConstraints");
        genericCreatedConstraintsProperty = serializedObject.FindProperty("createdClassGenericParameters");
        assemblies = AppDomain.CurrentDomain.GetUserCreatedAssemblies();//ограничить список сборок нужными
        types = assemblies[ascc.assemblyIndex].GetTypes();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ascc = (AssemblySelectionCodeCreator)target;

        var options = assemblies.AssemblyToString();
        ascc.assemblyIndex = EditorGUILayout.Popup("Derived from class assembly", ascc.assemblyIndex, options);
        
        types = assemblies[ascc.assemblyIndex].GetTypes().Where(x=>x.IsClass || x.IsInterface).ToArray();
        options = types.GetNames();

        ascc.classIndex = EditorGUILayout.Popup("Derived from class", ascc.classIndex, options);
        if (ascc.classIndex> types.Length)
            ascc.classIndex = default;
        var str = types[ascc.classIndex].Name;
        if (str.Contains('`'))
            ascc.derivedClassFromName = str.Substring(0, str.IndexOf('`'));
        else
            ascc.derivedClassFromName = str;

        ascc.generatingFolderPath = DrawStringFieldWithDefaultFiller("New class creating directory",
            ascc.generatingFolderPath, $"{Application.dataPath }");
        ascc.createdClassNamespace = DrawStringFieldWithDefaultFiller("Created class namespace", ascc.createdClassNamespace, "");
        ascc.classAccesLevel = DrawEnum("New class access level", ascc.classAccesLevel);
        ascc.addClassModifier = DrawEnum("Additional modifier", ascc.addClassModifier);
        ascc.classNamePrefix = DrawStringFieldWithDefaultFiller("New class name prefix", ascc.classNamePrefix, "InheritedFrom");
        EditorGUILayout.PropertyField(genericCreatedConstraintsProperty, true);
        EditorGUILayout.PropertyField(genericParamsProperty, true);
        EditorGUILayout.PropertyField(genericConstraintsProperty, true);
        CheckDirty<AssemblySelectionCodeCreator>();
        serializedObject.ApplyModifiedProperties();
        if (GUILayout.Button("Create class"))
        {
            ascc.CreateClass();
            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        }
    }

   
}