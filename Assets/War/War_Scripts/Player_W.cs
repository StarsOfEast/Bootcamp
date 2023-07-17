using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEditor.ShaderGraph;
using Unity.VisualScripting;

public class Player_W : MonoBehaviour
{
    float speed = 1500f;
    float sens = 100f;
    

    float minCameraRotationX = -30f;
    float maxCameraRotationX = 20f;

    Animator anim;
    private Rigidbody rb;


    float h;
    float v;
    float mouseX;
    float mouseY;


    public GameObject rifle;
    public Transform cameraTransform;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();


        

        rb.isKinematic = false;


    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        Vector3 movement = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f) * new Vector3(h, 0f, v);

        rb.velocity = movement * speed * Time.deltaTime;


        // Pass the movement values to the Animator parameters
        anim.SetFloat("horizontal", h);
        anim.SetFloat("vertical", v);


        

        float rotationAmount = mouseX * sens * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);

        float cameraRotationX = cameraTransform.localEulerAngles.x;
        float desiredCameraRotationX = cameraRotationX - mouseY * sens * Time.deltaTime;
        desiredCameraRotationX = ClampCameraRotation(desiredCameraRotationX);
        cameraTransform.localRotation = Quaternion.Euler(desiredCameraRotationX, 0f, 0f);


        //if there is no ibject with tag "enemy", load the scene indexed 3
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            //quit the game
            Application.Quit();
        }


    }

    private float ClampCameraRotation(float rotationX)
    {
        if (rotationX > 180f)
        {
            rotationX -= 360f;
        }

        rotationX = Mathf.Clamp(rotationX, minCameraRotationX, maxCameraRotationX);

        return rotationX;
    }

}
