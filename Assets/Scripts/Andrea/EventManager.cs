using System.Collections;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnPawCollided();
    public static event OnPawCollided OnPawCollision;

    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
