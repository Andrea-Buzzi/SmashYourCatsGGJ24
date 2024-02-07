using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems; // Import this namespace

public class ChangeTextColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI playText;
    private Color hoverColor;
    private Color normalColor;

    void Start()
    {
        hoverColor = Color.white;
        normalColor = new Color(160f / 255, 162f / 255, 228f / 255, 1);
    }

    // Implement the interface methods
    public void OnPointerEnter(PointerEventData eventData)
    {
        playText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        playText.color = normalColor;
    }
}
