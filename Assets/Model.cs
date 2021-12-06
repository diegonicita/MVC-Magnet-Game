using System;
using System.Collections.Generic;
using UnityEngine;

public class Model : Elemento
{
    public float fuerzaDeAtraccion = 5.674f;    
    public Dictionary<string, bool> attractorActivado = new Dictionary<string, bool>();
    public Dictionary<string, int> attractorCollisionsToWin = new Dictionary<string, int>();
    public int score = 0;

    private void Start()
    {
        attractorActivado.Add("Cube1", false);
        attractorCollisionsToWin.Add("Cube1", 3);
        attractorActivado.Add("Cube2", false);
        attractorCollisionsToWin.Add("Cube2", 3);        
    }

    public void RestaCollisionsToWin(GameObject o, int puntos)
    {
        if (o != null)
        attractorCollisionsToWin[o.name] = attractorCollisionsToWin[o.name] - 1;       
    }

    public int GetCollisionsToWin(GameObject o)
    {
        int r = 0;
        if (o != null)
        { r = attractorCollisionsToWin[o.name]; }
        return r;
    }

}
