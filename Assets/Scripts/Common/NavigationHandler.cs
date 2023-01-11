using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public class NavigationHandler : MonoBehaviour
    {
        [SerializeField] private CameraConstraints cameraConstraints;
        [SerializeField] [Range(0.01f, 20f)] private float currendScrollSpeed;
        [SerializeField] [Range(1f, 1000f)] private float currentScrollSensetivity;
        [SerializeField] private bool freezeSwipes;
        [SerializeField] private Camera mainCam;
        private float pressingTimeStart;
        private Coroutine scrollRoutine;
        [SerializeField] [Range(0f, 1f)] private float timeDelay = 0.5f;

        private float GetCamSizeOnZoomConstarints(float scroll) =>
            Mathf.Clamp(mainCam.orthographicSize - scroll * currentScrollSensetivity, cameraConstraints.MinCameraSize, cameraConstraints.MaxCameraSize);

        private IEnumerator MouseScrollRoutine(float scroll)
        {
            var targetSize = GetCamSizeOnZoomConstarints(scroll);
            int sign = targetSize <= mainCam.orthographicSize ? -1 : 1;
            Func<bool> pred;
            if (targetSize >= mainCam.orthographicSize)//камера увеличивается
                pred = () => { return mainCam.orthographicSize < targetSize; };
            else//камера уменьшается
                pred = () => { return mainCam.orthographicSize > targetSize; };
            while (pred.Invoke())
            {
                mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, targetSize, currendScrollSpeed * Time.deltaTime);
                transform.position = GetCamPosOnBoundsConstraints(transform.position);
                yield return null;
            }
            ZoomRoutine = null;
        }

        public Action HoldingMouseLimitReachedEvent;
        public Action HoldingMouseStartedEvent;
        public Action MouseReleasedEvent;

        public Vector3 CameraStartPos { get; private set; }
        public bool FirstTimeInLoop { get; private set; }
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

        public Vector3 GetCamPosOnBoundsConstraints(Vector3 expectedCamPos)
        {
            var posX = expectedCamPos.x;
            var posY = expectedCamPos.y;
            return new Vector3(
                Mathf.Clamp(posX, cameraConstraints.LeftPositionConstraint, cameraConstraints.RightPositionConstraint),
                Mathf.Clamp(posY, cameraConstraints.DownPositionConstraint, cameraConstraints.UpPositionConstraint),
                -100f);
        }
        private void OnDestroy()
        {
            HoldingMouseLimitReachedEvent = null;
            HoldingMouseStartedEvent = null;
            MouseReleasedEvent = null;
        }
        public void MouseScroll(float scroll)
        {
            if (scroll != 0.0f && IsZoomPermissed)
                ZoomRoutine = StartCoroutine(MouseScrollRoutine(scroll));
        }

        public void Swipes()
        {
            if (!FreezeSwipes)
            {
                if (Input.GetMouseButtonDown(0))//если левая нажата ВПЕРВЫЕ
                {
                    //Debug.Log("First click");
                    CameraStartPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
                    PointerStartPos = Input.mousePosition;
                    FirstTimeInLoop = true;
                }
                else if (Input.GetMouseButton(0))//если нажата и удерживается
                {
                    //Debug.Log("Holding");
                    if (FirstTimeInLoop)
                    {
                        pressingTimeStart = Time.time;
                        HoldingMouseStartedEvent?.Invoke();
                        FirstTimeInLoop = false;
                    }
                    if (Time.time - pressingTimeStart >= timeDelay)
                    {
                        //Debug.Log("Limit reached");
                        HoldingMouseLimitReachedEvent?.Invoke();
                    }
                    var mPos = Input.mousePosition;
                    var posX = mainCam.ScreenToWorldPoint(mPos).x - CameraStartPos.x;
                    var posY = mainCam.ScreenToWorldPoint(mPos).y - CameraStartPos.y;
                    transform.position = new Vector3(
                        Mathf.Clamp(transform.position.x - posX, cameraConstraints.LeftPositionConstraint, cameraConstraints.RightPositionConstraint),
                        Mathf.Clamp(transform.position.y - posY, cameraConstraints.DownPositionConstraint, cameraConstraints.UpPositionConstraint),
                        -100f);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    pressingTimeStart = 0f;
                    MouseReleasedEvent?.Invoke();
                    //Debug.Log("Release");
                }
            }
        }
    }
}