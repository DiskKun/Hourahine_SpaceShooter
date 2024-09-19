using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;

    float acceleration = 10 / 0.5f;
    float maxSpeed = 9;
    Vector3 velocity;

    private void Start()
    {
        velocity = Vector3.zero;
    }

    private void Update()
    {
        velocity.y += acceleration * Mathf.Sign(playerTransform.position.y - transform.position.y) * Time.deltaTime;
        velocity.x += acceleration * Mathf.Sign(playerTransform.position.x - transform.position.x) * Time.deltaTime;

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        transform.position += velocity * Time.deltaTime;
    }

}
