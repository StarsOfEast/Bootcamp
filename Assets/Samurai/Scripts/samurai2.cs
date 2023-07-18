using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class samurai2 : MonoBehaviour
{
    int i = 0;
    Animator anim;
    public Transform player;
    public float kilicMenzil = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= kilicMenzil && Input.GetButtonDown("Fire1"))
        {
            if (i < 2)
            {
                anim.SetTrigger("damage");
                i++;
            }
            else
            {
                anim.SetTrigger("dead");
                StartCoroutine(nextLevel());
            }
        }
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("egypt");
    }
}
