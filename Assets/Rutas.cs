using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class rutas : Elemento
{
    public Controller controlador;
    public string [] path;
    //public Func<string, int> [] met;
    MethodInfo [] met;

    // Start is called before the first frame update
    void Start()
    {
        // met = new Func<string, int>[10];
        met = new MethodInfo[10];
        int n = 0;
        foreach(string p in path)
        {
            Usar(n, p);
            n++;
        }
    }

    public void Usar(int n, string path)
    {
        //Get the method information using the method info class
        MethodInfo mi = controlador.GetType().GetMethod(path);
        met[n] = mi;        
    }

    public void ejecutar(int n)
    {
        string s = "";
        met[n].Invoke(controlador, new object[] { s });
    }

    public void ejecutarRuta(string ruta)
    {       
        string s = "";
        int a = Array.FindIndex(path, x => x.Contains(ruta));
        //Debug.Log(a);
        met[a].Invoke(controlador, new object[] { s });
    }


    
}
