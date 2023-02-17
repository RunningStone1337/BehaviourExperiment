//using UnityEditor;
//using UnityEngine;
//using static UnityEditor.EditorGUI;
//using static UnityEditor.EditorGUILayout;

////[CustomEditor(typeof(CharacterToPhenomFloatRelationsTable))]
//public class CharacterToPhenomFloatRelationsTableEditor : CharacterToPhenomTableEditor<float>
//{
//    private CharacterToPhenomFloatRelationsTable cf;

//    protected override void OnEnable()
//    {
//        base.OnEnable();
//        cf = (CharacterToPhenomFloatRelationsTable)target;
//    }

//    protected override void DrawArrayInRow(string rowLabel, float[] arr)
//    {
//        BeginHorizontal("box");
//        LabelField(rowLabel, GUILayout.Width(cf.labelsWidth));
//        for (int i = 0; i < cf.ColumnsCount; i++)
//        {
//            arr[i] = FloatField(arr[i], GUILayout.Width(cf.cellWidth));
//        }
//        EndHorizontal();
//    }
//}