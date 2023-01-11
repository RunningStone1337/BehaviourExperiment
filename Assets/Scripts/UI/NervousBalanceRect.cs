using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UI
{
    public class NervousBalanceRect : MonoBehaviour
    {
        [SerializeField] DropdownButtonPair balanceDropdownPair;
        [SerializeField] List<NervousBalanceType> nervousBalanceTypes;
        public DropdownButtonPair BalanceDropdownButtonPair => balanceDropdownPair;

        private void Awake()
        {
            foreach (var n in nervousBalanceTypes)
            {
                balanceDropdownPair.AddOption(n.Name, n);
            }
        }

        
    }
}