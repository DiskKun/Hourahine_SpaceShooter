using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject powerupPrefab;
    public int radarPoints;
    public float radarRadius;

    Vector3 velocity;
    float acceleration;
    float accelerationTime = 0.5f;
    float maxSpeed = 10;

    float deceleration;
    float decelerationTime = 0.4f;

    List<float> circleAngles = new List<float>();


    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = -(maxSpeed / decelerationTime);
    }

    void Update()
    {
        PlayerMovement();
        EnemyRadar(radarRadius, radarPoints);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPowerups(2, 9);
        }

    }

    void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float angleIncrement = 360 / numberOfPowerups;
        for (int i = 0; i < numberOfPowerups; i++)
        {
            circleAngles.Add(angleIncrement * i * Mathf.Deg2Rad);
        }
        for (int i = 0; i < circleAngles.Count; i++)
        {
            Vector3 pos1 = new Vector2(Mathf.Cos(circleAngles[i]), Mathf.Sin(circleAngles[i])) * radius;
            Instantiate(powerupPrefab, pos1 + transform.position, Quaternion.identity);
        }
        circleAngles.Clear();
    }

    void EnemyRadar(float radius, int circlePoints)
    {
        Color radarColor = (Mathf.Abs((enemyTransform.position - transform.position).magnitude) < radius) ? Color.red : Color.green;
        float angleIncrement = 360 / circlePoints;
        for (int i = 0; i < circlePoints; i++)
        {
            circleAngles.Add(angleIncrement * i * Mathf.Deg2Rad);
        }
        for (int i = 0; i < circleAngles.Count; i++)
        {
            int pos2Index = (i + 1) % circleAngles.Count;
            Vector3 pos1 = new Vector2(Mathf.Cos(circleAngles[i]), Mathf.Sin(circleAngles[i])) * radius;
            Vector3 pos2 = new Vector2(Mathf.Cos(circleAngles[pos2Index]), Mathf.Sin(circleAngles[pos2Index])) * radius;
            Debug.DrawLine(pos1 + transform.position, pos2 + transform.position, radarColor);
        }
        circleAngles.Clear();
    } 

    void PlayerMovement()
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
        
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            velocity.y += velocity.normalized.y * deceleration * Time.deltaTime;
            //if (velocity.y < 0.01f)
            //{
            //    velocity.y = 0;
            //}
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            velocity.x += velocity.normalized.x * deceleration * Time.deltaTime;
            //if (velocity.x < 0.01f)
            //{
            //    velocity.x = 0;
            //}
        }
        transform.position += velocity * Time.deltaTime;
    }
}