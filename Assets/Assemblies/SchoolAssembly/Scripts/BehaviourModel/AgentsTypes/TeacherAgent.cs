using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public sealed class TeacherAgent : SchoolAgentBase<TeacherAgent>
    {
        [SerializeField] BehaviourPatternBase pattern;

        public override List<IReaction> GetReactionsOnPhenomenon()
        {
            throw new System.NotImplementedException();
        }
        #region tables


        #endregion tables
        public override void Initiate<TLowAnx, TMidAnx, THighAnx,
            TLowSoc, TMidSoc, THighSoc,
            TLowStab, TMidStab, THighStab,
            TLowNonc, TMidNonc, THighNonc,
            TLowNorm, TMidNorm, THighNorm,
            TLowRad, TMidRad, THighRad,
            TLowSelf, TMidSelf, THighSelf,
            TLowSens, TMidSens, THighSens,
            TLowSusp, TMidSusp, THighSusp,
            TLowTens, TMidTens, THighTens,
            TLowExpre, TMidExpre, THighExpre,
            TLowInt, TMidInt, THighInt,
            TLowDrea, TMidDrea, THighDrea,
            TLowDom, TMidDom, THighDom,
            TLowDipl, TMidDipl, THighDipl,
            TLowCour, TMidCour, THighCour>(HumanRawData hum)

        {
            base.Initiate<TLowAnx, TMidAnx, THighAnx,
            TLowSoc, TMidSoc, THighSoc,
            TLowStab, TMidStab, THighStab,
            TLowNonc, TMidNonc, THighNonc,
            TLowNorm, TMidNorm, THighNorm,
            TLowRad, TMidRad, THighRad,
            TLowSelf, TMidSelf, THighSelf,
            TLowSens, TMidSens, THighSens,
            TLowSusp, TMidSusp, THighSusp,
            TLowTens, TMidTens, THighTens,
            TLowExpre, TMidExpre, THighExpre,
            TLowInt, TMidInt, THighInt,
            TLowDrea, TMidDrea, THighDrea,
            TLowDom, TMidDom, THighDom,
            TLowDipl, TMidDipl, THighDipl,
            TLowCour, TMidCour, THighCour>(hum);
            var data = (TeacherRawData)hum;
            pattern = data.behModel;
        }

        internal override void OnGlobalEventChangedCallback(ExperimentProcessHandler.CurrentEventChangedEventArgs args)
        {
            throw new System.NotImplementedException();
        }
    }
}