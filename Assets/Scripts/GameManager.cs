using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, StackData> _stacks;

    private void Awake()
    {
        _stacks = new Dictionary<string, StackData>();
        _stacks.Add("6th Grade", new StackData());
        _stacks.Add("7th Grade", new StackData());
        _stacks.Add("8th Grade", new StackData());

        var pack = GetCoursePack();
        foreach (var data in pack)
        {
            if(_stacks.ContainsKey(data.grade))
            {
                _stacks[data.grade].AddData(data);
            }
        }

        foreach(var stack in _stacks.Values)
        {
            stack.Sort();
        }

        GetComponent<StackManager>().Generate(_stacks.Values.ToList());
    }

    private List<CourseData> GetCoursePack()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        CourseDataPack info = JsonUtility.FromJson<CourseDataPack>("{\"pack\":" + jsonResponse + "}");
        return info.pack;
    }
}
