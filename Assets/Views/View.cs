using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class View : Elemento
{
    public Dictionary<string, GameObject> objectosDictionary = new Dictionary<string, GameObject>();
    public List<GameObject> cubesList;
    public List<GameObject> spheresList;
    public List<GameObject> particlesList;
    public List<GameObject> textsList;

    private void Awake()
    {
        addObject("Cube1", "Cube");
        addObject("Cube2", "Cube");
        addObject("Sphere1", "Sphere");
        addObject("Sphere2", "Sphere");
        addObject("Particle1", "Particle");
        addObject("Particle2", "Particle");
        addObject("Particle3", "Particle");
        addObject("Particle4", "Particle");
        addObject("Particle5", "Particle");
        addObject("Particle6", "Particle");
        addObject("TextScore", "Texto");        
    }

    private void addObject(string name, string tipo)
    {
        GameObject obj = GameObject.Find(name);
        objectosDictionary.Add(name, obj);
        switch(tipo)
        {
            case "Cube":
            cubesList.Add(obj);
            break;
            case "Sphere":
            spheresList.Add(obj);
            break;
            case "Particle":
            particlesList.Add(obj);
            break;
            case "Texto":
            textsList.Add(obj);            
            break;
        }
        
    }    

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
                        Debug.Log("click on cube1");
                        app.Notify("Toggle", cubesList[0]);
                        break;
                    case "Cube2":
                        Debug.Log("click on cube2");
                        app.Notify("Toggle", cubesList[1]);
                        break;
                    case "Sphere1":
                        Debug.Log("click on sphere1");
                        break;
                    case "Sphere2":
                        Debug.Log("click on sphere2");
                        break;
                }

            }
        }
    }

    public void EnviarMensaje(string texto)
    {
        string [] words = texto.Split(" ");
        if (words[0] == "Cubo1") app.Notify(words[1], cubesList[0]);
        if (words[0] == "Cubo2") app.Notify(words[1], cubesList[1]);
        if (words[0] == "Esfera1") app.Notify(words[1], spheresList[0]);
        if (words[0] == "Esfera2") app.Notify(words[1], spheresList[1]);
    }

    public void SumeScore(int sume)
    {
        app.model.score += 1;
        int score = app.model.score;
        textsList[0].GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }


}
