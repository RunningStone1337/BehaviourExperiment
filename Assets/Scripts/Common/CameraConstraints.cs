using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraConstraints : MonoBehaviour
{
    [SerializeField] private float downPositionConstraint;
    [SerializeField] private float leftPositionConstraint;
    [SerializeField] private float maxCameraSize;
    [SerializeField] private float minCameraSize;
    [SerializeField] private float rightPositionConstraint;
    [SerializeField] private float upPositionConstraint;
    public float DownPositionConstraint { get => downPositionConstraint; }
    public float LeftPositionConstraint { get => leftPositionConstraint; }
    public float MaxCameraSize { get => maxCameraSize; }
    public float MinCameraSize { get => minCameraSize; }
    public float RightPositionConstraint { get => rightPositionConstraint; }
    public float UpPositionConstraint { get => upPositionConstraint; }
}