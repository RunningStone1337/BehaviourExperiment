using System;

public static partial class TypeExtensions
{
    public static bool Equals<T>(this Type type)
    {
        return type.Equals(typeof(T));
    }

    public static string[] GetNames(this Type[] types)
    {
        string[] options = new string[types.Length];
        for (int i = 0; i < types.Length; i++)
            options[i] = types[i].Name;
        return options;
    }

    public static string[] GetFullNames(this Type[] types)
    {
        string[] options = new string[types.Length];
        for (int i = 0; i < types.Length; i++)
            options[i] = types[i].AssemblyQualifiedName;
        return options;
    }
}