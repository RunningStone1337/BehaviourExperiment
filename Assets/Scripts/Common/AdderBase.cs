using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Common
{
    [RequireComponent(typeof(InterierListScreen))]
    public class AdderBase<T> : MonoBehaviour where T : MonoBehaviour, IUIViewedObject
    {
        [SerializeField] private InterierListScreen interierListScreen;
        [SerializeField] private List<T> objectsToAdd;
        [SerializeField] private GameObject viewPerfab;
        private InterierListScreen InterierListScreen
        {
            get
            {
                if (interierListScreen == null)
                    interierListScreen = GetComponent<InterierListScreen>();
                return interierListScreen;
            }
        }

        private void AddObjectToScreen(T o)
        {
            var transf = InterierListScreen.ContentTransform;
            var view = Instantiate(viewPerfab, transf).GetComponent<PlaceableUIView>();
            view.CorrespondingObjectPrefab = o;
        }

        private void OnEnable()
        {
            interierListScreen = GetComponent<InterierListScreen>();
        }

        public List<T> ObjectsToAdd { get => objectsToAdd; set => objectsToAdd = value; }
        public GameObject ViewPrefab { get => viewPerfab; set => viewPerfab = value; }

        public void AddAllObjects()
        {
            foreach (var o in ObjectsToAdd)
            {
                if (o != null)
                    AddObjectToScreen(o);
            }
            ObjectsToAdd = null;
        }
    }
}