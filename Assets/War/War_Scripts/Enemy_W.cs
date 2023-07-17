using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_W : MonoBehaviour
{
    float hp = 50f;



    // Start is called before the first frame update
    void Start()
    {
        
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
        Destroy(gameObject);
    }

}
