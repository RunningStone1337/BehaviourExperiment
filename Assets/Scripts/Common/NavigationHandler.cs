using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public class NavigationHandler : MonoBehaviour
    {
        #region Public Events

        public event Action<float> OnCameraSizeChangedEvent;

        public event Action OnCameraSwipeEndEvent;

        public event Action OnCameraSwipeStartEvent;

        #endregion Public Events

        #region Public Properties

        public Vector3 CameraStartPos { get; private set; }
        public bool FreezeSwipes { get => freezeSwipes; set => freezeSwipes = value; }
        public bool IsZoomPermissed { get; internal set; } = true;
        public Vector3 PointerStartPos { get; private set; }
        public Coroutine ZoomRoutine
        {
            get => scrollRoutine; private set
            {
                if (scrollRoutine != null)
                    StopCoroutine(scrollRoutine);
                scrollRoutine = value;
            }
        }

        public bool FirstTimeInLoop { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public Vector3 GetCamPosOnBoundsConstraints(Vector3 expectedCamPos)
        {
            var posX = expectedCamPos.x;
            var posY = expectedCamPos.y;
            return new Vector3(
                Mathf.Clamp(posX, cameraConstraints.LeftPositionConstraint, cameraConstraints.RightPositionConstraint),
                Mathf.Clamp(posY, cameraConstraints.DownPositionConstraint, cameraConstraints.UpPositionConstraint),
                -100f);
        }

        #endregion Public Methods

        #region Private Fields

        [SerializeField] private CameraConstraints cameraConstraints;
        [SerializeField] [Range(0.01f, 20f)] private float currendScrollSpeed;
        [SerializeField] [Range(1f, 1000f)] private float currentScrollSensetivity;
        [SerializeField] private bool freezeSwipes;
        [SerializeField] private Camera mainCam;
        private Coroutine scrollRoutine;

        #endregion Private Fields

        #region Private Methods

        private float GetCamSizeOnZoomConstarints(float scroll)=>
            Mathf.Clamp(mainCam.orthographicSize - scroll * currentScrollSensetivity, cameraConstraints.MinCameraSize, cameraConstraints.MaxCameraSize);
        

        public void MouseScroll(float scroll)
        {
            if (scroll != 0.0f && IsZoomPermissed)
                ZoomRoutine = StartCoroutine(MouseScrollRoutine(scroll));
        }

        private IEnumerator MouseScrollRoutine(float scroll)
        {
            var targetSize = GetCamSizeOnZoomConstarints(scroll);
            int sign = targetSize <= mainCam.orthographicSize ? -1 : 1;
            Func<bool> pred;
            if (targetSize >= mainCam.orthographicSize)//камера увеличиваетс€
                pred = () => { return mainCam.orthographicSize < targetSize; };
            else//камера уменьшаетс€
                pred = () => { return mainCam.orthographicSize > targetSize; };
            while (pred.Invoke())
            {
                mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, targetSize, currendScrollSpeed * Time.deltaTime);
                transform.position = GetCamPosOnBoundsConstraints(transform.position);
                OnCameraSizeChangedEvent?.Invoke(mainCam.orthographicSize);
                yield return null;
            }
            ZoomRoutine = null;
        }

        public void Swipes()
        {
            if (!FreezeSwipes)
            {
                if (Input.GetMouseButtonDown(0))//если лева€ нажата ¬ѕ≈–¬џ≈ 
                {
                    CameraStartPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
                    PointerStartPos = Input.mousePosition;
                    FirstTimeInLoop = true;
                }
                else if (Input.GetMouseButton(0))//если нажата и удерживаетс€
                {
                    if (FirstTimeInLoop)
                    {
                        OnCameraSwipeStartEvent?.Invoke();
                        FirstTimeInLoop = false;
                        //Debug.Log("Start");
                    }

                    var mPos = Input.mousePosition;
                    var posX = mainCam.ScreenToWorldPoint(mPos).x - CameraStartPos.x;
                    var posY = mainCam.ScreenToWorldPoint(mPos).y - CameraStartPos.y;
                    transform.position = new Vector3(
                        Mathf.Clamp(transform.position.x - posX, cameraConstraints.LeftPositionConstraint, cameraConstraints.RightPositionConstraint),
                        Mathf.Clamp(transform.position.y - posY, cameraConstraints.DownPositionConstraint, cameraConstraints.UpPositionConstraint),
                        -100f);
                    //if (Mathf.Abs(PointerStartPos.x - transform.position.x) > 1f || Mathf.Abs(PointerStartPos.y - transform.position.y) > 1f)
                    //{//если свайп сильнее 1
                    //    Debug.Log(Mathf.Abs(PointerStartPos.x - transform.position.x));
                    //}
                    //else
                    //{
                    //}
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    OnCameraSwipeEndEvent?.Invoke();
                    //Debug.Log("End");
                }
            }
        }

        //private void Update()
        //{
        //    /// «ум камеры мышью
        //    float scroll = Input.GetAxis("Mouse ScrollWheel");
        //    MouseScroll(scroll);
        //    /// «ум камеры на телефоне с помощью тачей
        //    //TouchScroll(scroll);
        //    Swipes();
        //}

        #endregion Private Methods
    }
}