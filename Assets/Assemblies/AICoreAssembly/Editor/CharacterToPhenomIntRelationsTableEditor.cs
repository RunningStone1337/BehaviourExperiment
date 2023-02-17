//using UnityEditor;
//using UnityEngine;
//using static UnityEditor.EditorGUILayout;

//[CustomEditor(typeof(CharacterToPhenomIntRelationsTable))]
//public class CharacterToPhenomIntRelationsTableEditor : CharacterToPhenomTableEditor<int>
//{
//    private CharacterToPhenomIntRelationsTable cr;

//    protected override void OnEnable()
//    {
//        base.OnEnable();
//        cr = (CharacterToPhenomIntRelationsTable)target;
//    }

//    protected override void DrawArrayInRow(string rowLabel, int[] arr)
//    {
//        BeginHorizontal("box");
//        LabelField(rowLabel, GUILayout.Width(cr.labelsWidth));
//        for (int i = 0; i < cr.ColumnsCount; i++)
//        {
//            arr[i] = IntField(arr[i], GUILayout.Width(cr.cellWidth));
//        }
//        EndHorizontal();
//    }

//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//    }
//}