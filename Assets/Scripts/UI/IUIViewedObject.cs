using Common;
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