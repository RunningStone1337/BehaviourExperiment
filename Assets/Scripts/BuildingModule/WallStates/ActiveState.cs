using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class ActiveState : WallStateBase
    {

        public override void Initiate()
        {
            ThisWall.Renderer.enabled = true;
        }
    }
}