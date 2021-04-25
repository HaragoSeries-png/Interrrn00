using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powpow : Enemy
{
 
    public GameObject bullet;
    public Transform PP;
    private float Angle=0f;
    private float Ti;
    // Start is called before the first frame update
    void Start()
    {
        PP=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Shoot();
    }
    void Shoot() {
         
        if(Time.time - Ti  > 2.0){
            Ti =Time.time;

            Vector2 dir =  PP.position-transform.position;
            Vector3 dir2 = 0.5f*Vector3.Normalize(PP.position-transform.position);
            // dir2 = new Vector3(
            //     (Mathf.Sign(dir2.x) * (Mathf.Ceil(Mathf.Abs(dir2.x))+1)),
            //     (Mathf.Sign(dir2.y) * (Mathf.Ceil(Mathf.Abs(dir2.y))+1)),
            //     (Mathf.Sign(dir2.z) * (Mathf.Ceil(Mathf.Abs(dir2.z))+1))
            // );
            Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.Euler(0, 0, Angle);
            Instantiate(bullet, (transform.position+dir2),rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        }
    }
    
}
