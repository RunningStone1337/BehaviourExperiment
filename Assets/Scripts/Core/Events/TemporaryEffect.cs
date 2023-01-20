using BehaviourModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class TemporaryEffect : ScriptableObject, IPhenomenon
    {
        //public abstract List<ActionBase> CreateActions();
        [SerializeField] int effectImportance;
        public int PhenomenonPower { get => effectImportance; set => effectImportance = value; }
    }
}