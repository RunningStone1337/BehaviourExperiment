using BuildingModule;
using Common;
using UnityEngine;

namespace BehaviourModel
{
    public class AgentEnvironment : MonoBehaviour, ICurrentRoomHandler
    {
        [SerializeField] ChairInterier bindedChair;
        [SerializeField] private Room currentRoom;
        [SerializeField] private ChairInfo seatChair;
        [SerializeField] private TableInfo pupilTable;
        public ChairInterier BindedChair { get => bindedChair; set => bindedChair = value; }
        public ChairInfo ChairInfo { get => seatChair; set => seatChair = value; }
        public TableInfo TableInfo { get => pupilTable; set => pupilTable = value; }
        public Room CurrentRoom { get => currentRoom; set => currentRoom = value; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Entrance ent))
            {
                CurrentRoom = ent.CurrentRoom;
            }
        }
    }
}