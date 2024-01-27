using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawController : MonoBehaviour
{
    public float Intensity;
    public float Power;
    public ObjMovement ObjRef;

    private bool colliderTouched = false;
    private bool justPressed;
    private Transform initialTrans;

    // Start is called before the first frame update
    void Start()
    {
        ObjRef = FindObjectOfType<ObjMovement>();
        initialTrans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CalculatePower();
            print(Power);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            justPressed = true;
        }

        if (!colliderTouched && justPressed)
        {
            transform.position -= new Vector3( Intensity * Power * 0.01f, 0, 0);
        }
    }

    void CalculatePower()
    {
        Power += 2;
    }

    public float GetPower()
    {
        return Power;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            colliderTouched = true;
            print(collision.transform.tag);
            ObjMovement.StartForce = true;
            transform.position = initialTrans.position;
            //colliderTouched = false;
            //justPressed = false;
        }
    }
}
