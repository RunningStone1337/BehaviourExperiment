using BuildingModule;
using UnityEditor;
using static UnityEditor.EditorGUI;
using static UnityEditor.EditorGUILayout;

[CustomEditor(typeof(TemplateBuilder))]
public class TemplateBuilderEditor : CustomEditorBase
{
    private TemplateBuilder tb;

    private void OnEnable()
    {
        tb = (TemplateBuilder)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        tb.CentralPoint = DrawObjectField("Центральная точка", tb.CentralPoint);
        if (tb.CentralPoint == null)
            HelpBox("Необходимо указать центральную точку для шаблона", MessageType.Warning);
        tb.XStep = DrawObjectField("Шаг по горизонтали", tb.XStep);
        tb.YStep = DrawObjectField("Шаг по вертикали", tb.YStep);
        tb.EntranceTemplates = DrawList("Шаблоны", "Шаблон", "Выделить место для шаблона", "шаблон", tb.EntranceTemplates, true);
        CheckDirty();
    }
}