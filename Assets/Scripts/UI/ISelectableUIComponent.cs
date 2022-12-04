using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public interface ISelectableUIComponent
    {
        /// <summary>
        /// Объект, используемый для хранения и восстановления дефолтного значения компонента.
        /// </summary>
        object DefaultToken { get; set; }
        /// <summary>
        /// При переключении этого флага срабатывает один из методов.
        /// </summary>
        bool IsSelected { get; set; }
        void SetDisabledState();
        void SetHighlightedState();
    }
}