using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public interface ICurrentStateHandler 
    {
       IState CurrentState { get; set; }
    }
}