using System;
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

        Sprite DefaultImage { get => spritesList.Count > 0 ? spritesList[0] : null; }
        //public Image Image { get => thisImage; }
        public int ImageID { get; private set; }

        public Sprite GetCurrentSprite() => thisImage.sprite;

        public void ChooseImage()
        {
        }

       

        public void SetImageByID(int imageID)
        {
            thisImage.sprite = spritesList[imageID];
        }

        public void SetDefaultImage()
        {
            thisImage.sprite = DefaultImage;
        }
    }
}