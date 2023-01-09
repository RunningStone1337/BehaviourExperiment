using Common;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// »нтерфейс, определ€ющий отображаемые первичные данные в элементах интерфейса
    /// </summary>
    public interface IUIViewedObject : INameHandler, IDescriptionHandler
    {
        Sprite PreviewSprite { get; }
    }
}