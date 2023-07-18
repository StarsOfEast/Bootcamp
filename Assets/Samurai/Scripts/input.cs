using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    public float moveSpeed;
    public float mouseSpeed;
    public float extraSpeedAmount=2;
    float startSpeed;
    float extraSpeed;
    float Xmouse;
    float Ymouse;
    float Xmove;
    float Ymove;
    Animator anim;

    void Start()
    {
        startSpeed = moveSpeed;
        extraSpeed = moveSpeed + extraSpeedAmount;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = extraSpeed;
        else moveSpeed = startSpeed;

        Xmove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Ymove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(Xmove, 0f, Ymove);

        Xmouse = Input.GetAxis("Mouse Y");
        Ymouse = Input.GetAxis("Mouse X");
        transform.Rotate(-Xmouse, 0f, 0f);
        transform.Rotate(0f, Ymouse, 0f, Space.World);
    }
}