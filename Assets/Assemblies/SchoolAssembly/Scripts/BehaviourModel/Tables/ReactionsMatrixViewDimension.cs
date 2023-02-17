using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BehaviourModel
{
    public class ReactionsMatrixViewDimension : ClassMatrixViewDimension<ReactionsWrapper>
    {
        //[ShowInInspector, TableMatrix(IsReadOnly = true, SquareCells = true, DrawElementMethod = "ReactionsSelectorDrawer"), FoldoutGroup("Calmness")]
        //public override ReactionsWrapper[,] CalmMatrix { get => calmMatrix; protected set => calmMatrix = value; }
        //[ShowInInspector, TableMatrix(IsReadOnly = true), FoldoutGroup("Courage")]
        //public override ReactionsWrapper[,] CourageMatrix { get => courageMatrix; protected set => courageMatrix = value; }

        //static ReactionsWrapper ReactionsSelectorDrawer(Rect rect, ReactionsWrapper value)
        //{
        //    if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
        //    {
        //        Debug.Log("Click!");
        //    }

        //    return value;
        //}
    }
}
