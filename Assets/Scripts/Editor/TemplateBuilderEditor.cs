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
        tb.CentralPoint = DrawObjectField("����������� �����", tb.CentralPoint);
        if (tb.CentralPoint == null)
            HelpBox("���������� ������� ����������� ����� ��� �������", MessageType.Warning);
        tb.XStep = DrawObjectField("��� �� �����������", tb.XStep);
        tb.YStep = DrawObjectField("��� �� ���������", tb.YStep);
        tb.EntranceTemplates = DrawList("�������", "������", "�������� ����� ��� �������", "������", tb.EntranceTemplates, true);
        CheckDirty();
    }
}