using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public class WorkDaysSelector : MonoBehaviour
    {
        [SerializeField] DayInfo monday;
        [SerializeField] DayInfo tuesday;
        [SerializeField] DayInfo wednesday;
        [SerializeField] DayInfo thursday;
        [SerializeField] DayInfo friday;
        [SerializeField] DayInfo saturday;
        [SerializeField] DayInfo sunday;
        [SerializeField] DayInfo[] week;
    }
}