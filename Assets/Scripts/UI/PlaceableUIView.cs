using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class PlaceableUIView : MonoBehaviour, ISelectableUIComponent, IPointerClickHandler
    {
        [SerializeField] Image backImage;
        [SerializeField] Image previewImage;
        [SerializeField] Text nameText;
        [SerializeField] Text descriptionText;
        [SerializeField] GameObject correspondingObjectPrefab;
        [SerializeField] InterierListScreen interierListScreen;
        [SerializeField] bool isSelected;
        [SerializeField] [HideInInspector] Color defaultColor;
        public object DefaultToken { get => defaultColor; set => defaultColor = (Color)value; }
        public InterierListScreen InterierListScreen { get => interierListScreen; }
        public GameObject CorrespondingObjectPrefab { get => correspondingObjectPrefab; }
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
            var UIView = correspondingObjectPrefab.GetComponent<IUIViewedObject>();
            previewImage.sprite = UIView.PreviewSprite;
            nameText.text = UIView.ObjectName;
            descriptionText.text = UIView.ObjectDescription;
        }

        public T GetThisViewObject<T>() where T : MonoBehaviour=>
            CorrespondingObjectPrefab.GetComponent<T>();
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