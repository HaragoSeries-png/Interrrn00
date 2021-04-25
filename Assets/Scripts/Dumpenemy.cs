using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpenemy : Enemy
{
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        Randmove();
    }
    void Randmove()
    {

        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            Vector2 movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
            movementPerSecond = movementDirection * speed;
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }
}
