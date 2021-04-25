using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerstatus : MonoBehaviour
{
    public static int health=100;
    public int Maxhealth;
    public bool invincible=false;
    private Scene  activeScene;

    // Start is called before the first frame update
    void Start()
    {
        Maxhealth = 100;
        activeScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    public void takeDamage(int damage)
    {
        if(!this.invincible){
            
            health -= damage;
            if (health <= 0)
            {
                // Debug.Log("affffff");
                health = Maxhealth;
                SceneManager.LoadScene(activeScene.name);
            }
        }
        
    }
    public float getscale()
    {
        return (float)health/(float)Maxhealth;
    }

    
}
