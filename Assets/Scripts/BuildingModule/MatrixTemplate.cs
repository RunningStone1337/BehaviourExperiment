using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    [CreateAssetMenu(menuName = "BuildingTemplates/Template", fileName = "Template")]
    public class MatrixTemplate : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private List<bool[]> placesMatrix;
        [SerializeField] [HideInInspector] private List<bool> serializationList;
        [SerializeField] [HideInInspector] private int xSerialize;
        [SerializeField] [HideInInspector] private int ySerialize;
        public int Height => placesMatrix.Count;
        public List<bool[]> PlacesMatrix { get => placesMatrix; set => placesMatrix = value; }
        public int Width => placesMatrix.Count > 0 ? placesMatrix[0].Length : 0;
        public bool this[int y, int x]
        {
            get => PlacesMatrix[y][x];
            set => PlacesMatrix[y][x] = value;
        }

        public void OnAfterDeserialize()
        {
            PlacesMatrix = new List<bool[]>();
            for (int i = 0; i < ySerialize; i++)
            {
                var row = new bool[xSerialize];
                PlacesMatrix.Add(row);
            }
            int c = 0;
            for (int y = 0; y < ySerialize; y++)
            {
                for (int x = 0; x < xSerialize; x++)
                {
                    PlacesMatrix[y][x] = serializationList[c];
                    c++;
                }
            }
            serializationList = null;
        }

        public void OnBeforeSerialize()
        {
            serializationList = new List<bool>();
            ySerialize = placesMatrix != null? placesMatrix.Count : 0;
            if (placesMatrix != null)
                xSerialize = placesMatrix.Count > 0 ? placesMatrix[0].Length : 0;
            else
                xSerialize = 0;
            for (int i = 0; i < ySerialize; i++)
                serializationList.AddRange(placesMatrix[i]);
        }
    }
}