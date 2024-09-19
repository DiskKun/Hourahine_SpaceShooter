using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(0f, maxFloatDistance) + transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    void AsteroidMovement()
    {
        transform.position += (target - transform.position).normalized * moveSpeed * Time.deltaTime;
        if (Mathf.Abs((target - transform.position).magnitude) < arrivalDistance)
        {
            target = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(0f, maxFloatDistance) + transform.position;
        }
    }
}
