using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject paw;
    public Slider slider;
    public PawController pawController;

    private Vector3 originalPawPosition;
    private Vector3 originalObjectPosition;
    private float originalSliderValue;
    
    public ObjectSpawner objectSpawner;
    private GameObject objectToReset;
    private ObjectMovementChecker objectMovementChecker;
    
    private int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        originalPawPosition = paw.transform.position;
        originalSliderValue = slider.value;

        GameObject spawnedObject = objectSpawner.SpawnRandomObject();
        AssignObjectMovementChecker(spawnedObject);
        objectToReset = spawnedObject; // Assign the spawned object to objectToReset
        if (spawnedObject != null)
        {
            originalObjectPosition = spawnedObject.transform.position; // Set the original position
        }
    }

    public void ResetGame()
    {
        paw.transform.position = originalPawPosition;
        if (objectToReset != null)
        {
            objectToReset.transform.position = originalObjectPosition; // Reset to original position
        }
        slider.value = originalSliderValue;

        pawController.ResetPower();
        if (objectMovementChecker != null)
        {
            objectMovementChecker.ResetGameStates();
        }

        if (objectMovementChecker != null && objectMovementChecker.winCanvas != null) 
            objectMovementChecker.winCanvas.SetActive(false);
        if (objectMovementChecker != null && objectMovementChecker.loseCanvas != null) 
            objectMovementChecker.loseCanvas.SetActive(false);
        
        pawController.colliderTouched = false;

        GameObject spawnedObject = objectSpawner.SpawnRandomObject();
        AssignObjectMovementChecker(spawnedObject);
        objectToReset = spawnedObject; // Update the reference to the new object
        if (spawnedObject != null)
        {
            originalObjectPosition = spawnedObject.transform.position; // Update the original position
        }
    }

    private void AssignObjectMovementChecker(GameObject spawnedObject)
    {
        if (spawnedObject != null)
        {
            objectMovementChecker = spawnedObject.GetComponent<ObjectMovementChecker>();
            if (objectMovementChecker == null)
            {
                Debug.LogWarning("ObjectMovementChecker component not found on the spawned object.");
            }
        }
    }
    
    public void UpdateScore(bool won)
    {
        if (won)
        {
            score++;
        }
        else
        {
            score = 0;
        }
        scoreText.text = score.ToString();
    }
}