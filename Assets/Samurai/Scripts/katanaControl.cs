using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class katanaControl : MonoBehaviour
{
    bool yurume=false;
    bool isAttacking = false;
    Animator ktAnim;
    void Start()
    {
        ktAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) )
        {
            yurume = true;
            ktAnim.SetBool("yurume", yurume);
        } else
        {
            yurume = false;
            ktAnim.SetBool("yurume", yurume);
        }

        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            ktAnim.SetTrigger("saldir");
            isAttacking = false;
        }
    }
}
