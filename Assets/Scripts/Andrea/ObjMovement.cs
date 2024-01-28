using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : MonoBehaviour
{
    public PawController PawContRef;
    public static bool StartForce;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PawContRef = FindObjectOfType<PawController>();
    }

    void FixedUpdate()
    {
        if (StartForce)
        {
            rb.AddForce(new Vector2(-PawContRef.GetPower(), 0));
            print("Force: " + PawContRef.GetPower());
        }

        StartForce = false;
    }
}
