using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public interface IOptionsHandler 
    {
        string SelectedOptionValue { get; set; }
        object ValueObject { get; set; }
        void AddOption(string option);
        void RemoveOption(string option);
    }
}