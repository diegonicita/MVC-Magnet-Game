using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSampleScene : View
{
    public GameObject cube;
    public GameObject sphere;
    public GameObject[] particles;

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
        if (words[0] == "Cubo") app.Notify(words[1], cube);
        if (words[0] == "Esfera") app.Notify(words[1], sphere);
    }


}
