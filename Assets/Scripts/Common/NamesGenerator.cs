using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Common
{
    public class NamesGenerator : MonoBehaviour
    {
        [SerializeField] NamesLibrary library;
        [SerializeField] TextButtonPair nameInputField;
        [SerializeField] DropdownButtonPair sexDrop;
        public void GenerateRandomName()
        {
            var male = sexDrop.DropdownValue == "ì";
            if (male)
                nameInputField.InputField.text = library.GetFullMaleCombination();
            else
                nameInputField.InputField.text = library.GetFullFemaleCombination();
        }
    }
}