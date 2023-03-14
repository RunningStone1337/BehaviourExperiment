//using BuildingModule;
//using System.Collections;

//namespace BehaviourModel
//{
//    /// <summary>
//    /// Испортить вещь
//    /// </summary>
//    public class PupilMessUpThingPhysicAction : NegativePhysicAction, ICompletedAction
//    {
//        public PupilMessUpThingPhysicAction() : base()
//        {
//        }

//        public override void Initiate(IReactionSource reactSource, IAgent reactionActor)
//        {
//            base.Initiate(reactSource, reactionActor);
//            actionMakingTime = 5f;
//        }

//        public override IEnumerator TryPerformAction()
//        {
//            var cast = ActionActor as PupilAgent;
//            var thingCast = ReactionSource as PlacedInterier;
//            if (cast && thingCast)
//            {
//                cast.MovementTarget = thingCast;
//                var state = cast.SetState<MoveToTargetState<PupilAgent>>();
//                yield return state.StartState();

//                cast.StartActionVisual(this);
//                var state1 = cast.SetState<MessUpThingState>();
//                state1.Initiate(cast, thingCast, actionMakingTime);

//                //cast.StartActionVisual(this);
//                yield return state1.StartState();
//                WasPerformed = true;
//                cast.SetDefaultState();
//            }
//        }
//    }
//}