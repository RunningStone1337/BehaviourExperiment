using System;
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
        [SerializeField] [Range(1, 10)] private int activity;
        [SerializeField] [Range(1, 10)] private int reactivity;
        [SerializeField] [Range(1, 10)] private int nervousMobility;
        [SerializeField] [Range(1, 10)] private int nervousPower;
        [SerializeField] [Range(1, 10)] private int currentExcitement;
        [SerializeField] NervousBalanceType nervousBalance;

        /// <summary>
        /// ������� ���������� ����������� �� ��� � �����������������.
        /// </summary>
        public int Activity { get => activity; private set => activity = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// ��������� ���������� � ������������, ���������� ������ �������� - ����������� �� ������� ���� ��� ���������� ����������.
        /// ��� == 1 ����������� 0.5, ���� 1 - ������� ����������, ���� 1 - ������� ������������.
        /// </summary>
        public float ActReactRelation { get => ((float)activity) / reactivity; }

        /// <summary>
        /// ���������������� �� � �������� ������� �������, ���������� ����������� ����� ������������
        /// � �����������, ������ ���� ���������. �������� ��������������� ��������� ������� �������,
        /// ���������� � ��������� � ������� (� ����� � ������������) ������������ ��� ������ ������� ������������.
        /// </summary>
        public NervousBalanceType NervousBalance { get => nervousBalance; private set => nervousBalance = value; }

        /// <summary>
        /// ����������� �� - �������� ������� �������, ��������� � ����������� ������ ����������� �� ��������� � ���������� �����,
        /// ����������� ������������� � ��������������� �������� �� ��������� � ��������.
        /// </summary>
        public int NervousMobility { get => nervousMobility; private set => nervousMobility = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// ���� �� - �������� ������� �������, ���������� ������ ����������������� ������ ���� ��������� �����,
        /// �.�. �� ����������� �����������, �� �������� � ��������� ��������� (����������),
        /// ���� ����� �������, ���� ��������� ����������� (���� � �� �������) �����������.
        /// C��� ������� ������� ������� ����� � ����������������� ������������:
        /// ����� ������ ������� ������� �������� � ����� ��������������, �.�.
        /// ��� �������� ����������� �� ������� ����� ������ �������������, ��� �������.
        /// </summary>
        public int NervousPower { get => nervousPower; private set => nervousPower = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// ������� ���������������� ������� �� ������� � ���������� ��������.
        /// </summary>
        public int Reactivity { get => reactivity; private set => reactivity = Mathf.Clamp(value, 1, 10); }

        public void Initiate(HumanRawData data)
        {
            Activity = data.NsActivity;
            NervousBalance = data.NsType;
            NervousMobility = data.NsMoveability;
            NervousPower = data.NsPower;
            Reactivity = data.NsReactivity;
        }
    }
}