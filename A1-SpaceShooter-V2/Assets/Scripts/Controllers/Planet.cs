using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public float gravityFieldDistance = 3;
    public float gravityForce = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < gravityFieldDistance)
        {
            player.GetComponent<Player>().velocity += (transform.position - player.transform.position).normalized * gravityForce * Time.deltaTime;
        }

        if ((enemy.transform.position - transform.position).magnitude < gravityFieldDistance)
        {
            enemy.GetComponent<Enemy>().velocity += (transform.position - enemy.transform.position).normalized * gravityForce * Time.deltaTime;
        }
    }
}
