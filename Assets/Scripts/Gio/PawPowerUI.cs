using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawPowerUI : MonoBehaviour
{
    public PawController pawPower;
    public Slider slider;

    void Start()
    {
        if (slider != null && pawPower != null)
        {
            slider.minValue = 0;
            slider.maxValue = pawPower.GetMaxPower();
            slider.value = pawPower.GetPower();
        }
    }

    void Update()
    {
        if (slider != null && pawPower != null && !pawPower.IsPawMoving())
        {
            slider.value = pawPower.GetPower();
        }
    }
}