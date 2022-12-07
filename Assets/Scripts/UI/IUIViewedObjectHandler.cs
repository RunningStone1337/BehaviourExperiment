using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public interface IUIViewedObjectHandler
    {
        public IUIViewedObject CorrespondingObjectPrefab { get; }
    }
}