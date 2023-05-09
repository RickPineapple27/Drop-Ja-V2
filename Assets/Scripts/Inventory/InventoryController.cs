using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Objects[] slots;

    public Image[] slotImage;

    public int[] slotAmount;

    public Animator PersonajeV2;

    private InterfaceController iController;

    public void Awake()
    {
        //PersonajeV2 = GameObject.FindGameObjectWithTag("Player");

    }
    public void Start()
    {
        //PersonajeV2.GetComponent<Animator>().SetBool("Interaction", true);

        PersonajeV2 = GetComponent<Animator>();

        iController = FindObjectOfType<InterfaceController>();
    }

    // Update is called once per frame
    void Update()
    {
        //textoSlots.text = slotAmount.ToString();
        //textoSlots.text = slotAmount + " ";

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray,out hit, 20f))
        {
            if (hit.collider.tag == "Item")
            {
                iController.itemText.text = "Presiona (B) para coleccionar " + hit.transform.GetComponent<ObjectType>().objectType.itemName;

                if (Input.GetButtonDown("Fire3"))//B en Gamepad
                {
                    

                    for (int i = 0; i < slots.Length; i++) 
                    {
                    if (slots[i] == null || slots[i].name == hit.transform.GetComponent<ObjectType>().objectType.name)
                        {
                            slots[i] = hit.transform.GetComponent<ObjectType>().objectType;
                            slotAmount[i]++;
                            slotImage[i].sprite = slots[i].itemSprite;
                            Destroy(hit.transform.gameObject);
                            break;
                        }
                        

                    }
                }
            }
            else if(hit.collider.tag != "Item")
            {
                iController.itemText.text = null;
            }
        }
    }
    
}
