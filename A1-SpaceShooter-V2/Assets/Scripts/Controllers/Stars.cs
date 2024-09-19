using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    int currentStarIndex = 0;

    float lineLength = 0;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    void DrawConstellation()
    {
        Vector3 distance = starTransforms[currentStarIndex + 1].position - starTransforms[currentStarIndex].position;
        if (lineLength < distance.magnitude)
        {
            lineLength += (distance.magnitude / drawingTime) * Time.deltaTime;
        } else
        {
            currentStarIndex += 1;
            lineLength = 0;
        }
        currentStarIndex = currentStarIndex % (starTransforms.Count - 1);
        Debug.DrawLine(starTransforms[currentStarIndex].position, starTransforms[currentStarIndex].position + distance.normalized * lineLength);
    }
}
