using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// Интерфейс, укзывающий, что компонент может предоставлять определённый контекст при выборе поведения.
    /// </summary>
    public interface IContextCreator
    {
        List<IContext> CreateContext();
    }
}