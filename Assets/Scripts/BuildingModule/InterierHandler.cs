using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class InterierHandler : MonoBehaviour
    {
        private static InterierHandler instance;

        [SerializeField] private List<BoardInterier> boards;
        [SerializeField] private List<ChairInterier> chairs;
        [SerializeField] private List<PlantInterier> plants;
        [SerializeField] private List<TableInterier> tables;
        public List<TableInterier> Tables => tables;
        public List<BoardInterier> Boards => boards;
        public List<ChairInterier> Chairs => chairs;
        public List<PlantInterier> Plants => plants;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                return;
            }
            Destroy(this);
        }

        public static InterierHandler Handler => instance;

    }
}