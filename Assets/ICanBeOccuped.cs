using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public interface ICanBeOccuped
    {
       bool IsOccuped { get; set; }
    }
}