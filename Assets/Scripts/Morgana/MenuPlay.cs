using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuPlay : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject creditsCanvas;

    public void StartGame()
    {
        Debug.Log("start");
    }

    public void Credits()
    {
        menuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void BackToMenu()
    {
        creditsCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }
}
