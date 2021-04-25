using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrasherElit : Crasher
{
    // Start is called before the first frame update
    void Start()
    {
        this.Viewrange = 20.0f;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        chaseplayer();
    }
}
