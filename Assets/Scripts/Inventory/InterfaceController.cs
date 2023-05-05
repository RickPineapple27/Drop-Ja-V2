using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public GameObject panelInventory;
    public bool InvActive;

    public Text itemText;

    public ThirdPersonOrbitCamBasic thirdPersonOrbitCam;
    public MoveBehaviour moveBehaviour;
    public BasicBehaviour basicBehaviour;
    public Animator animator;
    public GameObject TextInv;
    void Start()
    {
        itemText.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Y"))
        {
            animator.enabled = false;
            basicBehaviour.enabled = false;
            thirdPersonOrbitCam.enabled = false;
            moveBehaviour.enabled = false;
            TextInv.SetActive(true);
            InvActive = ! InvActive;
            panelInventory.SetActive(InvActive);
        }
        if(InvActive)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else 
        {

            animator.enabled = true;

            basicBehaviour.enabled = true;
            moveBehaviour.enabled = true;
            thirdPersonOrbitCam.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            TextInv.SetActive(false);
        }
    }
}
