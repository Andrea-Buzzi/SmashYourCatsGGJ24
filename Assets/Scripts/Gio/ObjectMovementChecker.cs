using UnityEngine;

public class ObjectMovementChecker : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public float stopThreshold = 0.1f;

    private bool movementStarted = false;
    private bool isInWinZone = false;
    private bool canShowCanvas = true;
    
    private float previousVelocityMagnitude = 0f; // Add this as a private field

    void Start()
    {
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }

    void Update()
    {
        if (!canShowCanvas) return;

        CheckMovement();
    }

    private void CheckMovement()
    {
        // Check for movement start
        if (!movementStarted && ObjMovement.StartForce)
        {
            movementStarted = true;
        }

        // Store the current velocity magnitude for comparison in the next frame
        float currentVelocityMagnitude = rb.velocity.magnitude;

        // Check for stopping conditions
        if (movementStarted)
        {
            // Check if the object is in the win zone and has come to a stop
            if (isInWinZone && currentVelocityMagnitude < stopThreshold && previousVelocityMagnitude > stopThreshold)
            {
                ShowWinCanvas();
            }
            // Check if the object is not in the win zone but has come to a stop
            else if (!isInWinZone && currentVelocityMagnitude < stopThreshold && previousVelocityMagnitude > stopThreshold)
            {
                ShowLoseCanvas();
            }
        }

        // Update previousVelocityMagnitude for the next frame
        previousVelocityMagnitude = currentVelocityMagnitude;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ObjWin")
        {
            isInWinZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ObjWin")
        {
            isInWinZone = false;
        }
    }

    private void ShowWinCanvas()
    {
        if (winCanvas != null && canShowCanvas)
        {
            winCanvas.SetActive(true);
            canShowCanvas = false;
        }
    }

    private void ShowLoseCanvas()
    {
        if (loseCanvas != null && canShowCanvas)
        {
            loseCanvas.SetActive(true);
            canShowCanvas = false;
        }
    }

    public void ResetGameStates()
    {
        movementStarted = false;
        isInWinZone = false;
        canShowCanvas = true;
        rb.velocity = Vector2.zero; // Reset the Rigidbody's velocity
    }
}