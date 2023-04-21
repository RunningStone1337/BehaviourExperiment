using UnityEngine;

namespace BehaviourModel
{
    public interface IStatusBarDataSource
    {
        float BarShowingTime { get; set; }
        Sprite StatusBarSprite { get; set; }
    }
}