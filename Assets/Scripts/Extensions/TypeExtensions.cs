using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Extensions
{
    public static class TypeExtensions
    {
        public static bool Equals<T>(this Type type)
        {
            return type.Equals(typeof(T));
        }
    }
}