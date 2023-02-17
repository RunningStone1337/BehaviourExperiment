using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CodeGenerators/BundleSourceCodeGenerator", fileName = "Generator")]
public class BundleSourceCodeCreator : SourceCodeCreatorBase
{
    public SingleSourceCodeCreator creator;
    public List<string> derivedFromClasses;

    internal void CreateClasses()
    {
        foreach (var className in derivedFromClasses)
        {
            creator.CreateClass(className);
        }
    }
}
