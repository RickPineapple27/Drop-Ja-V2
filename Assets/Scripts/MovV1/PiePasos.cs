using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiePasos : MonoBehaviour
{
    public AudioSource pie;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Terrain")
        {
            pie.Play();
        }
    }
}
