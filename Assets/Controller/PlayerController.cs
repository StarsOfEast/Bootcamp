using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController; //fiziksel kontrol saðlar
    public float speed = 6.0f; // hýz deðeri
    //gravity
    private float gravity = 9.87f;
    private float verticalSpeed = 0f;
    // camera and rotation
    public Transform cameraHolder; // Kamera tutucusu
    public float mouseSensivity = 2f; // Fare hassasiyeti
    public float upLimit = -50; // Yukarý sýnýrlama açýsý
    public float downLimit = 50; // Aþaðý sýnýrlama açýsý

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
        float horizontalRotation = Input.GetAxis("Mouse X"); // Yatay dönüþ hareketini algýlar
        float VerticalRotation = Input.GetAxis("Mouse Y"); // Dikey dönüþ hareketini algýlar

        transform.Rotate(0, horizontalRotation * mouseSensivity, 0); // Yatay dönüþü uygula
        cameraHolder.Rotate(-VerticalRotation * mouseSensivity, 0, 0); // Dikey dönüþü uygular

        Vector3 currentRotation= cameraHolder.localEulerAngles; // Mevcut dönüþ açýlarýný alýr
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit); // Dikey dönüþ açýsýný sýnýrlar
        cameraHolder.localRotation = Quaternion.Euler(currentRotation); // Yeni dönüþ açýsýný uygular

        
    }

    private void Move()
    {
        float horitontalMove = Input.GetAxis("Horizontal"); //yatay hareketi algýlar
        float verticalMove = Input.GetAxis("Vertical");  // dikey hareketi algýlar
        //Debug.Log(horitontalMove);
        //Debug.Log(verticalMove);

        if (characterController.isGrounded) verticalSpeed = 0; // Karakter yerdeyse dikey hýzý sýfýrlar
        else verticalSpeed -= gravity * Time.deltaTime; // Yerçekimi etkisiyle dikey hýzý günceller

        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0); // Yerçekimi hareketini hesaplar
        Vector3 move = transform.forward * verticalMove + transform.right * horitontalMove; //hýz vektörü hesaplar 
        characterController.Move(Time.deltaTime*speed*move + gravityMove * Time.deltaTime); // hareket etmesini saðlar

        //animator.SetFloat("hiz", verticalMove/3);
        //if(Input.GetKey(KeyCode.LeftShift)) animator.SetFloat("hiz", verticalMove);
        /*animator.setfloat("hiz", vector3.clampmagnitude(move,0.3f).magnitude, 1f, time.deltatime * 5);
        if (ýnput.getkey(keycode.leftshift)) animator.setfloat("hiz", vector3.clampmagnitude(move, 1f).magnitude, 1f, time.deltatime*3);

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
