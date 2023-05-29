using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StackData
{
    private List<CourseData> _datas;

    public List<CourseData> CourseDatas => _datas;
    public StackData()
    {
        _datas = new List<CourseData>();
    }

    public void AddData(CourseData data)
    {
        _datas.Add(data);
    }

    public void Sort()
    {
        _datas.OrderBy(a => a.domainid).ThenBy(a => a.cluster).ThenBy(a => a.standardid);
    }
}
