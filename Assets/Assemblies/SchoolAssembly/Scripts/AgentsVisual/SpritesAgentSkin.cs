using UnityEngine;

namespace BehaviourModel
{
    public class SpritesAgentSkin : AgentsSkin
    {
        [SerializeField] private SpriteRenderer[] skinSprites;

        private void CheckFlags()
        {
            if (skinSprites.Length > 0)
            {
                if (skinSprites[0].color.a == 0f)
                    IsHided = true;
                else
                {
                    IsHided = false;
                    if (skinSprites[0].color.a == 1f)
                        IsFullShowed = true;
                    else
                        IsFullShowed = false;
                }
            }
        }

        public override void DecreaseVisibility()
        {
            for (int sprite = 0; sprite < skinSprites.Length; sprite++)
            {
                var col = skinSprites[sprite].color;
                skinSprites[sprite].color = new Color(col.r, col.g, col.b, Mathf.Clamp(col.a - opacityChangeStep, 0f, 1f));
            }
            CheckFlags();
        }

        public override void IncreaseVisibility()
        {
            for (int sprite = 0; sprite < skinSprites.Length; sprite++)
            {
                var col = skinSprites[sprite].color;
                skinSprites[sprite].color = new Color(col.r, col.g, col.b, Mathf.Clamp(col.a + opacityChangeStep, 0f, 1f));
            }
            CheckFlags();
        }
    }
}