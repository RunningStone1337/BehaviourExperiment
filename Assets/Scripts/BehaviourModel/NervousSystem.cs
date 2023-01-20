using System;
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
        #region main

        [SerializeField] [Range(1, 10)] private int activity;
        [SerializeField] [Range(1f, 10f)] private float currentActivity;
        [SerializeField] [Range(1f, 10f)] private float currentExcitement;
        [SerializeField] [Range(1f, 10f)] private float currentReactivity;
        [SerializeField] private NervousBalanceType nervousBalance;
        [SerializeField] [Range(1, 10)] private int nervousMobility;
        [SerializeField] [Range(1, 10)] private int nervousPower;
        [SerializeField] [Range(1, 10)] private int reactivity;
        /// <summary>
        /// ������� ���������� ����������� �� ��� � �����������������.
        /// </summary>
        public int Activity { get => activity; private set => activity = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// ��������� ���������� � ������������, ���������� ������ �������� - ����������� �� ������� ���� ��� ���������� ����������.
        /// ��� == 1 ����������� 0.5, ���� 1 - ������� ����������, ���� 1 - ������� ������������.
        /// </summary>
        public float ActReactRelation { get => ((float)activity) / reactivity; }

        public float CurrentActivity { get => currentActivity; private set => currentActivity = Mathf.Clamp(value, 1f, 10f); }
        /// <summary>
        /// ������� ������� �������������.
        /// </summary>
        public float CurrentExcitement { get => currentExcitement; private set => currentExcitement = Mathf.Clamp(value, 1f, 10f); }

        public float CurrentReactivity { get => currentReactivity; private set => currentReactivity = Mathf.Clamp(value, 1f, 10f); }

        internal void StartThinking()
        {
            throw new NotImplementedException();
        }

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

        #endregion main

        [SerializeField] private List<IPhenomenon> newProceedPhenomens;
        [SerializeField] private List<(IPhenomenon, float)> phenomensToReact;
        [SerializeField] private AgentBase thisAgent;      

        private List<IPhenomenon> NewPhenomens { get => newProceedPhenomens; set => newProceedPhenomens = value; }
        private List<(IPhenomenon, float)> PhenomensToReact { get => phenomensToReact; set => phenomensToReact = value; }

        /// <summary>
        /// �������� �������� ��� ������� ��� ������� ������� ������� (��������, �������, ����)
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        //private float CalculateContextImportanceValue<T>(T ph) where T : IPhenomenon
        //{
        //    float res = default;
        //    foreach (var charTrait in thisAgent.CharacterSystem)
        //    {
        //        if (charTrait.HasImportanceFor(ph))
        //            res += charTrait.GetImportanceValueFor(ph);
        //        foreach (var c in CurrentAdditionalContext)
        //        {
        //            if (charTrait.HasImportanceFor(ph))
        //                res += charTrait.GetImportanceValueFor(ph);
        //        }
        //    }
        //    return res;
        //}

        /// <summary>
        /// ���������� ��� ������� ��� ������� ��������.
        /// (�����������+�����������������)*������������/10
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        private float CalculateCurrentImportance<T>(T ph) where T : IPhenomenon
        {
            return CurrentReactivity / 10f * (ph.PhenomenonPower +
                //�������� ������� ��� ���� �������� � ������������
                CalculatePersonellImportanceValue(ph) 
                /*+ CalculateContextImportanceValue(ph)*/);
        }

        /// <summary>
        /// ���������� ���������� ��� ������� � ����� ������ ������ ������������.
        /// ������� �� ���������� ����� ���� ��� �������������, ��� � �������������, ��� ������������� �����.
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        private float CalculatePersonellImportanceValue<T>(T ph) where T : IPhenomenon
        {
            float res = 0f;
            ///����� ��������� ��������� ���������� ������� - ������,
            ///�������, ������������, �����! � ����������� �� ��������
            ///���������, ����������� � ����������.
            foreach (var charTrait in thisAgent.CharacterSystem)
                if (charTrait.HasImportanceFor(ph))
                    res += charTrait.GetImportanceValueFor(ph);
            foreach (var feature in thisAgent.FeaturesSystem)
                if (feature.HasImportanceFor(ph))
                    res += feature.GetImportanceValueFor(ph);
            return res;
        }

        /// <summary>
        /// ��������� ��������� ������������ ������� - ���������� ����������
        /// � ������� �� ��������.
        /// </summary>
        private void FilterNewPhenomenons()
        {
            foreach (var ph in NewPhenomens)
                if (IsPhenomenonValuable(ph, out float calculated))
                    PhenomensToReact.Add((ph, calculated));
            NewPhenomens.Clear();
            PhenomensToReact.Sort(PhenonemonComparer);
        }

        /// <summary>
        /// ����������� ���������� ������� � ������ �������.
        /// ���������� - ����� �� ����������� �� ��� �������?
        /// ���������� ������������ �������������, ������� �������������� (��������� ������),
        /// ��������������� ������������� (����� ���������, ����, ������������) � �������� ���������.
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        private bool IsPhenomenonValuable<T>(T ph, out float calculatedImportance) where T : IPhenomenon
        {
            //���������� ���������� �������
            calculatedImportance = CalculateCurrentImportance(ph);
            if (calculatedImportance >= CurrentExcitement)
                return true;
            return false;
        }

        private int PhenonemonComparer((IPhenomenon, float) x, (IPhenomenon, float) y)
        {
            if (x.Item2 > y.Item2)
                return -1;
            if (x.Item2 < y.Item2)
                return 1;
            return 0;
        }

        private int PhenonemonComparer(IPhenomenon x, IPhenomenon y)
        {
            if (x.PhenomenonPower > y.PhenomenonPower)
                return -1;
            if (x.PhenomenonPower < y.PhenomenonPower)
                return 1;
            return 0;
        }

        /// <summary>
        /// ��������� �������, ����������� ��� ��������.
        /// ����������� ����� ���� ��������������� ��������(��� �������, ��� � �������), ������������� ������,
        /// ����� ������������, ��������� �������� �������������� ��������� - ��, ��� ������.
        /// ���������� ������� �� ������ ������ ���������� ����� ���������.
        /// ��������� ����� "�����������" ��� ��������� � �������, �������� ����� �������
        /// ����������, ����� ���������� ����������� � �������� ������������� ������� ��� ������������.
        /// </summary>
        private void ReactAtNewPhenomenons()
        {
            foreach (var ph in PhenomensToReact)
                ReactAtPhenomenon(ph);
            PhenomensToReact.Clear();
        }

        /// <summary>
        /// ������� �� ������� <paramref name="phenomPrioritPair"/>
        /// </summary>
        /// <param name="phenomPrioritPair"></param>
        private void ReactAtPhenomenon((IPhenomenon phenom, float priority) phenomPrioritPair)
        {
            //��������������� ������� �������� �������������� � ������� ����������.
            //������� �������� ������� ������. ������� ������ �������� ����������� ��������.
            //������ ���� ��������� ������� � ��� ����� - ���� � ��������
            var reactions = new List<(List<EmotionBase> reaction, float reactionImportance)>();
            foreach (var charTrait in thisAgent.CharacterSystem)
            {
                if (charTrait.HasReactionOn(phenomPrioritPair.phenom, out List<EmotionBase> reaction))
                    reactions.Add((reaction, CalculateCurrentImportance(EmotionsToPhenom(reaction))));
            }
            foreach (var feature in thisAgent.FeaturesSystem)
            {
                if (feature.HasReactionOn(phenomPrioritPair.phenom, out List<EmotionBase> reaction))
                    reactions.Add((reaction, CalculateCurrentImportance(EmotionsToPhenom(reaction))));
            }
            var c = reactions.Count;
            if (c > 0)
            {
                //reactions.Sort(PhenonemonComparer);
                //var (reaction, importance) = reactions[c - 1];
                //if (importance >= CurrentExcitement)//�������� ����� ������ �������
                //    RealizeAction(reaction);
            }
            else
            {
                //��� ������� �� �������?
                Debug.Log($"�� ���� �������� �� ����� ������� �� ������� {phenomPrioritPair.phenom}");
            }

            //if (ActReactRelation < 1f)//������� ������������
            //{
            //    //������� ����������� �������������� �������
            //    //������ - ����������� ��������
            //}
            //else if (ActReactRelation > 1f)//������� ����������
            //{
            //    //������ ����������� �������������� �������
            //    //������� - ����������� ��������
            //}
            //else
            //{
            //}//������ �����������
        }

        private IPhenomenon EmotionsToPhenom(List<EmotionBase> reaction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ���������� ��������, ��� �� ��� �� ����.
        /// <paramref name="reaction"/> ����� ���� ��������������� ���������(��� �������, ��� � �������), �������������� ������,
        /// ����� ������������, ���������� �������� �������������� ��������� - ��, ��� ������.
        /// </summary>
        /// <param name="reaction"></param>
        private void RealizeAction(IPhenomenon reaction)
        {
            //if (reaction is ComplexAction ca)
            //{
            //}
            //else if (reaction is SimpleAction sa)
            //{
            //}
            //else if (reaction is MindSource m)
            //{
            //}
        }

        /// <summary>
        /// ������� �������������� �������� ��������. ��������� ��������� ������������ � �������.
        /// </summary>
        public List<IPhenomenon> CurrentAdditionalContext { get; private set; }

        /// <summary>
        /// ������� ������� �������� ��������. ��� �������, ��� ������� ���������� �������.
        /// </summary>
        public IPhenomenon CurrentGlobalContext { get; set; }

        /// <summary>
        /// ��������� ������� � ������ �������������� ���� �� ��� ��� ���
        /// </summary>
        /// <param name="phenomens"></param>
        public void AddNewPhenomenons(List<IPhenomenon> phenomens)
        {
            foreach (var p in phenomens)
            {
                if (!newProceedPhenomens.Contains(p))
                    NewPhenomens.Add(p);
            }
            NewPhenomens.Sort(PhenonemonComparer);
        }

        public void Initiate(HumanRawData data)
        {
            CurrentActivity = Activity = data.NsActivity;
            NervousBalance = data.NsType;
            NervousMobility = data.NsMoveability;
            NervousPower = data.NsPower;
            CurrentReactivity = Reactivity = data.NsReactivity;
        }

        /// <summary>
        /// ��������� �������. ����������, �������.
        /// �������, ��������� �������, ������� ���������, ����.
        /// </summary>
        public void ProceedPhenomenons()
        {
            FilterNewPhenomenons();
            ReactAtNewPhenomenons();
        }

        /// <summary>
        /// ������������ ����� �������� �� ������������� ��������.
        /// </summary>
        /// <returns></returns>
        public Func<IEnumerator> SelectAction()
        {
            //foreach (var pa in ProbablyActions)
            //{
            //}
            throw new NotImplementedException();
        }
    }
}