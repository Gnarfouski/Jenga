using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _gradeLevel, _cluster, _description;

    public void LoadData(CourseData data)
    {
        _gradeLevel.text = data.domain;
        _cluster.text = data.cluster;
        _description.text = data.standarddescription;
    }
}
