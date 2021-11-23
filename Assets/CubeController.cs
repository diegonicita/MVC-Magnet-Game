using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : Controller
{
    // Handles the ball hit event
    override public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
        if (p_target.name == obj.name)
        {
            Debug.Log(p_event_path + " - " + p_target.name);

            switch (p_event_path)
            {
                case "ColorBlanco":
                    CambiarABlanco();
                    break;
                case "ColorRojo":
                    CambiarARojo();
                    break;
                case "Agrandar":
                    AgrandarCubo();
                    break;
                case "Achicar":
                    AchicarCubo();
                    break;
            }
        }
    }

    public void AgrandarCubo()
    {        
        obj.transform.localScale = new Vector3(2, 2, 2);        
    }

    public void AchicarCubo()
    {
        obj.transform.localScale = new Vector3(1, 1, 1);
    }

    public void CambiarABlanco()
    {
        Color newColor = new Color(1, 1, 1, 1);
        rend.material.shader = Shader.Find("Universal Render Pipeline/Lit");
        rend.material.SetColor("_BaseColor", newColor);        
    }

    public void CambiarARojo()
    {
        Color newColor = new Color(1, 0, 0, 1);
        rend.material.shader = Shader.Find("Universal Render Pipeline/Lit");
        rend.material.SetColor("_BaseColor", newColor);        
    }
}
