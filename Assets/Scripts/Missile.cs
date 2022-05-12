using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] public float mSpeed = 5.0f;
    private Rigidbody rocketRb;
    private GameObject player;

    public int spawnPower { get; private set; } // ENCAPSULATION


    void Start()
    {
        rocketRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        spawnPower = Random.Range(-10, 10);
    }


    void Update()
    {
        OnObjectSpawn();
        Shoot();
    }

    void Shoot()
    {
        rocketRb.AddForce((player.transform.position - transform.position).normalized * mSpeed);
    }

    public void OnObjectSpawn()
    {
        rocketRb.velocity = GenerateRandomForce();
    }

    private Vector3 GenerateRandomForce()
    {
        float x = Random.Range(-spawnPower, spawnPower);
        float y = Random.Range(-spawnPower, spawnPower);
        float z = Random.Range(-spawnPower, spawnPower);
        return new Vector3(x, y, z);
    }
}
