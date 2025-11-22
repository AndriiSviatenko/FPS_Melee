using UnityEngine;

public class SliderHelper : IService
{
    public void SetupCorrectSide(Vector3 vector, SliderContainer slider)
    {
        slider.ViewRect.ChangeRotation(Quaternion.Euler(vector));
    }

    public void ChangeSize(float width, float height, SliderContainer slider)
    {
        slider.Rect.ChangeSize(width, height);
    }

    public void SetFollow(Transform target, SliderContainer slider)
    {
        slider.FollowTo.SetTarget(target);
    }
    public void SetLook(Transform target, SliderContainer slider)
    {
        slider.LookTo.SetTarget(target);
    }
}
