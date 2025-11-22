using UnityEngine;

public class SliderContainer : MonoBehaviour
{
    [field: SerializeField] public SliderView View;
    [field: SerializeField] public FollowTo FollowTo;
    [field: SerializeField] public LookTo LookTo;

    public RectTransform ViewRect =>
        View.GetComponent<RectTransform>();

    public RectTransform Rect =>
        GetComponent<RectTransform>();
}
