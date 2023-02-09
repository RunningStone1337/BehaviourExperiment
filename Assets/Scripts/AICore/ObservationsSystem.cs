using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class ObservationsSystem<TReaction, TFeature, TState> : SystemBase<TReaction, TFeature, TState>,
       IPhenomenonsCreator
        where TReaction: IReaction
        where TFeature : IFeature where TState : IState
    {
        [SerializeField] List<Sensor> sensors;
        public List<Sensor> Sensors => sensors;

        public List<IPhenomenon> CreatePhenomenons()
        {
            List<IPhenomenon> res = new List<IPhenomenon>();
            foreach (var s in sensors)
            {
                res.AddRange(s.CreatePhenomenons());
            }
            return res;
        }
    }
}