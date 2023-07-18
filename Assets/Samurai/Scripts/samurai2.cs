using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samurai2 : MonoBehaviour
{
    int i = 0;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (i < 2)
        {
            anim.SetTrigger("damage");
            i++;
        }else
        {
            anim.SetTrigger("dead");
        }

    }
}
