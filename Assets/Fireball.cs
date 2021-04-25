using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public float ApplyDamageNTimes =3.0f ;
    public float ApplyEveryNSeconds =0.5f ;
    public Rigidbody2D rb;
    public float speed=10f;
    private int appliedTimes = 0;
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

        Enemy enm = hitInfo.GetComponent<Enemy>();
  
        if(enm != null)
        {
            Debug.Log("hit");
            enm.doDot(30,appliedTimes,ApplyDamageNTimes,ApplyEveryNSeconds);
        }
     
        

        Destroy(gameObject);
    }
    
}
