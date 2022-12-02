using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraConstraints : MonoBehaviour
{
    [SerializeField] float leftPositionConstraint;
    [SerializeField] float rightPositionConstraint;
    [SerializeField] float upPositionConstraint;
    [SerializeField] float downPositionConstraint;
    [SerializeField] float maxCameraSize;
    [SerializeField] float minCameraSize;
    
    public float LeftPositionConstraint { get => leftPositionConstraint; }
    public float RightPositionConstraint { get => rightPositionConstraint; }
    public float UpPositionConstraint { get => upPositionConstraint; }
    public float DownPositionConstraint { get => downPositionConstraint; }
    public float MaxCameraSize { get => maxCameraSize; }
    public float MinCameraSize { get => minCameraSize; }

}
