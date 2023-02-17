using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CodeGenerators/BundleAssemblySelectionSourceCodeGenerator", fileName = "Generator")]
public class BundleAssemblySelectionCodeCreator : BundleSourceCodeCreator
{
    //public AssemblySelectionCodeCreator assemblyCreator;
    internal int assemblyIndex;
    internal List<int> Indexes;
    internal List<string> TypesFullNames;
}
