using System;
using System.Collections.Generic;
using UnityEngine;

public class Model : Elemento
{
    public float fuerzaDeAtraccion = 5.674f;    
    public Dictionary<string, bool> attractorActivado = new Dictionary<string, bool>();
    public Dictionary<string, int> attractorHitsNeeded= new Dictionary<string, int>();

}
