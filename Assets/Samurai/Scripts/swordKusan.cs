using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class swordKusan : MonoBehaviour
{
    public GameObject masadaki;
    public GameObject eldeki;
    public PlayableDirector timeline2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            masadaki.SetActive(false);
            eldeki.SetActive(true);
            timeline2.Play();
        }
    }
}
