using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using static UnityEditor.EditorGUILayout;
using static UnityEditor.EditorGUI;
using UnityEngine;
using Common;

[CustomEditor(typeof(InterierAdder))]
public class InterierAdderEditor : CustomEditorBase 
{
    InterierAdder adder;
    public override void OnInspectorGUI()
    {
        adder = (InterierAdder)target;
        adder.ViewPrefab = DrawObjectField("������ ��� �������������", adder.ViewPrefab);
        adder.ObjectsToAdd = DrawList("������� ��� ����������", "��������", "�������� ����� ��� ������� ���������", "��������", adder.ObjectsToAdd, false);
        if (GUILayout.Button("������� ������"))
        {
            adder.AddAllObjects();
        }
    }
}
