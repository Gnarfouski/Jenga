using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CourseDataPack
{
    public List<CourseData> pack;
}

[Serializable]
public class CourseData
{
    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;
}
