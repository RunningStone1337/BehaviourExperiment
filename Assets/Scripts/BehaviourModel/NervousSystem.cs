using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// ������������� ������� ������� ��������.
    /// ������ ������� ��������� ����������� ����������, ����������� ��������� ������� �� �������� �
    /// ��������� ����� ��������, ��������� ������� ��� ��������.
    /// ������� ������������ ����������� ��������.
    /// </summary>
    public class NervousSystem : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] int nervousPower;
        [SerializeField] [Range(1, 10)] int nervousMobility;
        [SerializeField] [Range(1, 10)] int reactivity;
        [SerializeField] [Range(1, 10)] int activity;
        [SerializeField] [Range(1f, 10f)] float actReactRelation;
        [SerializeField] int[] nervousBalance;
        ///�������� ������� ������� ����������� ��
        ///���������� ����������������� �� ��������� � ����������

        /// <summary>
        /// ���� �� - �������� ������� �������, ���������� ������ ����������������� ������ ���� ��������� �����,
        /// �.�. �� ����������� �����������, �� �������� � ��������� ��������� (����������),
        /// ���� ����� �������, ���� ��������� ����������� (���� � �� �������) �����������.
        /// C��� ������� ������� ������� ����� � ����������������� ������������: 
        /// ����� ������ ������� ������� �������� � ����� ��������������, �.�.
        /// ��� �������� ����������� �� ������� ����� ������ �������������, ��� �������.
        /// </summary>
        public int NervousPower { get => nervousPower; set => nervousPower = Mathf.Clamp(value, 1, 10); }
        /// <summary>
        /// ����������� �� - �������� ������� �������, ��������� � ����������� ������ ����������� �� ��������� � ���������� �����,
        /// ����������� ������������� � ��������������� �������� �� ��������� � ��������.
        /// </summary>
        public int NervousMobility { get => nervousMobility; set => nervousMobility = Mathf.Clamp(value, 1, 10); }
        /// <summary>
        /// ���������������� �� � �������� ������� �������, ���������� ����������� ����� ������������ 
        /// � �����������, ������ ���� ���������. �������� ��������������� ��������� ������� �������,
        /// ���������� � ��������� � ������� (� ����� � ������������) ������������ ��� ������ ������� ������������.
        /// </summary>
        public int[] NervousBalance { get => nervousBalance; set => nervousBalance = value; }
        /// <summary>
        /// ������� ���������������� ������� �� ������� � ���������� ��������.
        /// </summary>
        public int Reactivity { get => reactivity; set => reactivity = Mathf.Clamp(value, 1, 10); }
        /// <summary>
        /// ������� ���������� ����������� �� ��� � �����������������.
        /// </summary>
        public int Activity { get => activity; set => activity = Mathf.Clamp(value, 1, 10); }
        /// <summary>
        /// ��������� ���������� � ������������, ���������� ������ �������� - ����������� �� ������� ���� ��� ���������� ����������.
        /// ��� == 1 ����������� 0.5, ���� 1 - ������� ����������, ���� 1 - ������� ������������.
        /// </summary>
        public float ActReactRelation { get => actReactRelation; set => actReactRelation = activity/reactivity; }
    }
}