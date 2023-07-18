using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class samurai : MonoBehaviour
{
    public PlayableDirector timeline3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeline3.Play();
        }
    }
}
