using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeController : Controller
{
    private List<GameObject> objs;
    private List<GameObject> UItexts;

    private void Awake()
    {
        objs = app.view.GetComponent<View>().cubesList; 
        UItexts = app.view.GetComponent<View>().textsList;        
    }  

    // Handles the ball hit event
    override public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
        foreach(GameObject o in objs)
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
                    case "Agrandar":
                        AgrandarCubo(o);
                        break;
                    case "Achicar":
                        AchicarCubo(o);
                        break;
                    case "Toggle":
                        ToggleCubo(o);
                        break;
                    case "Collision":
                        Collision c = (Collision)p_data[0];                        
                        GameObject objChocado = GameObject.Find(c.gameObject.name);
                        if (objChocado != null && objChocado.name != "Floor" && app.model.GetCollisionsToWin(o) != 0)
                        {
                            objChocado.SetActive(false);                            
                            app.view.SumeScore(1);
                            app.model.RestaCollisionsToWin(o, 1);
                        }
                        break;
                }
            }
        }
    }

    public void AgrandarCubo(GameObject o)
    {        
        o.transform.localScale = new Vector3(2, 2, 2);        
    }

    public void AchicarCubo(GameObject o)
    {
        o.transform.localScale = new Vector3(1, 1, 1);
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

    public void ToggleCubo(GameObject o)
    {
        app.model.attractorActivado[o.name] = !app.model.attractorActivado[o.name];        
    }

    void FixedUpdate()
    {
        foreach (GameObject o in objs)
        {
            if (app.model.attractorActivado[o.name])
            {
                app.controllers[2].GetComponent<ParticlesController>().GetAttracted(o);
            }
        }
    }
    
}
