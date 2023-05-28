using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;

public class CourseDataRetrieval : MonoBehaviour
{
    private const string API_KEY = "88169749096b61e3b85398905927f53c";
    public string Id;

    private void Awake()
    {
        var data = GetCourseData();
    }

    private CourseDataPack GetCourseData()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack", Id, API_KEY));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        CourseDataPack info = JsonUtility.FromJson<CourseDataPack>("{\"pack\":" + jsonResponse + "}");
        return info;
    }
}