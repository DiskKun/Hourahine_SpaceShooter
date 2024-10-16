using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float angularSpeed;
    public float targetAngle;
    public Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 distanceVector = targetTransform.position - transform.position;
        float distanceAngle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        distanceAngle = StandardizeAngle(distanceAngle);

        Debug.DrawLine(transform.position, targetTransform.position, Color.blue);

        float sign = Mathf.Sign(distanceAngle - StandardizeAngle(transform.eulerAngles.z));
        if (Mathf.Abs(distanceAngle - StandardizeAngle(transform.eulerAngles.z)) > 180)
        {
            sign = -sign;
        }
        
        transform.Rotate(0, 0, angularSpeed * Time.deltaTime * sign);

        Debug.DrawLine(transform.position, transform.position + transform.up, Color.red);
    }

    public float StandardizeAngle(float inAngle)
    {
        inAngle = inAngle % 360;

        inAngle = (inAngle + 360) % 360;

        if (inAngle > 180)
        {
            inAngle -= 360;
        }

        return inAngle;
    }
}
