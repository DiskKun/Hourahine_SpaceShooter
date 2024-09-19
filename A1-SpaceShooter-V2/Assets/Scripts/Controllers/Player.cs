using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    Vector3 velocity;
    float acceleration;
    float accelerationTime = 0.5f;
    float maxSpeed = 10;

    float deceleration;
    float decelerationTime = 0.4f;


    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = -(maxSpeed / decelerationTime);
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            velocity += velocity.normalized * deceleration * Time.deltaTime;
            if (velocity.magnitude < 0.01f)
            {
                velocity = Vector3.zero;
            }
        }
        else
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            velocity += direction.normalized * acceleration * Time.deltaTime;
            if (velocity.magnitude > maxSpeed)
            {
                velocity = velocity.normalized * maxSpeed;
            } else if (velocity.magnitude < -maxSpeed)
            {
                velocity = velocity.normalized * -maxSpeed;
            }
        }
        
        transform.position += velocity * Time.deltaTime;
    }
}