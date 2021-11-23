using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : Controller
{
    private GameObject[] objs;

    private void Awake()
    {
        objs = app.views.GetComponent<ViewSampleScene>().particles;        
    }
    
    public void GetAttracted(GameObject objAttractor)
    {
        Rigidbody rbToAttract = objAttractor.GetComponent<Rigidbody>();
        Vector3 direction;
        float forceMagnitude;
        Vector3 force;

        foreach (GameObject o in objs)
        {
            direction = -o.GetComponent<Rigidbody>().position + objAttractor.transform.position;
            float distance = direction.magnitude;
            if (distance == 0f)
                continue;
            forceMagnitude = app.model.fuerzaDeAtraccion * (o.GetComponent<Rigidbody>().mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
            force = direction.normalized * forceMagnitude;
            o.GetComponent<Rigidbody>().AddForce(force);
        }
        }
    }

