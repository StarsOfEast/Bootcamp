using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_W : MonoBehaviour
{
    float hp = 500f;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0f)
        {
            Die();
        }
        
    }

    void Die()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 3f);
    }

}
