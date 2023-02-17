using Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class PlaceableUIView : MonoBehaviour, ISelectableUIComponent, IPointerClickHandler, IUIViewedObjectHandler
    {
        [SerializeField] private Image backImage;
        [SerializeField] private GameObject correspondingObjectPrefab;
        [SerializeField] [HideInInspector] private Color defaultColor;
        [SerializeField] private Text descriptionText;
        [SerializeField] private bool isSelected;
        [SerializeField] private Text nameText;
        [SerializeField] private Image previewImage;

        private void Awake()
        {
            InitUIView();
            DefaultToken = backImage.color;
        }

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

        public object DefaultToken { get => defaultColor; set => defaultColor = (Color)value; }
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

        public T GetThisViewObject<T>() where T : MonoBehaviour =>
            correspondingObjectPrefab.GetComponent<T>();

        [ContextMenu("Init")]
        public void InitUIView()
        {
            previewImage.sprite = CorrespondingObjectPrefab.PreviewSprite;
            nameText.text = CorrespondingObjectPrefab.Name;
            descriptionText.text = CorrespondingObjectPrefab.ObjDescription;
        }

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
    }
}