using UnityEngine;

public class Gravity :  BaseCustomComponent
{
    private CharacterController _controller;
    private float _minVelocityY = -2f;
    private float _gravity;

    public void Init(CharacterController controller)
    {
        _controller = controller;
    }

    public void SetMinVelocityY(float value)
    {
        _minVelocityY = value;
    }

    public void SetGravity(float value)
    {
        _gravity = value;
    }

    public Vector3 Apply(Vector3 value)
    {
        if (IsStop) 
            return Vector3.zero;

        value.y += _gravity * Time.deltaTime;
        if (_controller.isGrounded && value.y < 0)
            value.y = _minVelocityY;
        _controller.Move(value * Time.deltaTime);
        return value;
    }
}
