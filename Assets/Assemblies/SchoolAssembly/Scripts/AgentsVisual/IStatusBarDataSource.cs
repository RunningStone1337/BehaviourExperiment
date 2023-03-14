using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public interface IStatusBarDataSource
    {
        Sprite StatusBarSprite { get; set; }
        float BarShowingTime { get; set; }
    }
}
