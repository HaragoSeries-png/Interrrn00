using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Warp : MonoBehaviour
{
    public int scenename;
    // Start is called before the first frame update
    private void OnCollisionEnter2D() {
        SceneManager.LoadScene(scenename);
    }

    // Update is called once per frame
    
}
