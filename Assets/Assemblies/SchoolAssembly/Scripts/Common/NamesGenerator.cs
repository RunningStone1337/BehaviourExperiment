using UI;
using UnityEngine;

namespace Common
{
    public class NamesGenerator : MonoBehaviour
    {
        [SerializeField] private NamesLibrary library;
        [SerializeField] private TextButtonPair nameInputField;
        [SerializeField] private DropdownButtonPair sexDrop;

        public void GenerateRandomName()
        {
            var male = sexDrop.DropdownValue == "Ì";
            if (male)
                nameInputField.InputField.text = library.GetFullMaleCombination();
            else
                nameInputField.InputField.text = library.GetFullFemaleCombination();
        }
    }
}