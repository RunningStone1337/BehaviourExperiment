using UnityEngine;

[CreateAssetMenu(menuName = "CodeGenerators/AssemblySelectionCodeGenerator", fileName = "Generator")]
public class AssemblySelectionCodeCreator : SingleSourceCodeCreator
{
    public int assemblyIndex;
    public int classIndex;
    public string targetAssembly;
}