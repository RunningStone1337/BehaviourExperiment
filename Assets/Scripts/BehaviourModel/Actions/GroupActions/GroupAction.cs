using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// �������� ��������, ������������ �� ������ �����/�����/�����
    /// </summary>
    public abstract class GroupAction : ActionBase
    {
        public GroupAction(IPhenomenon context):base(context)
        {

        }
    }
}