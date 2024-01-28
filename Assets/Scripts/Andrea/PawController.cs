using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawController : MonoBehaviour
{
    public float Intensity;
    public ObjMovement ObjRef;
    public float MaxPower;

    private bool colliderTouched = false;
    private bool justPressed;
    private Transform initialTrans;
    private float Power;

    // Start is called before the first frame update
    void Start()
    {
        ObjRef = FindObjectOfType<ObjMovement>();
        initialTrans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Power != MaxPower)
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
        }
        else
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
        if (Power < MaxPower)
        {
            Power += 2;
        }
        
    }

    public float GetPower()
    {
        return Power;
    }
    
    public float GetMaxPower()
    {
        return MaxPower;
    }
    
    public void ResetPower()
    {
        Power = 0;
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
