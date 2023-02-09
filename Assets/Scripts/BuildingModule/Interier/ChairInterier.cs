using BehaviourModel;
using Common;
using Extensions;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace BuildingModule
{
    public class ChairInterier : PlacedInterier, IDependentFromChanges
    {
        [SerializeField] [Range(0f, 2f)] private float chairOffset;
        [SerializeField] private SchoolAgentBase thisAgent;

        private void OnDestroy()
        {
            InterierHandler.Handler.Chairs.Remove(this);
        }

        private Vector3 ReplacePosition(float v)
        {
            var oldPos = transform.localPosition;
            var chairs = ThisInterierPlace.InterierWhere<ChairInterier>();
            if (chairs != null && chairs.Count() == 2)
                v = -chairs.First(x => !x.Equals(this)).transform.localPosition.y;
            return new Vector3(oldPos.x, v, oldPos.z);
        }

        protected override void Awake()
        {
            base.Awake();
            InterierHandler.Handler.Chairs.Add(this);
        }

        public SchoolAgentBase ThisAgent { get => thisAgent; set => thisAgent = value; }

        public override void Initiate(InterierPlaceBase ipb)
        {
            transform.localPosition = ReplacePosition(chairOffset);
        }

        public override bool IsAvailForPlacing(MiddlePlace place)
        {
            var pinc = IsPrincipAvailableForPlacing(place);
            var noTable = place.InterierCount<TableInterier>() == 0;
            var sidesFree = place.LeftMiddlePlace.InterierCount() == 0 && place.RightMiddlePlace.InterierCount() == 0;
            var chairsCount = place.InterierCount<ChairInterier>() < 2;
            var noChairs = place.OppositeMiddlePlace.InterierCount<ChairInterier>() == 0;
            if (pinc && noTable && sidesFree && chairsCount && noChairs)
                return true;
            return false;
        }

        public override bool IsPrincipAvailableForPlacing<T>(T interier)
        {
            if (typeof(T).Equals<MiddlePlace>())
                return true;
            return false;
        }

        public IEnumerator OnLeaveChair()
        {
            collider2d.isTrigger = false;
            thisAgent.Chair = null;
            var body = thisAgent.AgentRigidbody;
            Collider2D[] contacts = new Collider2D[5];
            body.GetContacts(contacts);
            while (contacts.Contains(thisAgent.AgentCollider))
            {
                thisAgent.AgentRigidbody.MovePosition(thisAgent.transform.position + new Vector3(0.05f, 0, 0));
                body.GetContacts(contacts);
                yield return new WaitForFixedUpdate();
            }
            thisAgent.AgentRigidbody.MovePosition(thisAgent.transform.position + new Vector3(0.05f, 0, 0));
            yield return new WaitForFixedUpdate();
            thisAgent = null;
        }

        public override IEnumerator OnTargetReached(SchoolAgentBase moveAgent)
        {
            collider2d.isTrigger = true;
            thisAgent = moveAgent;
            thisAgent.AgentRigidbody.MovePosition(transform.position);
            yield return thisAgent.RotateRoutine(transform.up);
            //thisAgent.AgentRigidbody.SetRotation(transform.rotation.eulerAngles.z);
            thisAgent.Chair = this;
        }

        public void ResetIfConditionsChanged(object param)
        {
            ResetMiddleOppAndSidePlaces((InterierPlaceBase)param);
        }
    }
}