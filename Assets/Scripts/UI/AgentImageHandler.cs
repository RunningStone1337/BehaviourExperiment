using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AgentImageHandler : MonoBehaviour
    {
        [SerializeField] Image thisImage;
        [SerializeField] List<Sprite> spritesList;

        public Image Image { get=> thisImage; }
        public int ImageID { get; private set; }
        public Sprite DefaultImage { get => spritesList.Count > 0 ? spritesList[0] : null; }

        public void ChooseImage()
        {

        }
        private void Start()
        {
            ImageID = spritesList.IndexOf(thisImage.sprite);
        }
        public Sprite GetImage(ushort imageID)
        {
            return spritesList[imageID];
        }
    }
}