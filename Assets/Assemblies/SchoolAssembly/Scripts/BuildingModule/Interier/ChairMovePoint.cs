using UnityEngine;

namespace BuildingModule
{
    public class ChairMovePoint : MovePoint
    {
        //private void Start()
        //{
        //    var colliders = new Collider2D[10];
        //    var contacts = placeCollider.GetContacts(colliders);
        //    for (int i = 0; i < contacts; i++)
        //    {
        //        if (colliders[i].TryGetComponent(out ChairInterier ch))
        //        {
        //            isOccuped = true;
        //            break;
        //        }
        //    }
        //}
       
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ChairInterier chair))
            {
                IsOccuped = true;
                //Debug.Log("Chair trigger enter");
            }
        }

        //private void OnTriggerStay2D(Collider2D collision)
        //{
        //    if (collision.TryGetComponent(out ChairInterier chair))
        //    {
        //        Debug.Log("Chair collision stay");

        //    }
        //    else
        //    {
        //        Debug.Log("Other collision stay");

        //    }
        //}

        protected override void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ChairInterier chair))
            {
                IsOccuped = false;
                //Debug.Log("Chair trigger exit");
            }
        }
    }
}