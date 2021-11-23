using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particula : MonoBehaviour
{
    public static List<Particula> Particulas;
    private Rigidbody rb;

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        if (Particulas == null) Particulas = new List<Particula>();
        Particulas.Add(this);
    }

    void OnDisable()
    {
        Particulas.Remove(this);
    }

}
