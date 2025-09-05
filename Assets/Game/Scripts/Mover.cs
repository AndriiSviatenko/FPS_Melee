using UnityEngine;

public class Mover : BaseCustomComponent
{
    private CharacterController _controller;
    private float _speed;

    public void Init(CharacterController characterController)
    {
        _controller = characterController;
    }

    public void SetSpeed(float value)
    {
        if (value < 0)
            return;

        _speed = value;
    }

    public void Move(Vector2 input)
    {
        if (IsStop)
            return;

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);
    }
}
