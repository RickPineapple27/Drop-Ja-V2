using UnityEngine;
using System.Collections;

public class FootStep : MonoBehaviour {
	
	public AudioClip[] SonidoMetal;
	public AudioClip[] SonidoMadera;
	public AudioClip[] SonidoConcreto;
	public AudioClip[] SonidoTerreno;
	private CharacterController controller;
	private float delayTime;
	private float NextPlay;
	
	void PlayFootStepSound()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 10f) & Time.time > NextPlay)
		{
			NextPlay = delayTime + Time.time;
			delayTime = Random.Range(0.25f, 0.5f);
			switch (hit.collider.tag)
			{
			case "metal":
				GetComponent<AudioSource>().clip = SonidoMetal[Random.Range (0, SonidoMetal.Length)];
				GetComponent<AudioSource>().Play();
				break;
			case "madera":
				GetComponent<AudioSource>().clip = SonidoMadera[Random.Range(0, SonidoMadera.Length)];
				GetComponent<AudioSource>().Play ();
				break;
			case "concreto":
				GetComponent<AudioSource>().clip = SonidoConcreto[Random.Range(0, SonidoConcreto.Length)];
				GetComponent<AudioSource>().Play();
				break;
			default:
				GetComponent<AudioSource>().clip = SonidoTerreno[Random.Range (0, SonidoTerreno.Length)];
				GetComponent<AudioSource>().Play();
				break;
			}
		}
	}
	
	// Funcion start para inicializar el juego
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Funcion update para determinar frame por frame y mandar llamar objetos establecidos en el constructor
	void Update () 
	{
		if (controller.isGrounded & controller.velocity.magnitude > 0.5)
		{
			PlayFootStepSound();
		}
	}
}
