using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet0 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed=10f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Enemy enm = hitInfo.GetComponent<Enemy>();
        PlayerColidermanage pl = hitInfo.GetComponent<PlayerColidermanage>();
        if(enm != null)
        {
            enm.takeDamage(50);
        }
        else if(pl != null){
            pl.takeDamage(20);
        }
        

        Destroy(gameObject);
    }
    
}
