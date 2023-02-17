using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditorInternal;
using UnityEngine;

[CreateAssetMenu(menuName = "CodeGenerators/AssemblySelectionCodeGenerator", fileName = "Generator")]
public class AssemblySelectionCodeCreator : SingleSourceCodeCreator
{
    public string targetAssembly;
    public int assemblyIndex;
    public int classIndex;
}
