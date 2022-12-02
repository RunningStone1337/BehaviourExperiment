using UnityEngine;

namespace Common
{
    public class SceneDataStorage : MonoBehaviour
    {
        #region Public Properties

        public static SceneDataStorage Storage { get => storageInstance; private set => storageInstance = value; }
        //public Sprite DownLeftRoom { get => downLeftRoom; }
        //public Sprite DownRightRoom { get => downRightRoom; }
        //public Sprite DownRoom { get => downRoom; }
        public GameObject EntrancePrefab { get => entrancePrefab; }
        public GameObject LeftWallPrefab { get => leftWallPrefab; }
        public GameObject RightWallPrefab { get => rightWallPrefab; }
        public GameObject UpWallPrefab { get => upWallPrefab; }
        public GameObject DownWallPrefab { get => downWallPrefab; }
        //public Sprite Floor { get => floor; }
        //public Sprite LeftRightDownRoom { get => leftRightDownRoom; }
        //public Sprite LeftRightRoom { get => leftRightRoom; }
        //public Sprite LeftRightUpRoom { get => leftRightUpRoom; }
        //public Sprite LeftRoom { get => leftRoom; }
        //public Sprite RightRoom { get => rightRoom; }
        //public Sprite UpDownLeftRoom { get => upDownLeftRoom; }
        //public Sprite UpDownRightRoom { get => upDownRightRoom; }
        //public Sprite UpDownRoom { get => upDownRoom; }
        //public Sprite UpLeftRoom { get => upLeftRoom; }
        //public Sprite UpRightRoom { get => upRightRoom; }
        //public Sprite UpRoom { get => upRoom; }

        #endregion Public Properties

        #region Private Fields

        private static SceneDataStorage storageInstance;
        [SerializeField] private GameObject entrancePrefab;
        [SerializeField] private GameObject leftWallPrefab;
        [SerializeField] private GameObject rightWallPrefab;
        [SerializeField] private GameObject upWallPrefab;
        [SerializeField] private GameObject downWallPrefab;
        //[SerializeField] private Sprite downLeftRoom;
        //[SerializeField] private Sprite downRightRoom;
        //[SerializeField] private Sprite downRoom;
        //[SerializeField] private Sprite floor;
        //[SerializeField] private Sprite leftRightDownRoom;
        //[SerializeField] private Sprite leftRightRoom;
        //[SerializeField] private Sprite leftRightUpRoom;
        //[SerializeField] private Sprite leftRoom;
        //[SerializeField] private Sprite rightRoom;
        //[SerializeField] private Sprite upDownLeftRoom;
        //[SerializeField] private Sprite upDownRightRoom;
        //[SerializeField] private Sprite upDownRoom;
        //[SerializeField] private Sprite upLeftRoom;
        //[SerializeField] private Sprite upRightRoom;
        //[SerializeField] private Sprite upRoom;

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