using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed;
    public GameObject impactEffect;
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        HitTarget();
    }


    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);
        Destroy(this.gameObject);
    }

}
