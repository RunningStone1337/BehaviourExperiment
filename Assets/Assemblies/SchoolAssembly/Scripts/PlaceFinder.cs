using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public class PlaceFinder
    {
        int counter;
        //private List<Room> placingRooms;
        Vector3 startPoint;
        Vector3 tempPoint;
        float overlapRadius;
        float spawnRadius;
        ContactFilter2D filter;
        List<Collider2D> results;
        Func<Vector3> resetStartPointFunc;
        public Vector3 Place { get; private set; }
        public PlaceFinder(Func<Vector3> startPointSearchFunc, float overlapRad, float searchingRad, ContactFilter2D placeContactFilter)
        {
            counter = 0;
            resetStartPointFunc = startPointSearchFunc;
        
            
            startPoint = resetStartPointFunc.Invoke();
            tempPoint = startPoint;
            overlapRadius = overlapRad;
            filter = placeContactFilter;
            spawnRadius = searchingRad;
            results = new List<Collider2D>();
        }

        public PlaceFinder(Func<Vector3> startPointSearchFunc, AgentsPlacerParams placerParams)
        {
            counter = 0;
            resetStartPointFunc = startPointSearchFunc;
            //placingRooms = EntranceRoot.Root.Rooms.Where(x => x.Role is ExitRole).ToList();
            startPoint = resetStartPointFunc.Invoke(); /*placingRooms.GetRandom().RandomEntrance().transform.position;*/
            tempPoint = startPoint;
            overlapRadius = placerParams.OverlapRadius;
            filter = placerParams.Filter;
            spawnRadius = placerParams.SearchRadius;
            results = new List<Collider2D>();
        }

        public bool TryFindPlace()
        {
            if (counter == 10)
            {
                counter = 0;
                startPoint = resetStartPointFunc.Invoke(); /*placingRooms.GetRandom().RandomEntrance().transform.position;*/
            }
            //есть пересечения
            if (Physics2D.OverlapCircle(tempPoint, overlapRadius, filter, results) > 0)
            {
                tempPoint = startPoint + (Vector3)(UnityEngine.Random.insideUnitCircle * spawnRadius);
                counter++;
                return false;
            }
            Place = tempPoint;
            counter = 0;
            tempPoint = startPoint;
            return true;
        }
    }
}
