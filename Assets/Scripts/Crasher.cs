using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crasher : Enemy
{
    public Transform Player;
    public float Stoprange, Viewrange;
    public float Dis;
    private Collider2D Mcollider;
    // Start is called before the first frame update
    void Start()
    {
        Mcollider = GetComponent<Collider2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Viewrange = 3.0f;
        Stoprange = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        chaseplayer();
    }
    public void chaseplayer()
    {

        // transform.LookAt(Player);
        // transform.Rotate(new Vector3(0,-90,0),Space.Self);
        Dis = (float)Vector3.Distance(transform.position, Player.position);
          
            if(Dis<=Viewrange){
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, Player.position, step);
            }
     
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Crasher "+hitInfo.name);
        if(hitInfo.name == "PlayerCollider"){
            PlayerColidermanage enm = hitInfo.GetComponent<PlayerColidermanage>();
            if(enm != null)
            {
                enm.takeDamage(90);
            }

            Destroy(gameObject);
        }
        else{
            Debug.Log("nopl "+hitInfo.name);
        }
        
    }
}
