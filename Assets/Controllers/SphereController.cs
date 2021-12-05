using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : Controller
{
    private List<GameObject> objs;
    
    private void Awake()
    {
        objs = app.views.GetComponent<ViewSampleScene>().spheresList;        
    }

    // Handles the ball hit event
    override public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
        foreach (GameObject o in objs)
        {

            if (p_target.name == o.name)
            {
                Debug.Log(p_event_path + " - " + p_target.name);

                switch (p_event_path)
                {
                    case "ColorBlanco":
                        CambiarABlanco(o);
                        break;
                    case "ColorRojo":
                        CambiarARojo(o);
                        break;
                }
            }
        }
    }

    public void CambiarABlanco(GameObject o)
    {
        Color newColor = new Color(1, 1, 1, 1);
        o.GetComponent<Renderer>().material.shader = Shader.Find("Universal Render Pipeline/Lit");
        o.GetComponent<Renderer>().material.SetColor("_BaseColor", newColor);        
    }

    public void CambiarARojo(GameObject o)
    {
        Color newColor = new Color(1, 0, 0, 1);
        o.GetComponent<Renderer>().material.shader = Shader.Find("Universal Render Pipeline/Lit");
        o.GetComponent<Renderer>().material.SetColor("_BaseColor", newColor);        
    }
}
