using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Common
{
    [RequireComponent(typeof(InterierListScreen))]
    public class AdderBase<T> : MonoBehaviour where T: MonoBehaviour, IUIViewedObject
    {
        [SerializeField] InterierListScreen interierListScreen;
        [SerializeField] List<T> objectsToAdd;
        [SerializeField] GameObject viewPerfab;
        public GameObject ViewPrefab { get => viewPerfab; set => viewPerfab = value; }
        public List<T> ObjectsToAdd { get=> objectsToAdd; set=> objectsToAdd = value; }
        InterierListScreen InterierListScreen
        {
            get
            {
                if (interierListScreen == null)
                    interierListScreen = GetComponent<InterierListScreen>();
                return interierListScreen;
            }
        }

        void OnEnable()
        {
            interierListScreen = GetComponent<InterierListScreen>();
        }

        public void AddAllObjects()
        {
            foreach (var o in ObjectsToAdd)
            {
                if (o != null)
                    AddObjectToScreen(o);
            }
            ObjectsToAdd = null;
        }

        private void AddObjectToScreen(T o)
        {
            var transf = InterierListScreen.ContentTransform;
            var view = Instantiate(viewPerfab, transf).GetComponent<PlaceableUIView>();
            view.CorrespondingObjectPrefab = o;
        }       
    }
}