using UnityEngine;

public static class Vector3Extensions
{
    public static float SignedAngleFromDirection(this Vector3 fromdir, Vector3 todir, Vector3 referenceup)
    {// calculates the the angle between two direction vectors, with a referenceup a sign in which direction it points can be calculated (clockwise is positive and counter clockwise is negative)
        Vector3 planenormal = Vector3.Cross(fromdir, todir);             // calculate the planenormal (perpendicular vector)
        float angle = Vector3.Angle(fromdir, todir);                     // calculate the angle between the 2 direction vectors (note: its always the smaller one smaller than 180°)
        float orientationdot = Vector3.Dot(planenormal, referenceup);    // calculate wether the normal and the referenceup point in the same direction (>0) or not (<0), http://docs.unity3d.com/Documentation/Manual/ComputingNormalPerpendicularVector.html
        if (orientationdot > 0.0f)                                         // the angle is positive (clockwise orientation seen from referenceup)
            return angle;
        return -angle;  // the angle is negative (counter-clockwise orientation seen from referenceup)
    }

    public static float SignedAngleFromPosition(this Vector3 referencepoint, Vector3 frompoint, Vector3 topoint, Vector3 referenceup)
    {// calculates the the angle between two position vectors regarding to a reference point (plane), with a referenceup a sign in which direction it points can be calculated (clockwise is positive and counter clockwise is negative)
        Vector3 fromdir = frompoint - referencepoint;                       // calculate the directionvector pointing from refpoint towards frompoint
        Vector3 todir = topoint - referencepoint;                           // calculate the directionvector pointing from refpoint towards topoint
        Vector3 planenormal = Vector3.Cross(fromdir, todir);               // calculate the planenormal (perpendicular vector)
        float angle = Vector3.Angle(fromdir, todir);                       // calculate the angle between the 2 direction vectors (note: its always the smaller one smaller than 180°)
        float orientationdot = Vector3.Dot(planenormal, referenceup);   // calculate wether the normal and the referenceup point in the same direction (>0) or not (<0), http://docs.unity3d.com/Documentation/Manual/ComputingNormalPerpendicularVector.html
        if (orientationdot > 0.0f)                                           // the angle is positive (clockwise orientation seen from referenceup)
            return angle;
        return -angle;   // the angle is negative (counter-clockwise orientation seen from referenceup)
    }
}