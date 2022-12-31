using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// ���������, ������������ ������������ ��������� ������ � ��������� ����������
    /// </summary>
    public interface IUIViewedObject : INameHandler, IDescriptionHandler
    {
        Sprite PreviewSprite { get; }
    }
}