using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    const float G = 5.674f;
    private Rigidbody rb;
    public bool activado = false;
    public string particulasTag = "";

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    void FixedUpdate()
    {
        if (activado)
            if (Particula.Particulas != null)
                foreach (Particula p in Particula.Particulas)
                {
                    Attract(p);
                }
    }


    void Attract(Particula objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.GetRigidbody();
        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;
        rbToAttract.AddForce(force);
    }

}