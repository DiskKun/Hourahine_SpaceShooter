using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitRadius;
    public float orbitSpeed;

    float orbitAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitRadius, orbitSpeed, planetTransform);
    }

    void OrbitalMotion(float radius, float speed, Transform target)
    {
        orbitAngle += Time.deltaTime * speed;
        float rad = orbitAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad)) * radius + target.position;
    }
}
