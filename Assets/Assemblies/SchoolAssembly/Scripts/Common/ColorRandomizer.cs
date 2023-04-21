using UnityEngine;

namespace Common
{
    public class ColorRandomizer : MonoBehaviour
    {
        [SerializeField] SpriteRenderer mainRenderer;
        private void Awake()
        {
            mainRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
