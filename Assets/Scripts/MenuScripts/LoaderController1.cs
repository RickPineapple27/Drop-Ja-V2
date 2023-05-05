using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LoaderController1 : MonoBehaviour
{

    public Slider loader;
    public TMP_Text loadingText;
    public float progress;
    // Start is called before the first frame update
    void Start()
    {
        progress = 0;
        StartCoroutine(cargaRecursos());
    }

    // Update is called once per frame
    void Update()
    {
        carga();
    }

    public void carga()
    {
        progress += Time.deltaTime / 5.0f;
        if(progress >= 1)
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
        else
        {
            loader.value = Mathf.Clamp01(progress);
            loadingText.text = string.Format("{0}%",(int)(loader.value * 100)); 
        }
    }




    IEnumerator cargaRecursos()
    {
        
        yield return new WaitForSecondsRealtime(10);
        
        //aqui puedes cargar los recursos que necesites
        //...
        //Texture2D myTexture = Resources.Load<Texture2D>("myTexture");
        //yield return null;
    }
    
}
