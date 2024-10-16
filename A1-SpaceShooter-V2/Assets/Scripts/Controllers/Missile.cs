using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Transform enemyTransform;

    float acceleration = 5 / 0.5f;
    float maxSpeed = 7;
    Vector3 velocity;

    private void Start()
    {
        enemyTransform = GameObject.Find("Enemy").transform;
        velocity = Vector3.zero;
    }

    private void Update()
    {
        velocity.y += acceleration * Mathf.Sign(enemyTransform.position.y - transform.position.y) * Time.deltaTime;
        velocity.x += acceleration * Mathf.Sign(enemyTransform.position.x - transform.position.x) * Time.deltaTime;

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        transform.position += velocity * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(velocity.y, velocity.x) - 90);
    }
}
