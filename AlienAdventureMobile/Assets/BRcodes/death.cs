using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "die")
        {
            SceneManager.LoadScene("level 1");
        }
        if (collision.gameObject.tag == "win")
        {
            SceneManager.LoadScene("win");
        }
    }

}
