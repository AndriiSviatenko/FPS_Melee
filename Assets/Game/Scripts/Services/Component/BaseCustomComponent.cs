using UnityEngine;

public class BaseCustomComponent : MonoBehaviour, ICustomComponent
{
    public bool IsStop { get; private set; }

    public virtual void StartComponent()
    {
        IsStop = false;
    }

    public virtual void StopComponent()
    {
        IsStop = true;
    }
}
