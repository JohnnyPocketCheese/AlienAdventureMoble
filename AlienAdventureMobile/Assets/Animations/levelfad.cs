using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelfad : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButton(0))
        {
            fadetolevel(1);
        }
    }
    public void fadetolevel (int levelIdex)
    {
        animator.SetTrigger("FADEOUT");
    }
}
