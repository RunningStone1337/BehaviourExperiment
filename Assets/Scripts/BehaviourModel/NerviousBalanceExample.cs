using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [CreateAssetMenu(fileName ="NerviousBalance", menuName = "BehaviourModel/NerviousBalance")]
    public class NerviousBalanceExample : ScriptableObject
    {
        [SerializeField] int[] nervousBalance = new int[9];
        /// <summary>
        /// —ила реакции на раздражитель силы i, где i = индекс. —ила реакции на силу 2 = NervousReaction[i-1].
        /// «десь же определ€ютс€ подпороговые, пороговые, надпороговые, максимальные и сверхмаксимальные значени€.
        /// </summary>
        public int[] NervousReaction { get => nervousBalance; }
    }
}