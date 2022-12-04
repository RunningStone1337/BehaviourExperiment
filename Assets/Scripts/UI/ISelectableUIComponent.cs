using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public interface ISelectableUIComponent
    {
        /// <summary>
        /// ������, ������������ ��� �������� � �������������� ���������� �������� ����������.
        /// </summary>
        object DefaultToken { get; set; }
        /// <summary>
        /// ��� ������������ ����� ����� ����������� ���� �� �������.
        /// </summary>
        bool IsSelected { get; set; }
        void SetDisabledState();
        void SetHighlightedState();
    }
}