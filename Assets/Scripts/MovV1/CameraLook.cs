using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    //public float Speed = 1.0f;
    public float mouseSensivity = 80f;
    public Transform playerBody;

    float xRotation = 0;

    //public float JumpForce = 1.0f;

    private Rigidbody Physics;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;    

        //Physics = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
       //float horizontal = Input.GetAxis("Horizontal");
       //float vertical = Input.GetAxis("Vertical");
        
      // transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime);


        //Rotacion
        float mouseX = Input.GetAxis("Mouse X")*mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);
       //Salto
       //if (Input.GetKeyDown(KeyCode.Space))
       //{
      //      Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
     //  }

    }
}
