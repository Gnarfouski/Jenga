using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _piecePrefab;
    [SerializeField]
    private Transform[] _starts;
    [SerializeField]
    private Material[] _materials;

    public void Generate(List<StackData> stacks)
    {
        GenerateStack(_starts[0], stacks[0]);
        GenerateStack(_starts[1], stacks[1]);
        GenerateStack(_starts[2], stacks[2]);
    }

    private void GenerateStack(Transform start, StackData stackData)
    {
        float[] xValues = new float[6] { -1.2f, 0, 1.2f, 0, 0, 0 };
        float[] yValues = new float[6] { 0.5f, 0.5f, 0.5f, 1.5f, 1.5f, 1.5f };
        float[] zValues = new float[6] { 0, 0, 0, 1.2f, 0, -1.2f };
        float[] rotationValues = { 0, 0, 0, 90, 90, 90 };
        int yIncrement = 0;
        int index = 0;

        for (int i = 0; i < stackData.CourseDatas.Count; i++)
        {
            index = i % 6;
            yIncrement = (int)i / 6;
            InstantiatePiece(start, new Vector3(xValues[index], yValues[index] + 2 * yIncrement, zValues[index]), rotationValues[index], stackData.CourseDatas[i]);
        }
    }

    private void InstantiatePiece(Transform start, Vector3 position, float yRotation, CourseData courseData)
    {
        var piece = GameObject.Instantiate(_piecePrefab);
        piece.transform.SetParent(start);
        piece.transform.localPosition = position;
        piece.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        piece.GetComponent<Renderer>().material = _materials[courseData.mastery];
        piece.GetComponent<Stack>().SetData(courseData);
    }
}
