using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// ���������, ����������, ��� ��������� ����� ������������� ����������� �������� ��� ������ ���������.
    /// </summary>
    public interface IContextCreator
    {
        List<IContext> CreateContext();
    }
}