using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private const float ANGLE_APPROX = -0.01f;
    private const float VERT_MOVEMENT = -0.02f;

    [SerializeField]
    private Transform[] _starts;
    [SerializeField]
    private Transform[] _targets;

    private Vector3 _target;
    private bool _isMoving = false;
    private Vector3? _lastMousePosition = null;
    private int _currentStack;

    public void Focus(int index)
    {
        _currentStack = index;
        Camera.main.transform.position = _starts[index].position;
        _target = _targets[index].position;
        LookAtTarget();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isMoving = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            _isMoving = false;
            _lastMousePosition = null;
        }

        if (_isMoving)
        {
            if (_lastMousePosition != null)
            {
                var xMovement = Input.mousePosition - _lastMousePosition;
                var angle = xMovement.Value.x * ANGLE_APPROX;

                var originalVector = Camera.main.transform.position - _target;
                var newVector = new Vector3(
                    Mathf.Cos(angle) * originalVector.x - Mathf.Sin(angle) * originalVector.z,
                    Mathf.Clamp(originalVector.y + xMovement.Value.y * VERT_MOVEMENT, -4f, 8.5f),
                    Mathf.Sin(angle) * originalVector.x + Mathf.Cos(angle) * originalVector.z);
                var change = newVector - originalVector;

                Camera.main.transform.position += change;
                LookAtTarget();
            }
            _lastMousePosition = Input.mousePosition;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextStack();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousStack();
        }
    }

    private void NextStack()
    {
        _currentStack = (_currentStack + 1) % 3;
        Focus(_currentStack);
    }

    private void PreviousStack()
    {
        _currentStack = (_currentStack + 2) % 3;
        Focus(_currentStack);
    }

    private void LookAtTarget()
    {
        var levelTarget = new Vector3(_target.x, Camera.main.transform.position.y, _target.z);
        Camera.main.transform.LookAt(levelTarget);
    }
}
