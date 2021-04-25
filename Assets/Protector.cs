using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Protector : MonoBehaviour
{
    // Start is called before the first frame update
    public Mapcontrol mapcontrol;
    private bool Pen;
    private Collider2D Mcollider;
    public Image Ui;
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = 0.0f;
        Ui.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(cheker());
    }
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if(Pen){
            // Debug.Log("Protect "+hitInfo.name);
            if(hitInfo.name == "PlayerCollider"){
                PlayerColidermanage player = hitInfo.GetComponent<PlayerColidermanage>();
                if(player != null)
                {
                    player.protecter();
                }
            }
            else{
            }
        }    
    }
    // private void OnTriggerExit2D(Collider2D hitInfo) {
        
    //         Debug.Log("Exittt "+hitInfo.name);
    //         if(hitInfo.name == "PlayerCollider"){
    //             PlayerColidermanage player = hitInfo.GetComponent<PlayerColidermanage>();
    //             if(player != null)
    //             {
      
    //             }

    //         }
    //         else{
    //         }
        
        
    // }
    IEnumerator cheker(){
        if(mapcontrol.activate){
            // Debug.Log("active");
            GetComponent<CircleCollider2D>().radius = 1.0f;
            Ui.enabled = true;
            Pen = true;
        }
        else{
            yield return new WaitForSeconds(0.9f);
            // Debug.Log("Deactive");
            GetComponent<CircleCollider2D>().radius = 0.0f;
            Ui.enabled = false;
            Pen = false;
        }
    }


}
