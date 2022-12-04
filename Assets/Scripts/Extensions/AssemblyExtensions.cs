using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Extensions
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// ���������� ������ Type ��� baseClassType
        /// </summary>
        /// <param name="ass">������</param>
        /// <param name="baseClassType">������� �����</param>
        /// <param name="isAbstract">����� �� ����������� ����������</param>
        /// <returns></returns>
        public static List<Type> GetInheritors(this Assembly ass, Type baseClassType, bool isAbstract = false)
        {
            return ass.GetTypes().Where(x => x.IsSubclassOf(baseClassType) && x.IsAbstract == isAbstract).ToList();
        }
    }
}