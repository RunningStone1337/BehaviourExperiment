using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BehaviourModel
{
    /// <summary>
    /// ������������� ������� ������� ��������.
    /// ������ ������� ��������� ����������� ����������, ����������� ��������� ������� �� �������� �
    /// ��������� ����� ��������, ��������� ������� ��� ��������.
    /// ������� ������������ ����������� ��������.
    /// </summary>
    public abstract class NervousSystem<TReaction, TFeature, TState> : SystemBase<TReaction, TFeature, TState>
        where TReaction :IReaction
        where TFeature : IFeature 
        where TState : IState
    {
        [SerializeField] private bool actionSelected;
        [SerializeField] private TReaction lastReaction;
        [SerializeField] private List<IPhenomenon> newPhenomens;
        [SerializeField] [Range(0f, 10f)] private float observationPause = 1f;
        [SerializeField] private Dictionary<IPhenomenon, float> phenomensToReact;
        [SerializeField] private List<TReaction> temporaryReactions;
        private List<IPhenomenon> NewPhenomens { get => newPhenomens; }
        private Dictionary<IPhenomenon, float> PhenomensToReact { get => phenomensToReact; }

        /// <summary>
        /// ��������� ������� � ������ �������������� ���� �� ��� ��� ���
        /// </summary>
        /// <param name="phenomens"></param>
        private IEnumerator AddNewPhenomenons(List<IPhenomenon> phenomens)
        {
            foreach (var p in phenomens)
            {
                if (!newPhenomens.Contains(p))
                    NewPhenomens.Add(p);
                yield return null;
            }
            NewPhenomens.Sort(PhenonemonComparer);
        }

        private void Awake()
        {
            temporaryReactions = new List<TReaction>();
            newPhenomens = new List<IPhenomenon>();
            phenomensToReact = new Dictionary<IPhenomenon, float>();
        }

        /// <summary>
        /// ���������� ��� ������� ��� ������� ��������.
        /// (�����������+�����������������)*������������
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        public abstract float CalculateCurrentImportance<T>(T ph) where T : IPhenomenon;
        //{
        //    return thisAgent.CharacterSystem.RelaxationTension.RawCharacterValue/10f * (ph.PhenomenonPower
        //        //�������� ������� ��� ���� �������� � ������������
        //        + CalculatePersonellImportanceValue(ph)
        //        /*+ CalculateContextImportanceValue(ph)*/);
        //}

        /// <summary>
        /// ���������� ���������� ��� ������� � ����� ������ ������ ������������.
        /// ������� �� ���������� ����� ���� ��� �������������, ��� � �������������, ��� ������������� �����.
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        private float CalculatePersonellImportanceValue<T>(T ph) where T : IPhenomenon
        {
            //float res = 0f;
            /////����� ��������� ��������� ���������� ������� - ������,
            /////�������, ������������, �����! � ����������� �� ��������
            /////���������, ����������� � ����������.
            //foreach (var charTrait in thisAgent.CharacterSystem)
            //    res += charTrait.GetImportanceValueFor(ph);
            //return res;
            throw new NotImplementedException();
        }

        /// <summary>
        /// ��������� ��������� ������������ ������� - ���������� ����������.
        /// </summary>
        private IEnumerator FilterNewPhenomenons()
        {
            foreach (var ph in NewPhenomens)
            {
                if (IsPhenomenonValuable(ph, out float calculated))
                {
                    if (!PhenomensToReact.ContainsKey(ph))
                    {
                        PhenomensToReact.Add(ph, calculated);
                        Debug.Log($"Interest value {calculated}/{CalculateInterestThreshold()} for phenom {ph}. Interested, added");
                    }
                    else
                    {

                        Debug.Log($"Interest value {calculated}/{CalculateInterestThreshold()} for phenom {ph}. Interested, yet added");
                    }
                }
                else
                    Debug.Log($"Interest value {calculated}/{CalculateInterestThreshold()} for phenom {ph}. Not interested.");
                yield return null;
            }
            NewPhenomens.Clear();
        }

        /// <summary>
        /// ����������� ���������� ������� � ������ �������.
        /// ���������� - ����� �� ����������� �� ��� �������?
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        private bool IsPhenomenonValuable<T>(T ph, out float calculatedImportance) where T : IPhenomenon
        {
            //���������� ���������� �������
            calculatedImportance = CalculateCurrentImportance(ph);
            int interestThreshold = CalculateInterestThreshold();
            if (calculatedImportance > interestThreshold)
                return true;
            return false;
        }

        private int CalculateInterestThreshold()
        {
            var cs = ThisAgent.CharacterSystem;
            var rawExpress = cs.RestraintExpressiveness.RawCharacterValue;
            var rawEmitions = cs.EmotionalInstabilityStability.RawCharacterValue;
            var expressVal = rawExpress > 5 ? rawExpress - 5 : 5 - rawExpress;
            var emotionsVal = rawEmitions > 5 ? rawEmitions - 5 : 5 - rawEmitions;
            var interestThreshold = (cs.Selfcontrol.RawCharacterValue - expressVal + emotionsVal);
            return interestThreshold;
        }

        private IEnumerator ObservationsDelayRoutine()
        {
            yield return new WaitForSeconds(observationPause + Random.Range(0f, observationPause/10f));
        }

        private int PhenonemonComparer((IPhenomenon, float) x, (IPhenomenon, float) y)
        {
            if (x.Item2 > y.Item2)
                return -1;
            if (x.Item2 < y.Item2)
                return 1;
            return 0;
        }
        private int PhenonemonComparer(KeyValuePair<IPhenomenon, float> x, KeyValuePair<IPhenomenon, float> y)
        {
            if (x.Value > y.Value)
                return -1;
            if (x.Value < y.Value)
                return 1;
            return 0;
        }

        internal IEnumerator DecisionsRoutine()
        {
            if (phenomensToReact.Count > 0)
            {
                //�������� �����
                var sorted = phenomensToReact.ToList();
                sorted.Sort(PhenonemonComparer);
                var selected = sorted[0].Key;
                var reaction = EmotionalReactAtPhenomenon(selected);
            }
            yield return new WaitForFixedUpdate();
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
        private IEnumerator ReactAtNewPhenomenons()
        {
            //foreach (var ph in PhenomensToReact)
            //{
            //    ReactAtPhenomenon(ph);
            //}
            //PhenomensToReact.Clear();
                yield return null;
        }

        /// <summary>
        /// ������� �� ������� <paramref name="phenom"/>
        /// </summary>
        /// <param name="phenom"></param>
        private List<TReaction> EmotionalReactAtPhenomenon<TPhenom>(TPhenom phenom) 
            where TPhenom: IPhenomenon
        {
            //��������������� ������� �������� �������������� � ������� ����������.
            //������� �������� ������� ������. ������� ������ �������� ����������� ��������.
            //������ ���� ��������� ���� � ��������
            //var reactions = new List<TReaction>();
            //foreach (var charTrait in thisAgent.CharacterSystem)
            //{
                var type = ThisAgent.GetType();
                var interfaces = type.GetInterfaces();
                var correctIface = typeof(ICanReactOnPhenomenon<TPhenom, TReaction>);
                foreach (var iface in interfaces)
                {
                    if (iface.IsEquivalentTo(correctIface))
                    {
                        var method = iface.GetMethod("HasReactionOn");
                        object[] parameters = new object[] { phenom, null }; 
                        bool result = (bool)method.Invoke(ThisAgent, parameters);
                        if (result)
                            return (List<TReaction>)parameters[1];
                    }
                }
                //if (charTrait.HasReactionOn(phenom, out List<IReaction> reaction))
            //}
            return default;
        }

        public bool ActionSelected { get => actionSelected; set => actionSelected = value; }
    
        public IReaction LastReaction => lastReaction;
        public List<TReaction> TemporaryReactions => temporaryReactions;

        public void AddReaction(TReaction newEmotion)
        {
            TemporaryReactions.Add(newEmotion);
            lastReaction = newEmotion;
        }

        /// <summary>
        /// ��������� �������. ����������.
        /// �������, ��������� �������, ������� ���������, ����.
        /// </summary>
        internal IEnumerator ProceedPhenomenons(List<IPhenomenon> observationSources)
        {
            yield return AddNewPhenomenons(observationSources);
            yield return FilterNewPhenomenons();
            yield return ObservationsDelayRoutine();
            DecreasePhenomsValue();
            Debug.Log($"Phenoms to react count {PhenomensToReact.Count}");
        }

        private void DecreasePhenomsValue()
        {
            if (PhenomensToReact.Count > 0)
            {
                var anxietyVal = (10- ThisAgent.CharacterSystem.CalmnessAnxiety.RawCharacterValue) / 50f;
                var lst = PhenomensToReact.ToList();
                for (int i = 0; i < lst.Count; i++)
                {
                    var temp = lst[i];
                    if (temp.Value - anxietyVal <= 0)
                        PhenomensToReact.Remove(temp.Key);
                    else
                        PhenomensToReact[temp.Key] -= anxietyVal;
                }
            }
        }
    }
}