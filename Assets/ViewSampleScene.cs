using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSampleScene : View
{     
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                app.Notify(hit.transform.gameObject.name, this);

                switch (hit.transform.gameObject.name)
                {
                    case "Cube":
                        Debug.Log("c");
                        break;
                    case "Sphere":
                        Debug.Log("e");
                        break;
                }

            }
        }
    }

    public void EnviarMensaje(string texto)
    {
        string [] words = texto.Split(" ");
        GameObject box = app.controllers[0].obj;
        GameObject sphere = app.controllers[1].obj;
        if (words[0] == "Cubo") app.Notify(words[1], box);
        if (words[0] == "Esfera") app.Notify(words[1], sphere);
    }


}
