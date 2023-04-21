using UnityEngine;

namespace BuildingModule
{
    public class ChairMovePoint : MovePoint
    {
       
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ChairInterier chair))
                IsOccuped = true;
        }
       
        protected override void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out ChairInterier chair))
                IsOccuped = false;
        }
    }
}