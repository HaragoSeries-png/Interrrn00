using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossbullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed=16.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        

        PlayerColidermanage pl = hitInfo.GetComponent<PlayerColidermanage>();
        
        if(pl != null){
            pl.takeDamage(20);
            Destroy(gameObject);
        }
        else if(hitInfo.tag=="colli"){
            Destroy(gameObject);
        }
        

        
    }
}
