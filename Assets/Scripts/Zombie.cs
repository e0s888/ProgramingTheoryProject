using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie : Enemy //INHERITANCE
{
    public override void Move() // POLYMORPHISM , add this to set new "speed" to 1 for zombie class added to zombie prefab
    {
        speed = 1;
        if (transform.position.y < -2)
        {

            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Move();
    }
}