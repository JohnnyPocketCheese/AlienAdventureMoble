using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    bool shooting;
    float timer;
    public float shootAnimDelay = 0.8f;

    void Update()
    {
        timer += Time.deltaTime;
        if(shooting && timer > shootAnimDelay)
        {
            shooting = false;
        }
        GetComponent<Animator>().SetBool("shooting", shooting);
    }

    public void Shoot()
    {
        animator.SetTrigger("GUN");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        shooting = true;
        timer = 0;

    }
}
