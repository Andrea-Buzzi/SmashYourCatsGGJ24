using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuPlay : MonoBehaviour
{
    public TextMeshProUGUI playText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        playText.color = Color.white;
    }

    public void StartGame()
    {
        Debug.Log("start");
    }
}
