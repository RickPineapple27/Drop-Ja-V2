using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirElevador : MonoBehaviour
{
    //public AudioSource audioSource;
    //public AudioClip sound;
    public Elevador elevadorScript;
    public Elevador1 elevadorScript1;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Subir()
    {
        //audioSource.clip = sound;
        //audioSource.Play();

        elevadorScript.enabled = true;
        elevadorScript1.enabled = false;

    }

    public void Bajar()
    {
        elevadorScript.enabled = false;
        elevadorScript1.enabled = true;

    }
}
