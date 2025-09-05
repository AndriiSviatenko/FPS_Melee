using UnityEngine;

public class Jumper : BaseCustomComponent
{
    public Vector3 Jump(bool isGrounded, Vector3 value, float height, float gravity)
    {
        if (isGrounded)
            value.y = Mathf.Sqrt(height * -3.0f * gravity);
        return value;
    }
}