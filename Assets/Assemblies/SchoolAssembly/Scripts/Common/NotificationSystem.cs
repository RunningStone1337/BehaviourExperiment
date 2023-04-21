using UI;
using UnityEngine;

namespace Common
{
    public class NotificationSystem : MonoBehaviour
    {
        [SerializeField] NotificationScreen screen;
        private static NotificationSystem notificationSystem;

        public static NotificationSystem NotifyMaster => notificationSystem;


        void Awake()
        {
            if (notificationSystem == null)
            {
                notificationSystem = this;
                return;
            }
            Destroy(this);
        }

        public void SendNotification(string message)
        {
            screen.InitiateState(message);
        }
    }
}