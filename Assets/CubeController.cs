using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : Controller
{    
    public int AgrandarCubo(string msg)
    {        
        obj.transform.localScale = new Vector3(2, 2, 2);
        return 2;
    }

    public int AchicarCubo(string msg)
    {
        obj.transform.localScale = new Vector3(1, 1, 1);
        return 2;
    }

    public int CambiarABlanco(string msg)
    {
        Color newColor = new Color(1, 1, 1, 1);
        rend.material.shader = Shader.Find("Universal Render Pipeline/Lit");
        rend.material.SetColor("_BaseColor", newColor);
        return 0;
    }

    public int CambiarARojo(string msg)
    {
        Color newColor = new Color(1, 0, 0, 1);
        rend.material.shader = Shader.Find("Universal Render Pipeline/Lit");
        rend.material.SetColor("_BaseColor", newColor);
        return 1;
    }
}
