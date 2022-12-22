using UnityEngine;

namespace Common
{
    public class SceneDataStorage : MonoBehaviour
    {
        #region Public Properties

        public static SceneDataStorage Storage { get => storageInstance; private set => storageInstance = value; }
    
        public GameObject EntrancePrefab { get => entrancePrefab; }
        public GameObject LeftWallPrefab { get => leftWallPrefab; }
        public GameObject RightWallPrefab { get => rightWallPrefab; }
        public GameObject UpWallPrefab { get => upWallPrefab; }
        public GameObject DownWallPrefab { get => downWallPrefab; }
        public GameObject PlaceableUIViewPefab { get => placeableUIViewPefab; }
        public GameObject AgentCardPrafab { get => agentCardPrafab; }
       

        #endregion Public Properties

        #region Private Fields

        private static SceneDataStorage storageInstance;
        [SerializeField] private GameObject entrancePrefab;
        [SerializeField] private GameObject leftWallPrefab;
        [SerializeField] private GameObject rightWallPrefab;
        [SerializeField] private GameObject upWallPrefab;
        [SerializeField] private GameObject downWallPrefab;
        [SerializeField] private GameObject placeableUIViewPefab;
        [SerializeField] private GameObject agentCardPrafab;

        #endregion Private Fields

        #region Private Methods

        private void Awake()
        {
            if (Storage == null)
            {
                Storage = this;
                return;
            }
            Destroy(this);
        }

        #endregion Private Methods
    }
}