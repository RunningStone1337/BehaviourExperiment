using UnityEngine;

namespace UI
{
    public class GameSpeedHandler : MonoBehaviour
    {
        static float cachedDelta;
        private void Awake()
        {
            cachedDelta = Time.fixedDeltaTime;
        }
        public void OnChangeGameSpeedButtonClickCallback(float speedRatio)
        {
            Time.timeScale = speedRatio;
        }
    }
}
