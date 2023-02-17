using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "CodeGenerators/SourceCodeGenerator", fileName = "Generator")]
public class SingleSourceCodeCreator : SourceCodeCreatorBase
{
    public string derivedClassFromName;
    public List<string> derivedClassGenericParameters;
    public List<string> createdClassGenericParameters;
    public List<string> genericConstraints;

    public void CreateClass()
    {
        CreateClass(derivedClassFromName);
    }

    public void CreateClass(string derivedFromClassName)
    {
        var dirInfo = new DirectoryInfo(generatingFolderPath);
        if (!dirInfo.Exists)
            Directory.CreateDirectory(generatingFolderPath);
        var fullPath = generatingFolderPath + $"/{classNamePrefix}{derivedFromClassName}.cs";
        if (File.Exists(fullPath))
        {
            Debug.Log($"File with name {classNamePrefix}{derivedFromClassName} already exists");
            return;
        }
        var acessLevel = GetAccessLevel(classAccesLevel);
        var addModifier = GetAddModifier(addClassModifier);
        var genericParams = GetGenericParams(derivedClassGenericParameters);
        var newClassgenericParams = GetGenericParams(createdClassGenericParameters);
        var genericConstarints = GetGenericConstraints(genericConstraints);
        string code = GenerateCode(createdClassNamespace, acessLevel, addModifier, newClassgenericParams, genericParams, genericConstarints, derivedFromClassName);
        File.WriteAllText(fullPath, code);
    }
}
