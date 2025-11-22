using UnityEngine;

public static class TransformExtensions
{
    public static void SetX(this Transform transform, float value)
    {
        var temp = transform.position;
        temp.x = value;
        transform.position = temp;
    }

    public static void SetPos(this Transform transform, Vector3 value)
    {
        transform.position = value;
    }
    public static void SetRotate(this Transform transform, Quaternion value)
    {
        transform.rotation = value;
    }
}