using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;

    float acceleration = 10 / 0.5f;
    float maxSpeed = 7;
    public Vector3 velocity;


    float bulletTimer;

    public GameObject bulletPrefab;
    public Transform bombsTransform;

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
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(velocity.y, velocity.x) - 90);

        bulletTimer += Time.deltaTime;
        if (bulletTimer > 2)
        {
            bulletTimer = 0;
            Instantiate(bulletPrefab, transform.position, Quaternion.identity, bombsTransform).GetComponent<Bomb>().velocity = velocity;

        }

    }

}
