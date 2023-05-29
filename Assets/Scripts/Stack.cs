using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private CourseData _data;

    public CourseData Data => _data;
    public void SetData(CourseData data)
    {
        _data = data;
    }
}
