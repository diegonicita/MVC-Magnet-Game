using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : Controller
{
    private GameObject obj;
    private Renderer rend;
    private Rigidbody rb;

    private void Awake()
    {
        obj = app.views.GetComponent<ViewSampleScene>().sphere;
        if (obj != null)
            rb = obj.GetComponent<Rigidbody>();
        if (obj != null)
            rend = obj.GetComponent<Renderer>();
    }

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
            }
        }
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
