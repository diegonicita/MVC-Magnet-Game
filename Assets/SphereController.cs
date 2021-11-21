using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : Controller
{
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
