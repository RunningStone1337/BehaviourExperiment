using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AgentImageHandler : MonoBehaviour
    {
        [SerializeField] private List<Sprite> spritesList;
        [SerializeField] private Image thisImage;

        private void Start()
        {
            ImageID = spritesList.IndexOf(thisImage.sprite);
        }

        public Sprite DefaultImage { get => spritesList.Count > 0 ? spritesList[0] : null; }
        public Image Image { get => thisImage; }
        public int ImageID { get; private set; }

        public void ChooseImage()
        {
        }

        public Sprite GetImage(int imageID)
        {
            if (imageID >= spritesList.Count || imageID == -1)
            {
                return default;
            }
            return spritesList[imageID];
        }
    }
}