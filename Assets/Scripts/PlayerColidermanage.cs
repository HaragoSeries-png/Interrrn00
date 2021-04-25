using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColidermanage : MonoBehaviour
{
    // Start is called before the first frame update
    private Playerstatus Ps; 
    void Start()
    {
        Ps = GetComponentInParent<Playerstatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int damage)
    {
        // Debug.Log("get ");
        Ps.takeDamage(damage);
        
    }
    public void protecter(){
        StartCoroutine(startpro());
    }
    public void endprotecter(){
        Ps.invincible = false;
    }
    IEnumerator startpro(){

        Ps.invincible = true;
        yield return new WaitForSeconds(5.0f);
        Ps.invincible =false;

    }
}
