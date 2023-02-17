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
        protected GroupAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
    }
}