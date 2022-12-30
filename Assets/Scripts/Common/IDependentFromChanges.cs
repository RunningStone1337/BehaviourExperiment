using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// ���������, ����������� ��������� ��������� ������� ��� ��������� ����������� �������
    /// </summary>
    public interface IDependentFromChanges
    {
        /// <summary>
        /// �������� ��������� ������� ��� ����������
        /// </summary>
        /// <param name="param"></param>
        void ResetIfConditionsChanged(object param);
    }
}