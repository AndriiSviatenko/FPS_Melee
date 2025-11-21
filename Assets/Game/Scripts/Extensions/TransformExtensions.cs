using UnityEngine;

public static class TransformExtensions
{
    public static void SetX(this Transform transform, float value)
    {
        var temp = transform.position;
        temp.x = value;
        transform.position = temp;
    }
}
