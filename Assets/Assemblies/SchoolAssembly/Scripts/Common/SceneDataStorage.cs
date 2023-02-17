using UnityEngine;

namespace Common
{
    public class SceneDataStorage : MonoBehaviour
    {
        #region Public Properties

        public static SceneDataStorage Storage { get => storageInstance; private set => storageInstance = value; }

        public GameObject AgentCardPrafab { get => agentCardPrafab; }
        public GameObject AgentDataSaveLoadViewPrafab { get => agentDataSaveLoadViewPrafab; }
        public GameObject DownWallPrefab { get => downWallPrefab; }
        public GameObject EntrancePrefab { get => entrancePrefab; }
        public GameObject LeftWallPrefab { get => leftWallPrefab; }
        public GameObject PlaceableUIViewPefab { get => placeableUIViewPefab; }
        public GameObject RightWallPrefab { get => rightWallPrefab; }
        public GameObject UpWallPrefab { get => upWallPrefab; }

        #endregion Public Properties

        #region Private Fields

        private static SceneDataStorage storageInstance;
        [SerializeField] private GameObject agentCardPrafab;
        [SerializeField] private GameObject agentDataSaveLoadViewPrafab;
        [SerializeField] private GameObject downWallPrefab;
        [SerializeField] private GameObject entrancePrefab;
        [SerializeField] private GameObject leftWallPrefab;
        [SerializeField] private GameObject placeableUIViewPefab;
        [SerializeField] private GameObject rightWallPrefab;
        [SerializeField] private GameObject upWallPrefab;

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