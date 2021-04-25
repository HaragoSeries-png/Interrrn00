using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int Maxhealth =100;
    public int speed=1;
    protected float latestDirectionChangeTime;
    protected readonly float directionChangeTime = 0.5f;
    protected Vector2 movementPerSecond;
    Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        health = 100;
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {

            Destroy(gameObject);
        }
    }
    IEnumerator Dps(int Dps,float appliedTimes,float ApplyDamageNTimes,float Every) {
        appliedTimes = 0f;

        while(appliedTimes < ApplyDamageNTimes)
        {
            yield return new WaitForSeconds(Every);
            this.takeDamage(Dps);          
            appliedTimes++;
        }


    }
    public float getscale()
    {
        return (float)health/(float)Maxhealth;
    }

    public void doDot(int tDps,float appliedTimes,float ApplyDamageNTimes,float Every){
        StartCoroutine(Dps(tDps,appliedTimes,ApplyDamageNTimes,Every));
        // Dps(tDps,appliedTimes,ApplyDamageNTimes,Every);
    }
    
}
