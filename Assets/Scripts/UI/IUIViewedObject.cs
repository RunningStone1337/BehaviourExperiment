using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public interface IUIViewedObject
    {
        Sprite PreviewSprite { get; }
        string ObjectName { get; }
        string ObjectDescription { get; }
    }
}