using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Elemento
{
    public GameObject obj;
    protected Renderer rend;

    // Handles the ball hit event
    virtual public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
       // Debug.Log(p_event_path);
    }

    public void Start()
    {
        rend = obj.GetComponent<Renderer>();
    }
 
}
