using BehaviourModel;
using System;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUI;
using static UnityEditor.EditorGUILayout;

[CustomEditor(typeof(CharacterToPhenomFloatRelationsTable))]
public class CharacterToPhenomFloatRelationsTableEditor : CustomEditorBase
{
    private static float cellWidth = 25f;
    private static float labelsWidth = 100f;
    private CharacterToPhenomFloatRelationsTable cr;

    private void DrawArrayInRow(string rowLabel, float[] arr, int width = 25)
    {
        BeginHorizontal("box");
        LabelField(rowLabel, GUILayout.Width(labelsWidth));
        for (int i = 0; i < cr.LowAnxietyVector.Length; i++)
        {
            arr[i] = FloatField(arr[i], GUILayout.Width(width));
        }
        EndHorizontal();
    }

    private void DrawFullColumnNames()
    {
        var l = cr.ColumnsNames.Length;
        for (int i = 0; i < l; i++)
        {
            cr.ColumnsNames[i] = DrawStringFieldWithDefaultFiller($"������� {i}", cr.ColumnsNames[i], $"Col {i}");
        }
    }

    private void DrawShortColumnNames()
    {
        BeginHorizontal("box");
        var l = cr.ColumnsNames.Length;
        GUILayout.Space(labelsWidth);
        for (int i = 0; i < l; i++)
        {
            LabelField(cr.ColumnsNames[i]?.Substring(0, Mathf.Clamp(cr.ColumnsNames[i].Length, 0, 5)), GUILayout.Width(cellWidth));
        }
        EndHorizontal();
    }

    private void DrawVectors()
    {
        DrawArrayInRow("���� �������������", cr.LowSocialVector);
        DrawArrayInRow("���� �������������", cr.MidSocialVector);
        DrawArrayInRow("��� �������������", cr.HighSocialVector);

        DrawArrayInRow("���� �����������", cr.LowAnxietyVector);
        DrawArrayInRow("���� �����������", cr.MidAnxietyVector);
        DrawArrayInRow("��� �����������", cr.HighAnxietyVector);

        DrawArrayInRow("���� �������������", cr.LowNonconformVector);
        DrawArrayInRow("���� ��������������", cr.MidNonconformVector);
        DrawArrayInRow("��� �������������", cr.HighNonconformVector);

        DrawArrayInRow("���� ����������", cr.LowRadicalVector);
        DrawArrayInRow("���� ����������", cr.MidRadicalVector);
        DrawArrayInRow("��� ����������", cr.HighRadicalVector);

        DrawArrayInRow("���� ������������", cr.LowSuspicionVector);
        DrawArrayInRow("���� ������������", cr.MidSuspicionVector);
        DrawArrayInRow("��� ������������", cr.HighSuspicionVector);

        DrawArrayInRow("���� ����.����", cr.LowEmStabVector);
        DrawArrayInRow("���� ����.����", cr.MidEmStabVector);
        DrawArrayInRow("��� ����.����", cr.HighEmStabVector);

        DrawArrayInRow("���� ���������", cr.LowIntellVector);
        DrawArrayInRow("���� ���������", cr.MidIntellVector);
        DrawArrayInRow("��� ���������", cr.HighIntellVector);

        DrawArrayInRow("���� �������������", cr.LowNormativityVector);
        DrawArrayInRow("���� �������������", cr.MidNormativityVector);
        DrawArrayInRow("��� �������������", cr.HighNormativityVector);

        DrawArrayInRow("���� �������������", cr.LowDreamVector);
        DrawArrayInRow("���� �������������", cr.MidDreamVector);
        DrawArrayInRow("��� �������������", cr.HighDreamVector);

        DrawArrayInRow("���� �������������", cr.LowTensionVector);
        DrawArrayInRow("���� �������������", cr.MidTensionVector);
        DrawArrayInRow("��� �������������", cr.HighTensionVector);

        DrawArrayInRow("���� �����������", cr.LowExpressVector);
        DrawArrayInRow("���� �����������", cr.MidExpressVector);
        DrawArrayInRow("��� �����������", cr.HighExpressVector);

        DrawArrayInRow("���� ������������", cr.LowSensetVector);
        DrawArrayInRow("���� ������������", cr.MidSensetVector);
        DrawArrayInRow("��� ������������", cr.HighSensetVector);

        DrawArrayInRow("���� ������������", cr.LowSelfControlVector);
        DrawArrayInRow("���� ������������", cr.MidSelfControlVector);
        DrawArrayInRow("��� ������������", cr.HighSelfControlVector);

        DrawArrayInRow("���� ����������", cr.LowDiplomVector);
        DrawArrayInRow("���� ����������", cr.MidDiplomVector);
        DrawArrayInRow("��� ����������", cr.HighDiplomVector);

        DrawArrayInRow("���� �������������", cr.LowDomintationVector);
        DrawArrayInRow("���� �������������", cr.MidDomintationVector);
        DrawArrayInRow("��� �������������", cr.HighDomintationVector);

        DrawArrayInRow("���� ��������", cr.LowCourageVector);
        DrawArrayInRow("���� ��������", cr.MidCourageVector);
        DrawArrayInRow("��� ��������", cr.HighCourageVector);
    }

    private T[] ExtendVector<T>(int oldSize, int newVectorsLength, T[] vector)
    {
        if (vector == null)
            vector = new T[newVectorsLength];
        T[] newArray = new T[newVectorsLength];
        for (int i = 0; i < oldSize; i++)
            newArray[i] = vector[i];
        return newArray;
    }

    private void ExtendVectors(int oldSize, int newVectorsLength)
    {
        cr.LowAnxietyVector = ExtendVector(oldSize, newVectorsLength, cr.LowAnxietyVector);
        cr.LowNonconformVector = ExtendVector(oldSize, newVectorsLength, cr.LowNonconformVector);
        cr.LowCourageVector = ExtendVector(oldSize, newVectorsLength, cr.LowCourageVector);
        cr.LowDiplomVector = ExtendVector(oldSize, newVectorsLength, cr.LowDiplomVector);
        cr.LowDomintationVector = ExtendVector(oldSize, newVectorsLength, cr.LowDomintationVector);
        cr.LowDreamVector = ExtendVector(oldSize, newVectorsLength, cr.LowDreamVector);
        cr.LowEmStabVector = ExtendVector(oldSize, newVectorsLength, cr.LowEmStabVector);
        cr.LowExpressVector = ExtendVector(oldSize, newVectorsLength, cr.LowExpressVector);
        cr.LowIntellVector = ExtendVector(oldSize, newVectorsLength, cr.LowIntellVector);
        cr.LowNormativityVector = ExtendVector(oldSize, newVectorsLength, cr.LowNormativityVector);
        cr.LowRadicalVector = ExtendVector(oldSize, newVectorsLength, cr.LowRadicalVector);
        cr.LowSelfControlVector = ExtendVector(oldSize, newVectorsLength, cr.LowSelfControlVector);
        cr.LowSensetVector = ExtendVector(oldSize, newVectorsLength, cr.LowSensetVector);
        cr.LowSocialVector = ExtendVector(oldSize, newVectorsLength, cr.LowSocialVector);
        cr.LowSuspicionVector = ExtendVector(oldSize, newVectorsLength, cr.LowSuspicionVector);
        cr.LowTensionVector = ExtendVector(oldSize, newVectorsLength, cr.LowTensionVector);
        cr.ResetLowValuesList();

        cr.MidAnxietyVector = ExtendVector(oldSize, newVectorsLength, cr.MidAnxietyVector);
        cr.MidNonconformVector = ExtendVector(oldSize, newVectorsLength, cr.MidNonconformVector);
        cr.MidCourageVector = ExtendVector(oldSize, newVectorsLength, cr.MidCourageVector);
        cr.MidDiplomVector = ExtendVector(oldSize, newVectorsLength, cr.MidDiplomVector);
        cr.MidDomintationVector = ExtendVector(oldSize, newVectorsLength, cr.MidDomintationVector);
        cr.MidDreamVector = ExtendVector(oldSize, newVectorsLength, cr.MidDreamVector);
        cr.MidEmStabVector = ExtendVector(oldSize, newVectorsLength, cr.MidEmStabVector);
        cr.MidExpressVector = ExtendVector(oldSize, newVectorsLength, cr.MidExpressVector);
        cr.MidIntellVector = ExtendVector(oldSize, newVectorsLength, cr.MidIntellVector);
        cr.MidNormativityVector = ExtendVector(oldSize, newVectorsLength, cr.MidNormativityVector);
        cr.MidRadicalVector = ExtendVector(oldSize, newVectorsLength, cr.MidRadicalVector);
        cr.MidSelfControlVector = ExtendVector(oldSize, newVectorsLength, cr.MidSelfControlVector);
        cr.MidSensetVector = ExtendVector(oldSize, newVectorsLength, cr.MidSensetVector);
        cr.MidSocialVector = ExtendVector(oldSize, newVectorsLength, cr.MidSocialVector);
        cr.MidSuspicionVector = ExtendVector(oldSize, newVectorsLength, cr.MidSuspicionVector);
        cr.MidTensionVector = ExtendVector(oldSize, newVectorsLength, cr.MidTensionVector);
        cr.ResetMidValuesList();

        cr.HighAnxietyVector = ExtendVector(oldSize, newVectorsLength, cr.HighAnxietyVector);
        cr.HighNonconformVector = ExtendVector(oldSize, newVectorsLength, cr.HighNonconformVector);
        cr.HighCourageVector = ExtendVector(oldSize, newVectorsLength, cr.HighCourageVector);
        cr.HighDiplomVector = ExtendVector(oldSize, newVectorsLength, cr.HighDiplomVector);
        cr.HighDomintationVector = ExtendVector(oldSize, newVectorsLength, cr.HighDomintationVector);
        cr.HighDreamVector = ExtendVector(oldSize, newVectorsLength, cr.HighDreamVector);
        cr.HighEmStabVector = ExtendVector(oldSize, newVectorsLength, cr.HighEmStabVector);
        cr.HighExpressVector = ExtendVector(oldSize, newVectorsLength, cr.HighExpressVector);
        cr.HighIntellVector = ExtendVector(oldSize, newVectorsLength, cr.HighIntellVector);
        cr.HighNormativityVector = ExtendVector(oldSize, newVectorsLength, cr.HighNormativityVector);
        cr.HighRadicalVector = ExtendVector(oldSize, newVectorsLength, cr.HighRadicalVector);
        cr.HighSelfControlVector = ExtendVector(oldSize, newVectorsLength, cr.HighSelfControlVector);
        cr.HighSensetVector = ExtendVector(oldSize, newVectorsLength, cr.HighSensetVector);
        cr.HighSocialVector = ExtendVector(oldSize, newVectorsLength, cr.HighSocialVector);
        cr.HighSuspicionVector = ExtendVector(oldSize, newVectorsLength, cr.HighSuspicionVector);
        cr.HighTensionVector = ExtendVector(oldSize, newVectorsLength, cr.HighTensionVector);
        cr.ResetHighValuesList();

        cr.ColumnsNames = ExtendVector(oldSize, newVectorsLength, cr.ColumnsNames);
    }

    private void OnEnable()
    {
        cr = (CharacterToPhenomFloatRelationsTable)target;
    }

    private T[] ReduceVector<T>(int vectorsLength, T[] vector)
    {
        if (vector == null)
            vector = new T[vectorsLength];
        T[] newArray = new T[vectorsLength];
        Array.Copy(vector, newArray, vectorsLength);
        return newArray;
    }

    private void ReduceVectors(int vectorsLength)
    {
        cr.LowAnxietyVector = ReduceVector(vectorsLength, cr.LowAnxietyVector);
        cr.LowNonconformVector = ReduceVector(vectorsLength, cr.LowNonconformVector);
        cr.LowCourageVector = ReduceVector(vectorsLength, cr.LowCourageVector);
        cr.LowDiplomVector = ReduceVector(vectorsLength, cr.LowDiplomVector);
        cr.LowDomintationVector = ReduceVector(vectorsLength, cr.LowDomintationVector);
        cr.LowDreamVector = ReduceVector(vectorsLength, cr.LowDreamVector);
        cr.LowEmStabVector = ReduceVector(vectorsLength, cr.LowEmStabVector);
        cr.LowExpressVector = ReduceVector(vectorsLength, cr.LowExpressVector);
        cr.LowIntellVector = ReduceVector(vectorsLength, cr.LowIntellVector);
        cr.LowNormativityVector = ReduceVector(vectorsLength, cr.LowNormativityVector);
        cr.LowRadicalVector = ReduceVector(vectorsLength, cr.LowRadicalVector);
        cr.LowSelfControlVector = ReduceVector(vectorsLength, cr.LowSelfControlVector);
        cr.LowSensetVector = ReduceVector(vectorsLength, cr.LowSensetVector);
        cr.LowSocialVector = ReduceVector(vectorsLength, cr.LowSocialVector);
        cr.LowSuspicionVector = ReduceVector(vectorsLength, cr.LowSuspicionVector);
        cr.LowTensionVector = ReduceVector(vectorsLength, cr.LowTensionVector);
        cr.ResetLowValuesList();

        cr.MidAnxietyVector = ReduceVector(vectorsLength, cr.MidAnxietyVector);
        cr.MidNonconformVector = ReduceVector(vectorsLength, cr.MidNonconformVector);
        cr.MidCourageVector = ReduceVector(vectorsLength, cr.MidCourageVector);
        cr.MidDiplomVector = ReduceVector(vectorsLength, cr.MidDiplomVector);
        cr.MidDomintationVector = ReduceVector(vectorsLength, cr.MidDomintationVector);
        cr.MidDreamVector = ReduceVector(vectorsLength, cr.MidDreamVector);
        cr.MidEmStabVector = ReduceVector(vectorsLength, cr.MidEmStabVector);
        cr.MidExpressVector = ReduceVector(vectorsLength, cr.MidExpressVector);
        cr.MidIntellVector = ReduceVector(vectorsLength, cr.MidIntellVector);
        cr.MidNormativityVector = ReduceVector(vectorsLength, cr.MidNormativityVector);
        cr.MidRadicalVector = ReduceVector(vectorsLength, cr.MidRadicalVector);
        cr.MidSelfControlVector = ReduceVector(vectorsLength, cr.MidSelfControlVector);
        cr.MidSensetVector = ReduceVector(vectorsLength, cr.MidSensetVector);
        cr.MidSocialVector = ReduceVector(vectorsLength, cr.MidSocialVector);
        cr.MidSuspicionVector = ReduceVector(vectorsLength, cr.MidSuspicionVector);
        cr.MidTensionVector = ReduceVector(vectorsLength, cr.MidTensionVector);
        cr.ResetMidValuesList();

        cr.HighAnxietyVector = ReduceVector(vectorsLength, cr.HighAnxietyVector);
        cr.HighNonconformVector = ReduceVector(vectorsLength, cr.HighNonconformVector);
        cr.HighCourageVector = ReduceVector(vectorsLength, cr.HighCourageVector);
        cr.HighDiplomVector = ReduceVector(vectorsLength, cr.HighDiplomVector);
        cr.HighDomintationVector = ReduceVector(vectorsLength, cr.HighDomintationVector);
        cr.HighDreamVector = ReduceVector(vectorsLength, cr.HighDreamVector);
        cr.HighEmStabVector = ReduceVector(vectorsLength, cr.HighEmStabVector);
        cr.HighExpressVector = ReduceVector(vectorsLength, cr.HighExpressVector);
        cr.HighIntellVector = ReduceVector(vectorsLength, cr.HighIntellVector);
        cr.HighNormativityVector = ReduceVector(vectorsLength, cr.HighNormativityVector);
        cr.HighRadicalVector = ReduceVector(vectorsLength, cr.HighRadicalVector);
        cr.HighSelfControlVector = ReduceVector(vectorsLength, cr.HighSelfControlVector);
        cr.HighSensetVector = ReduceVector(vectorsLength, cr.HighSensetVector);
        cr.HighSocialVector = ReduceVector(vectorsLength, cr.HighSocialVector);
        cr.HighSuspicionVector = ReduceVector(vectorsLength, cr.HighSuspicionVector);
        cr.HighTensionVector = ReduceVector(vectorsLength, cr.HighTensionVector);
        cr.ResetHighValuesList();

        cr.ColumnsNames = ReduceVector(vectorsLength, cr.ColumnsNames);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        cr.TableDescription = DrawStringFieldWithDefaultFiller("�������� �������", cr.TableDescription, "�����������");
        var oldSize = cr.LowAnxietyVector?.Length ?? -1;
        var newLength = Mathf.Clamp(DrawObjectField("������ ��������", oldSize), 1, 64);
        if (oldSize > newLength)
            ReduceVectors(newLength);
        else if (oldSize < newLength)
            ExtendVectors(oldSize, newLength);
        DrawShortColumnNames();
        DrawVectors();
        DrawFullColumnNames();
        CheckDirty();
    }
}