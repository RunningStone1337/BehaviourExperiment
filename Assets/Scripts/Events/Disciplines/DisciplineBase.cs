using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public abstract class DisciplineBase : ScriptableObject
    {
        [SerializeField] string disciplineName;
        public string DisciplineName { get=> disciplineName; }
    }
}