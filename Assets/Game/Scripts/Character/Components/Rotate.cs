using UnityEngine;

public class Rotate : BaseCustomComponent
{
    private Camera _cam;

    private float _sensitivity;
    private float _minAngle;
    private float _maxAngle;

    private float _xRotation;

    public void Init(Camera camera)
    {
        _cam = camera;
    }
    public void SetSensitivity(float value)
    {
        if (value < 0)
            return;

        _sensitivity = value;
    }
    public void SetMinAngle(float value)
    {
        if (value > _maxAngle || value == _minAngle)
            return;

        _minAngle = value;
    }

    public void SetMaxAngle(float value)
    {
        if (value < _minAngle || value == _maxAngle)
            return;

        _maxAngle = value;
    }

    public void Look(Vector3 input)
    {
        if (IsStop) 
            return;

        float mouseX = input.x;
        float mouseY = input.y;

        _xRotation -= (mouseY * Time.deltaTime * _sensitivity);
        _xRotation = Mathf.Clamp(_xRotation, _minAngle, _maxAngle);

        _cam.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * _sensitivity));
    }
}