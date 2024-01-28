using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeTextColor : MonoBehaviour
{
    public TextMeshProUGUI playText;
    private Color hoverColor;
    private Color normalColor;

    void Start()
    {
        hoverColor = Color.white;
        normalColor = new Color(160, 162, 228, 255);
    }

    private void OnMouseOver()
    {
        playText.color = hoverColor;
    }

    private void OnMouseExit()
    {
        playText.color = normalColor;
    }

}
