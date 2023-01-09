using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    [CreateAssetMenu(fileName = "Names", menuName = "Data/Names")]
    public class NamesLibrary : ScriptableObject
    {
        [SerializeField] private List<string> femaleFirstnames;
        [SerializeField] private List<string> femaleSecondnames;
        [SerializeField] private List<string> femaleSurenames;
        [SerializeField] private List<string> maleFirstnames;
        [SerializeField] private List<string> maleSecondnames;
        [SerializeField] private List<string> maleSurenames;

        public string GetFullFemaleCombination()
        {
            var f = femaleFirstnames[UnityEngine.Random.Range(0, femaleFirstnames.Count)];
            var s = femaleSecondnames[UnityEngine.Random.Range(0, femaleSecondnames.Count)];
            var t = femaleSurenames[UnityEngine.Random.Range(0, femaleSurenames.Count)];
            return $"{f} {s} {t}";
        }

        public string GetFullMaleCombination()
        {
            var f = maleFirstnames[UnityEngine.Random.Range(0, maleFirstnames.Count)];
            var s = maleSecondnames[UnityEngine.Random.Range(0, maleSecondnames.Count)];
            var t = maleSurenames[UnityEngine.Random.Range(0, maleSurenames.Count)];
            return $"{f} {s} {t}";
        }
    }
}