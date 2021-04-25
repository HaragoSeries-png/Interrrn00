using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    public Boss boss;
    public bool activate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boss.casting){
            activate = true;
        }
        else{
            activate = false;
        }
    }
}
