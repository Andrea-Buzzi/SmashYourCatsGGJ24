using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PawController : MonoBehaviour
{
    public float Intensity;
    public ObjMovement ObjRef;
    public ObjectMovementChecker IsCanvasEnabled;
    public float MaxPower;

    public bool colliderTouched = false;
    public bool justPressed;
    private Transform initialTrans;
    private float Power;
    
    public GameObject winCanvas;
    public GameObject loseCanvas;
    
    private bool isPawMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        ObjRef = FindObjectOfType<ObjMovement>();
        initialTrans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!winCanvas.activeSelf && !loseCanvas.activeSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Power != MaxPower)
            {
                if (Input.GetMouseButton(0) && !isPawMoving)
                {
                    CalculatePower();
                    print(Power);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    justPressed = true;
                    isPawMoving = true;
                }
            }
            else if(Power >= MaxPower)
            {
                justPressed = true;
                isPawMoving = true;
            }
        

            if (!colliderTouched && justPressed)
            {
                transform.position -= new Vector3( Intensity * Power * 0.01f, 0, 0);
            }
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
        isPawMoving = false;
    }
    
    public bool IsPawMoving()
    {
        return isPawMoving;
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        justPressed = false;
    }
}
