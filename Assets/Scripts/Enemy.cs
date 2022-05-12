using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float speed = 2.0f; // must be public to be readed by child class zombie
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
        Move();
    }
    public virtual void Move() //ABSTRACTION , public virtual void - has to be to be readed by zombie .cs to ovveride it
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
