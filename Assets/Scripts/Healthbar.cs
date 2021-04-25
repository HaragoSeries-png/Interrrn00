using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{

    public Playerstatus Ps;

    public float hsize;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hsize = Ps.getscale();
        transform.localScale =new Vector3( hsize,1,1);
    }
}
