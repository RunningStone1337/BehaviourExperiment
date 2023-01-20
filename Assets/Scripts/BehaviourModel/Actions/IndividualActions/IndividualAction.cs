using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// �������� ��������, ������������ �� ���� ����/����/��������
    /// </summary>
    public abstract class IndividualAction : ActionBase
    {
        protected IndividualAction(IPhenomenon context):base(context)
        {
        }
    }
}