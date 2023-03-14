using Core;
using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public sealed class TeacherAgent : SchoolAgentBase<TeacherAgent>
    {
        [SerializeField] BehaviourPatternBase pattern;

        public override GlobalEvent CurrentEvent => ((SchoolObservationsSystem<TeacherAgent>)ObservationsSystem).EventsSensor.CurrentEvent;

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

       

        //public override IEnumerator AnswerToReqestRoutine<TSpeaker>(TSpeaker speaker, IPhenomenon targetAction)
        //{
        //    SetState<TeacherAnsweringToRequestState<TSpeaker>>();
        //    ((TeacherAnsweringToRequestState<TSpeaker>)CurrentState).Initiate(this, speaker, targetAction);
        //    yield return currentState.StartState();
        //}



        public override void SetDefaultState()
        {
            SetState<IdleTeacherState>();
        }
    }
}