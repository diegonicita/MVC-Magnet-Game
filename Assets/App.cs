using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all elements in this application.
public class Elemento : MonoBehaviour
{
    // Gives access to the application and all instances.
    public App app { get { return GameObject.FindObjectOfType<App>(); } }
}

public class App : MonoBehaviour
{
    public Rutas [] routes;
    public Controller [] controllers;
    public Model model;
    public View views;

    // Iterates all Controllers and delegates the notification data
    // This method can easily be found because every class is “Element” and has an “app” instance.

    public void Notify(string p_event_path, Object p_target, params object[] p_data)
    {
        Controller[] controller_list = GetAllControllers();
        foreach (Controller c in controller_list)
        {
            //Debug.Log(p_event_path);
            c.OnNotification(p_event_path, p_target, p_data);
        }
    }

    // Fetches all scene Controllers.
    public Controller[] GetAllControllers() {               

        return controllers;

    }

}