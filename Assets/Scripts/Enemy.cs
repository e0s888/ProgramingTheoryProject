using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody enemyRb;
    private GameObject player;

    //odtad zmiany

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //inaczej - enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        //enemyRb.AddForce(lookDirection * speed * Time.deltaTime); dodaæ Time.deltaTime aby spowolniæ prêdkoœæ odbicia
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -6)
        {
            
            Destroy(gameObject);
        }
    }
}
