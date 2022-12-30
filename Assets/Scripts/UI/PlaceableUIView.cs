using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class PlaceableUIView : MonoBehaviour, ISelectableUIComponent, IPointerClickHandler, IUIViewedObjectHandler
    {
        [SerializeField] Image backImage;
        [SerializeField] Image previewImage;
        [SerializeField] Text nameText;
        [SerializeField] Text descriptionText;
        [SerializeField] GameObject correspondingObjectPrefab;
        [SerializeField] bool isSelected;
        [SerializeField] [HideInInspector] Color defaultColor;
        public object DefaultToken { get => defaultColor; set => defaultColor = (Color)value; }
        public IUIViewedObject CorrespondingObjectPrefab
        {
            get
            {

                var comp = correspondingObjectPrefab.GetComponent<IUIViewedObject>();
                if (comp == null)
                    comp = correspondingObjectPrefab.GetComponent<IUIViewedObjectHandler>().CorrespondingObjectPrefab;
                return comp;
            }
            set => correspondingObjectPrefab = ((Component)value).gameObject;
        }
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                if (isSelected)
                    SetHighlightedState();
                else
                    SetDisabledState();
            }
        }


        [ContextMenu("Init")]
        public void InitUIView()
        {
            previewImage.sprite = CorrespondingObjectPrefab.PreviewSprite;
            nameText.text = CorrespondingObjectPrefab.ObjectName;
            descriptionText.text = CorrespondingObjectPrefab.ObjectDescription;
        }

        public T GetThisViewObject<T>() where T : MonoBehaviour=>
            correspondingObjectPrefab.GetComponent<T>();
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneMaster.Master.HandlePlaceableUIViewClick(this, eventData);
        }

        public void SetDisabledState()
        {
            backImage.color = (Color)DefaultToken;
        }

        public void SetHighlightedState()
        {
            backImage.color = Color.yellow;
        }

        private void Awake()
        {
            InitUIView();
            DefaultToken = backImage.color;
        }
    }
}