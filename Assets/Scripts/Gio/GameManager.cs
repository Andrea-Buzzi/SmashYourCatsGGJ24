using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ObjectMovementChecker objectMovementChecker;
    public GameObject paw;
    public GameObject objectToReset;
    public Slider slider;
    public PawController pawController;

    private Vector3 originalPawPosition;
    private Vector3 originalObjectPosition;
    private float originalSliderValue;

    void Start()
    {
        originalPawPosition = paw.transform.position;
        originalObjectPosition = objectToReset.transform.position;
        originalSliderValue = slider.value;
    }

    public void ResetGame()
    {
        paw.transform.position = originalPawPosition;
        objectToReset.transform.position = originalObjectPosition;
        slider.value = originalSliderValue;

        objectMovementChecker.ResetGameStates();
        pawController.ResetPower();  // Reset the power

        if (objectMovementChecker.winCanvas != null) 
            objectMovementChecker.winCanvas.SetActive(false);
        if (objectMovementChecker.loseCanvas != null) 
            objectMovementChecker.loseCanvas.SetActive(false);
    }

}