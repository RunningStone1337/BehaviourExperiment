using System.Collections.Generic;
using UnityEngine;

public enum AdditionalModifiersEnum
{
    None,
    Abstract
}

public enum ModifierEnum
{
    Public,
    Internal,
    Protected,
    Private
}

public abstract class SourceCodeCreatorBase : ScriptableObject
{
    protected string GenerateCode(string nameSpace, string modifier, string addModifier, string createdClassGenericParams, string genericParams, string genericConstarints, string derivedClassFromName)
    {
        if (!string.IsNullOrEmpty(nameSpace))
        {
            return $"using System.Collections;\n" +
                $"using System.Collections.Generic;\n" +
                $"using UnityEngine;\n\n" +
                $"namespace {nameSpace}\n" + "{\n" +
                $"{modifier} {addModifier} class {classNamePrefix}{derivedClassFromName}{createdClassGenericParams} :" +
                $" {derivedClassFromName}{genericParams}\n {genericConstarints}" +
                "{}\n}";
        }
        else
            return $"using System.Collections;\n" +
                $"using System.Collections.Generic;\n" +
                $"using UnityEngine;\n\n" +
                $"{modifier} {addModifier} class {classNamePrefix}{derivedClassFromName} :" +
                $" {derivedClassFromName}{genericParams}\n {genericConstarints}" +
                "{}";
    }

    protected string GetAccessLevel(ModifierEnum classAccesLevel)
    {
        return classAccesLevel switch
        {
            ModifierEnum.Public => "public",
            ModifierEnum.Internal => "internal",
            ModifierEnum.Protected => "protected",
            ModifierEnum.Private => "private",
            _ => default,
        };
    }

    protected string GetAddModifier(AdditionalModifiersEnum addClassModifier)
    {
        return addClassModifier switch
        {
            AdditionalModifiersEnum.None => default,
            AdditionalModifiersEnum.Abstract => "abstract",
            _ => default,
        };
    }

    protected string GetGenericConstraints(List<string> genericConstraints)
    {
        if (genericConstraints.Count > 0)
        {
            string result = string.Empty;
            for (int i = 0; i < genericConstraints.Count; i++)
            {
                result += $"{genericConstraints[i]}\n";
            }
            return result;
        }
        return default;
    }

    protected string GetGenericParams(List<string> derivedClassGenericParameters)
    {
        if (derivedClassGenericParameters.Count > 0)
        {
            string result = "<";
            for (int i = 0; i < derivedClassGenericParameters.Count; i++)
            {
                if (i == derivedClassGenericParameters.Count - 1)//последний
                    result += $"{derivedClassGenericParameters[i]}";
                else
                    result += $"{derivedClassGenericParameters[i]}, ";
            }
            return result + ">";
        }
        return default;
    }

    [SerializeField] public AdditionalModifiersEnum addClassModifier;
    [SerializeField] public ModifierEnum classAccesLevel;
    [SerializeField] public string classNamePrefix;
    [SerializeField] public string createdClassNamespace;
    [SerializeField] public string generatingFolderPath;
}