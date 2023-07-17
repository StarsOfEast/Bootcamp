using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController; //fiziksel kontrol sa�lar
    public float speed = 6.0f; // h�z de�eri
    //gravity
    private float gravity = 9.87f;
    private float verticalSpeed = 0f;
    // camera and rotation
    public Transform cameraHolder; // Kamera tutucusu
    public float mouseSensivity = 2f; // Fare hassasiyeti
    public float upLimit = -50; // Yukar� s�n�rlama a��s�
    public float downLimit = 50; // A�a�� s�n�rlama a��s�

    //public Animator animator;

    private void Start()
    {
       // animator = GetComponent<Animator>();

    }

    void Update()
    {
        Move();
        Rotate();
    }

    public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X"); // Yatay d�n�� hareketini alg�lar
        float VerticalRotation = Input.GetAxis("Mouse Y"); // Dikey d�n�� hareketini alg�lar

        transform.Rotate(0, horizontalRotation * mouseSensivity, 0); // Yatay d�n��� uygula
        cameraHolder.Rotate(-VerticalRotation * mouseSensivity, 0, 0); // Dikey d�n��� uygular

        Vector3 currentRotation= cameraHolder.localEulerAngles; // Mevcut d�n�� a��lar�n� al�r
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit); // Dikey d�n�� a��s�n� s�n�rlar
        cameraHolder.localRotation = Quaternion.Euler(currentRotation); // Yeni d�n�� a��s�n� uygular

        
    }

    private void Move()
    {
        float horitontalMove = Input.GetAxis("Horizontal"); //yatay hareketi alg�lar
        float verticalMove = Input.GetAxis("Vertical");  // dikey hareketi alg�lar
        //Debug.Log(horitontalMove);
        //Debug.Log(verticalMove);

        if (characterController.isGrounded) verticalSpeed = 0; // Karakter yerdeyse dikey h�z� s�f�rlar
        else verticalSpeed -= gravity * Time.deltaTime; // Yer�ekimi etkisiyle dikey h�z� g�nceller

        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0); // Yer�ekimi hareketini hesaplar
        Vector3 move = transform.forward * verticalMove + transform.right * horitontalMove; //h�z vekt�r� hesaplar 
        characterController.Move(Time.deltaTime*speed*move + gravityMove * Time.deltaTime); // hareket etmesini sa�lar

        //animator.SetFloat("hiz", verticalMove/3);
        //if(Input.GetKey(KeyCode.LeftShift)) animator.SetFloat("hiz", verticalMove);
        /*animator.setfloat("hiz", vector3.clampmagnitude(move,0.3f).magnitude, 1f, time.deltatime * 5);
        if (�nput.getkey(keycode.leftshift)) animator.setfloat("hiz", vector3.clampmagnitude(move, 1f).magnitude, 1f, time.deltatime*3);

        if (horitontalmove > 0) {
            animator.setbool("sag", true);
        }
        else if (horitontalmove < 0){
            animator.setbool("sol", true);
        }
        else
        {
            animator.setbool("sag", false);
            animator.setbool("sol", false);
        }*/
        
        //animator.SetBool("isWalking", verticalMove !=0 || horitontalMove != 0);
    }
}
