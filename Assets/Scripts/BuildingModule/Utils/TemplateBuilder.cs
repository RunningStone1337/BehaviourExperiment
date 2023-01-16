using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BuildingModule
{
    public class TemplateBuilder : MonoBehaviour
    {
        private static TemplateBuilder instance;
        [SerializeField] private BuildingPlace centralPoint;
        [SerializeField] private int xStep;
        [SerializeField] private int yStep;
        [SerializeField] private List<EntranceTemplateConfig> entranceTemplates;

        private void Awake()
        {
            if (Instance == null)
            {
                instance = this;
                return;
            }
            Destroy(this);
        }

        private Vector2Int GetStartCoords(MatrixTemplate template)
        {
            var divX = template.Width % 2;
            var divY = template.Height % 2;
            var x = divX == 0 ? template.Width / 2 - 1 : template.Width / 2;
            var y = divY == 0 ? template.Height / 2 - 1 : template.Height / 2;
            var dict = EntranceRoot.Root.PlacesDict;
            var res = CentralPoint.Coordinates - new Vector2Int(x * XStep, y * YStep);
            bool xFlag = true;
            while (!dict.ContainsKey(res))
            {
                if (xFlag)
                    res += new Vector2Int(xStep, 0);
                else
                    res += new Vector2Int(0, yStep);
                xFlag = !xFlag;
            }
            return res;
        }

        public static TemplateBuilder Instance => instance;
        public BuildingPlace CentralPoint { get => centralPoint; set => centralPoint = value; }
        public int XStep { get => xStep; set => xStep = value; }
        public int YStep { get => yStep; set => yStep = value; }
        public List<EntranceTemplateConfig> EntranceTemplates { get=> entranceTemplates; set=> entranceTemplates = value; }

        public void BuildRandomTemplate()
        {
            var config = EntranceTemplates[Random.Range(0, EntranceTemplates.Count)];
            if (config)
            {
                var template = config.EntrancePlacingTemplate;
                var startCoords = GetStartCoords(template);
                var dict = EntranceRoot.Root.PlacesDict;
                
                Vector2Int tempCoords = startCoords;
                BuildingPlace tempPlace;
                for (int y = 0; y < template.Height; y++)
                {
                    for (int x = 0; x < template.Width; x++)
                    {
                        if (template[y, x])
                        {
                            tempPlace = dict[tempCoords];
                            tempPlace.TryPlaceNewEntrance(null);
                        }
                        tempCoords = startCoords + new Vector2Int(xStep * x, yStep * y);
                    }
                }
            }
        }
    }
}