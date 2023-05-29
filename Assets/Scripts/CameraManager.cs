using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _lastMousePosition;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isMoving = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            _isMoving = false;
        }

        if(_lastMousePosition != null)
        {
            var movement = Input.mousePosition - _lastMousePosition;
        }
    }
}
