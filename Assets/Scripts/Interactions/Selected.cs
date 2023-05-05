using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Selected : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;

    //texto
    public Texture2D puntero;
    public GameObject TextDetect;
    GameObject ultimoReconocido = null;

    public Animator animator;
    public GameObject panelAnimacion;

    public GameObject personaje;
    public Transform puntoInicial;
    public Transform puntoEntrada;
    public Transform puntoArranque;

    public void Awake()
    {
        personaje = GameObject.FindGameObjectWithTag("Player");
        puntoInicial = GameObject.FindGameObjectWithTag("PuntoInicial").transform;
        puntoEntrada = GameObject.FindGameObjectWithTag("PuntoEntrada").transform;
        puntoArranque = GameObject.FindGameObjectWithTag("PuntoArranque").transform;
        panelAnimacion = GameObject.FindGameObjectWithTag("Animacion");

    }

    void Start()
    {
        panelAnimacion.GetComponent<Animator>();

        //Iniciamos al player en el punto de arranque
        personaje.transform.position = puntoArranque.position;

        mask = LayerMask.GetMask("Raycast Detect");
        TextDetect.SetActive(false);
    }


    void Update()
    {
        //Raycast(origen, direccion, out hit, distancia, mascara)

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Deselect();
            SelectedObject(hit.transform);
            if (hit.collider.tag == "MesaCrafteo")
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    hit.collider.transform.GetComponent<Objeto>().ActivarObjeto();

                }
            }
            if (hit.collider.tag == "SubirElevador")
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    hit.collider.transform.GetComponent<SubirElevador>().Subir();

                }
            }
            if (hit.collider.tag == "BajarElevador")
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    hit.collider.transform.GetComponent<SubirElevador>().Bajar();

                }
            }

            if (hit.collider.tag == "PasarCity")
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    //Debug.Log("Transladamos al player a afuera del bunker");
                    //Transladamos al personaje a la parte de afuera
                    animator.Play("salida");
                    StartCoroutine("AnimacionEntrada");
                    
                }
            }
            if (hit.collider.tag == "PasarBunker")
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    //Pasamos al personaje a la parte de adentro del bunker junto a la puerta
                    //Debug.Log("Transladamos al personaje a dentro del bunker");
                    animator.Play("salida");
                    StartCoroutine("AnimacionSalida");

                }
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        }
        else
        {
            Deselect();
        }
    }

    IEnumerator AnimacionEntrada()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        animator.Play("Entrada");
        personaje.transform.position = puntoInicial.position;

    }

    IEnumerator AnimacionSalida()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        animator.Play("Entrada");
        personaje.transform.position = puntoEntrada.position;

    }

    public void SelectedObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoReconocido = transform.gameObject;
    }

    public void Deselect()
    {
        if(ultimoReconocido)
        {
        ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
        ultimoReconocido = null;
        
        }
    }

    public void OnGUI() 
    {

        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
        GUI.DrawTexture(rect, puntero);

        if(ultimoReconocido)
        {
            TextDetect.SetActive(true);
        }
        else
        {
            TextDetect.SetActive(false);
        }
    }

}
