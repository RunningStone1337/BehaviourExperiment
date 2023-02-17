using System;
using System.Collections;
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
            var x = divX == 0 ? template.Width / 2 : template.Width / 2 - 1;
            var y = divY == 0 ? template.Height / 2  : template.Height / 2 - 1;
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
                StartCoroutine(TemplateBuildRoutine(config));
            }
        }

        private IEnumerator TemplateBuildRoutine(EntranceTemplateConfig config)
        {
            var dict = EntranceRoot.Root.PlacesDict;
            var entrancesTemplate = config.EntrancePlacingTemplate;
            var startCoords = GetStartCoords(entrancesTemplate);
            yield return ApplyTemplate(entrancesTemplate, startCoords, dict, (x) => { x.TryPlaceNewEntrance(null); });
            //исправить стены
            //разделить помещения
            //назначить новые роли
            foreach (var pair in config.EntrancesRolesTemplates)
            {
                //ApplyTemplate(pair.Item1, startCoords, dict, (x)=> { x.Entrance.ForceSetRoo; });
            }
        }

        private IEnumerator ApplyTemplate(MatrixTemplate template, Vector2Int startCoords, Dictionary<Vector2Int, BuildingPlace> source,Action<BuildingPlace> action)
        {
            Vector2Int tempCoords = startCoords;
            BuildingPlace tempPlace;
            for (int y = 0; y < template.Height; y++)
            {
                for (int x = 0; x < template.Width; x++)
                {
                    if (template[y, x])
                    {
                        tempPlace = source[tempCoords];
                        action.Invoke(tempPlace);
                    }
                    tempCoords = startCoords + new Vector2Int(xStep * (x+1), yStep * y);
                }
                tempCoords = startCoords + new Vector2Int(0, yStep * (y+1));
                yield return null;
            }
        }
    }
}