using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class AssemblyExtensions
{
    public static string[] AssemblyToString(this Assembly[] assemblies)
    {
        string[] options = new string[assemblies.Length];
        for (int i = 0; i < assemblies.Length; i++)
        {
            var name = assemblies[i].GetName();
            options[i] = name.Name;
        }
        return options;
    }
    private static readonly HashSet<string> internalAssemblyNames = new HashSet<string>()
    {
        "Bee.BeeDriver",
        "ExCSS.Unity",
        "Mono.Security",
        "mscorlib",
        "netstandard",
        "Newtonsoft.Json",
        "nunit.framework",
        "ReportGeneratorMerged",
        "Unrelated",
        "SyntaxTree.VisualStudio.Unity.Bridge",
        "SyntaxTree.VisualStudio.Unity.Messaging",
    };

    public static Assembly[] GetUserCreatedAssemblies(this AppDomain appDomain)
    {
        List<Assembly> assemblies = new List<Assembly>();
        foreach (var assembly in appDomain.GetAssemblies())
        {
            if (assembly.IsDynamic)
            {
                continue;
            }

            var assemblyName = assembly.GetName().Name;
            if (assemblyName.StartsWith("System") ||
               assemblyName.StartsWith("Unity") ||
               assemblyName.StartsWith("UnityEditor") ||
               assemblyName.StartsWith("UnityEngine") ||
               internalAssemblyNames.Contains(assemblyName))
            {
                continue;
            }
            assemblies.Add(assembly);
        }
        return assemblies.ToArray();
    }
    /// <summary>
    /// Возвращает список Type для baseClassType
    /// </summary>
    /// <param name="ass">Сборка</param>
    /// <param name="baseClassType">Базовый класс</param>
    /// <param name="isAbstract">Нужны ли абстрактные наследники</param>
    /// <returns></returns>
    public static List<Type> GetInheritors(this Assembly ass, Type baseClassType, bool isAbstract = false)
    {
        return ass.GetTypes().Where(x => baseClassType.IsAssignableFrom(x) && x.IsAbstract == isAbstract).ToList();
    }
}