using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SourceCodeCreatorBase))]
public class SourceCodeGeneratorEditor : CustomEditorBase
{
    private SourceCodeCreatorBase scc;

   

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        scc = (SourceCodeCreatorBase)target;
        scc.generatingFolderPath = DrawStringFieldWithDefaultFiller("New class creating directory", scc.generatingFolderPath, $"{Application.dataPath }");
        scc.createdClassNamespace = DrawStringFieldWithDefaultFiller("Created class namespace", scc.createdClassNamespace, "");
        scc.classAccesLevel = DrawEnum("New class access level", scc.classAccesLevel);
        scc.addClassModifier = DrawEnum("Additional modifier", scc.addClassModifier);
        scc.classNamePrefix = DrawStringFieldWithDefaultFiller("New class name prefix", scc.classNamePrefix, "InheritedFrom");
        //scc.generatingFolderPath = StringField
    }
}