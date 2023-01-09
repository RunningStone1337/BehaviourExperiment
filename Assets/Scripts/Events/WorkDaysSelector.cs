using UnityEngine;

namespace Events
{
    public class WorkDaysSelector : MonoBehaviour
    {
        [SerializeField] private DayInfo friday;
        [SerializeField] private DayInfo monday;
        [SerializeField] private DayInfo saturday;
        [SerializeField] private DayInfo sunday;
        [SerializeField] private DayInfo thursday;
        [SerializeField] private DayInfo tuesday;
        [SerializeField] private DayInfo wednesday;
        [SerializeField] private DayInfo[] week;
    }
}