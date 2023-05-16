using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecetaMaterials : MonoBehaviour
{
    public static RecetaMaterials shd; 
    public int Roca;
    public int Carbon;
    public int Hojas;

    void awake()
    {
        if(shd == null)
        {
            shd= this;
        }
    }


}
