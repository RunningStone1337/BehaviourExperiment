using BuildingModule;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Extensions;

[CustomEditor(typeof(ObjectPlacingTypesSolver))]
public class ObjectPlacingTypesSolverEditor : CustomEditorBase
{
    ObjectPlacingTypesSolver opts;
    List<Type> types;
    Type type;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        (opts.ObjectBaseType, opts.index, opts.displayedName) = DrawTypeSelector(types, type, opts.index);
    }
    private void OnEnable()
    {
        opts = (ObjectPlacingTypesSolver)target;
        type = typeof(InterierBase);
        types = Assembly.GetAssembly(type).GetInheritors(type);
    }
}
