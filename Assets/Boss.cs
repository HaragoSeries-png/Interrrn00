using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Boss : Enemy
{
    // Start is called before the first frame update
    
    public Transform Player;
    public Playerstatus playerstatus;
    private float Viewrange=10.0f;
    private float time,ti ,tis,Tisum;
    public bool walk =false,casting=false,ulted1=false,ulted2=false,ulted3=false;
    private float walktime,casttime;
    private float ultiratio;
    public Transform ultiindicator;
    public GameObject ultimatebound ;
    public GameObject bullet;
    public GameObject summ;

    
    void Start()
    {
        this.Maxhealth=9000;
        this.health=9000;
        this.speed= 2;
        ti=0;
        ultimatebound.GetComponent<Renderer>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        if(!casting){
            chaseplayer();
            Shoot();
            summon();
        }       
        if(this.health<7500 && !ulted1){
            Debug.Log("ulti1");
            ULtimate();
        }
        if(this.health<5000 && !ulted2){
            Debug.Log("ult2");
            ULtimate();
        }
        if(this.health<2500 && !ulted3){
            Debug.Log("ulti3");
            ULtimate();
        }
    }
    void chaseplayer()
    {
        // transform.LookAt(Player);
        // transform.Rotate(new Vector3(0,-90,0),Space.Self);
        if((time - ti  > 5.0)||walk){
            ti =time;
            walk = true;
            float Dis = (float)Vector3.Distance(transform.position, Player.position);
            
                if(Dis<=Viewrange){
                    float step = speed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, Player.position, step);

            }   
            walktime += Time.deltaTime;
            if(walktime >2.0f){
                walk = false;
                walktime = 0;
            }
     
        }
    }
    void ULtimate(){
        Debug.Log("start ult"+ulted1+ulted2+ulted3);
        ultimatebound.GetComponent<Renderer>().enabled = true;

        casting = true;
        transform.position = new Vector3(0,0,0);
        casttime += Time.deltaTime;
        ultiratio = casttime/3.0f;
        ultiindicator.localScale =ultiratio*new Vector3(1,1,1);
        if(casttime>3.0f){
            playerstatus.takeDamage(100);
            casting = false;
            casttime =0;
            if(ulted1){
                if(ulted2){
                    ulted3 = true;
                }
                ulted2 = true;   
            }
            ulted1 = true;
            ultimatebound.GetComponent<Renderer>().enabled = false;
            ultiindicator.localScale =Vector3.zero;
        }
    }
    void Shoot() {
         
        if((Time.time - tis  > 4.0)&& !casting){
            tis =Time.time;
            Debug.Log("shoot");
            StartCoroutine(letshoot());
        }
    }
    IEnumerator letshoot(){
        int i =0;
        while(i<3){
            Vector2 dir =  Player.position-transform.position;
            Vector3 dir2 = 1.3f*Vector3.Normalize(Player.position-transform.position);
            float Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.Euler(0, 0, Angle);
            Instantiate(bullet, (transform.position+dir2),rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            yield return new WaitForSeconds(0.5f);
            i++;
        }
    }
    void summon(){
        if(Time.time - Tisum  > 20.0){
            Tisum =Time.time;

            Vector2 dir =  Player.position-transform.position;
            Vector3 dir2 = 1.5f*Vector3.Normalize(Player.position-transform.position);
            // dir2 = new Vector3(
            //     (Mathf.Sign(dir2.x) * (Mathf.Ceil(Mathf.Abs(dir2.x))+1)),
            //     (Mathf.Sign(dir2.y) * (Mathf.Ceil(Mathf.Abs(dir2.y))+1)),
            //     (Mathf.Sign(dir2.z) * (Mathf.Ceil(Mathf.Abs(dir2.z))+1))
            // );
            float Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            Instantiate(summ, (transform.position+dir2),rotation);


        }
    }
    
}