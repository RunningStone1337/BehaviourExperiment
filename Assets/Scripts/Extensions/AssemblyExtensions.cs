using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Extensions
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Возвращает список Type для baseClassType
        /// </summary>
        /// <param name="ass">Сборка</param>
        /// <param name="baseClassType">Базовый класс</param>
        /// <param name="isAbstract">Нужны ли абстрактные наследники</param>
        /// <returns></returns>
        public static List<Type> GetInheritors(this Assembly ass, Type baseClassType, bool isAbstract = false)
        {
            return ass.GetTypes().Where(x => x.IsSubclassOf(baseClassType) && x.IsAbstract == isAbstract).ToList();
        }
    }
}