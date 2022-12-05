using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public abstract class WallStateBase : MonoBehaviour, IState
    {
        [SerializeField] protected Wall thisWall;
        public Wall ThisWall {
            get
            {
                if (thisWall == null)
                    thisWall = GetComponent<Wall>();
                return thisWall;
            } 
        }

        public abstract void Initiate();
    }
}