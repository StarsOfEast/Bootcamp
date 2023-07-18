using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zara : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        Vector3 lookAtDirection = player.position - transform.position;
        lookAtDirection.y = 0f;
        transform.rotation = Quaternion.LookRotation(lookAtDirection);
    }
}
