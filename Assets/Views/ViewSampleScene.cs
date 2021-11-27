using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSampleScene : View
{
    public GameObject[] cubes;
    public GameObject[] spheres;
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
                    case "Cube1":
                        Debug.Log("cube1");
                        break;
                    case "Sphere1":
                        Debug.Log("sphere1");
                        break;
                }

            }
        }
    }

    public void EnviarMensaje(string texto)
    {
        string [] words = texto.Split(" ");
        if (words[0] == "Cubo1") app.Notify(words[1], cubes[0]);
        if (words[0] == "Esfera1") app.Notify(words[1], spheres[0]);
    }


}
