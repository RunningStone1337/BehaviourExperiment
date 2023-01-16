using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class SexRect : MonoBehaviour
    {
        [SerializeField] private List<SexBase> sexes;
        [SerializeField] DropdownButtonPair sexDropPair;

        public SexBase SelectedSex { get => (SexBase)sexDropPair.SelectedOptionValue; set => sexDropPair.DropdownValue = value.Name; }


        private void Awake()
        {
            foreach (var s in sexes)
            {
                sexDropPair.AddOption(s.Name, s);
            }
        }

        public void PushButton()
        {
            sexDropPair.PushButton();
        }
    }
}