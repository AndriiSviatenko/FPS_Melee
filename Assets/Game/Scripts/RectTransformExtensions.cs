using UnityEngine;

public static class RectTransformExtensions
{
    public static void ChangeSize(this RectTransform rectTransform, float width, float height)
    {
        var size = rectTransform.sizeDelta;
        size.x = width;
        size.y = height;
        rectTransform.sizeDelta = size;
    }
    public static void ChangeRotation(this RectTransform rectTransform, Quaternion value)
    {
        rectTransform.rotation = value;
    }
}