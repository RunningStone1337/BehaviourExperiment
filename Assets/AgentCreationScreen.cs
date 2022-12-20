using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AgentCreationScreen : UIScreenBase
    {
        [SerializeField] Image agentImage;
        [SerializeField] TextButtonPair nameInputFieldButtonPair;
        [SerializeField] DropdownButtonPair sexDropButtonPair;
        [SerializeField] DropdownButtonPair ageDropButtonPair;
        [SerializeField] DropdownButtonPair weightDropButtonPair;
        [SerializeField] DropdownButtonPair heightDropButtonPair;
        [Space]
        [SerializeField] int minAge = 8;
        [SerializeField] int maxAge = 18;
        [SerializeField] int minWeight = 20;
        [SerializeField] int maxWeight = 70;
        [SerializeField] int minHeight = 115;
        [SerializeField] int maxHeight = 180;
        private void Start()
        {
            InitiateComponents();
        }

        private void InitiateComponents()
        {
            for (int age = minAge; age <= maxAge; age++)
            {
                ageDropButtonPair.AddDropdownOption(age.ToString());
            }
            for (int weight = minWeight; weight <= maxWeight; weight++)
            {
                weightDropButtonPair.AddDropdownOption(weight.ToString());
            }
            for (int height = minHeight; height <= maxHeight; height++)
            {
                heightDropButtonPair.AddDropdownOption(height.ToString());
            }
        }
    }
}