using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staff : MonoBehaviour
{
    public Fire firebutt,Cbutt;
    public Transform Firepoint;
    public GameObject  bullet;
    public GameObject  Fireball;
    public Transform PP;
    private float Angle=0f;
    private bool reles=true ;
    private bool ched=true ;
    private int btype=0;
    public GameObject txt;
    private Text mytxt;
    public GameObject Nspell;
    
    // Start is called before the first frame update
    void Start()
    {        
        Nspell = bullet;
        mytxt = txt.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Callshoot()  ;
        Change();

    }
    void Shoot() {
        Vector2 dir = Firepoint.position - PP.position;
        Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.Euler(0, 0, Angle);
        Instantiate(Nspell, Firepoint.position,rotation);
        Rigidbody2D rb = Nspell.GetComponent<Rigidbody2D>();
        
    }
    public void changespell(){
        Debug.Log("change");
        if(btype==0){
            Nspell = Fireball;
            btype = 1;
            mytxt.text = "Fireball";
        }
        else{
            Nspell = bullet;
            btype = 0;
            mytxt.text = "Normal";
        }

    }
    void Callshoot(){
        if (firebutt.Pressed || Input.GetKeyDown("space"))
        {
            if(firebutt.Pressed){
                if(reles){
                    Shoot();
                }
                reles = false;
            }
            else{
               Shoot(); 
            }         
        }
        else{
            reles=true;
        }
    }
    void Change(){
        if (Cbutt.Pressed || Input.GetKeyDown(KeyCode.R))
        {
            if(Cbutt.Pressed){
                if(ched){
                    changespell();
                    ched = false;
                }       
            } 
            else{
                changespell();
            }                                
        }
        else{
            ched=true;
        }
    }
}
