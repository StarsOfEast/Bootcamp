using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle_W : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    float impactForce = 30f;
    

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;

    private bool isShooting = false;

    

    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash.Stop();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire1") )
        {
           
            isShooting = true;
            muzzleFlash.Play();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
            muzzleFlash.Stop();
        }
    }

    public void Shoot()
    {
        

        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            print(hit.transform.name);

            Enemy_W target = hit.transform.GetComponent<Enemy_W>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

        }
    }

}
