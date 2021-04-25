using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fire : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
   
    public bool Pressed,reles;

    // Use this for initialization
    void Awake() {
        
    
    
        reles = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(reles==true){
            Debug.Log("reles "+reles);
            Pressed = true;
            reles = false;
        }
        else{
            Debug.Log("reles stop "+reles);
            Pressed = false;
        }
       
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        reles =true;
    }
}
