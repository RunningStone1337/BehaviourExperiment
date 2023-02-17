using BuildingModule;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUI;
using static UnityEditor.EditorGUILayout;

[CustomEditor(typeof(MatrixTemplate))]
public class MatrixTemplateEditor : CustomEditorBase
{
    private MatrixTemplate bt;

    private void BalanceXDim(Vector2Int oldSize, Vector2Int newSize, int Yindex)
    {
        //обрезать строку или скопировать с дополнением
        if (oldSize.x > newSize.x)
        {
            var oldRow = bt.PlacesMatrix[Yindex];
            var temp = bt.PlacesMatrix[Yindex] = new bool[newSize.x];
            for (int i = 0; i < newSize.x; i++)
                temp[i] = oldRow[i];
        }
        //скопировать с дополнением
        else if (oldSize.x < newSize.x)
        {
            var oldRow = bt.PlacesMatrix[Yindex];
            var temp = bt.PlacesMatrix[Yindex] = new bool[newSize.x];
            for (int i = 0; i < oldRow.Length; i++)
                temp[i] = oldRow[i];
        }
    }

    private void BalanceYDim(Vector2Int newSize)
    {
        var diff = bt.PlacesMatrix.Count - newSize.y;
        //удалить лишние по y
        if (bt.PlacesMatrix.Count > newSize.y)
        {
            if (newSize.y != 0)
                bt.PlacesMatrix.RemoveRange(newSize.y - 1, diff);
            else
                bt.PlacesMatrix.Clear();
        }
        //или добавить новые
        else if (bt.PlacesMatrix.Count < newSize.y)
        {
            diff *= -1;
            for (int i = 0; i < diff; i++)
                bt.PlacesMatrix.Add(new bool[newSize.x]);
        }
    }

    private Vector2Int GetSize(List<bool[]> placesMatrix)
    {
        return new Vector2Int(placesMatrix.Count > 0 ? placesMatrix[0].Length : 0, placesMatrix.Count);
    }

    private void OnEnable()
    {
        bt = (MatrixTemplate)target;
    }

    private bool SizeNotMatch(Vector2Int newSize)
    {
        var count = bt.PlacesMatrix.Count;
        bool cond;
        if (count > 0)
            cond = count != newSize.y || bt.PlacesMatrix[0].Length != newSize.x;
        else
            cond = count != newSize.y;
        return cond;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (bt.PlacesMatrix == null)
            bt.PlacesMatrix = new List<bool[]>();
        var oldSize = GetSize(bt.PlacesMatrix);
        var newSize = Vector2IntField("Размер шаблона", GetSize(bt.PlacesMatrix));
        if (SizeNotMatch(newSize))
        {
            BalanceYDim(newSize);
            for (int y = 0; y < newSize.y; y++)
            {
                for (int x = 0; x < newSize.x; x++)
                    BalanceXDim(oldSize, newSize, y);
            }
        }
        int c = 1;
        foreach (var row in bt.PlacesMatrix)
        {
            BeginHorizontal("Box");
            LabelField($"Ряд {c}",GUILayout.Width(50f));
            for (int x = 0; x < row.Length; x++)
            {
                row[x] = Toggle(row[x]);
            }
            EndHorizontal();
            c++;
        }
        CheckDirty();
    }
}