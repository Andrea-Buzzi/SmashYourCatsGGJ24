using UnityEngine;
using System.Collections;

public class ObjectMovementChecker : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public float stopThreshold = 0.1f;
    public AudioSource crashAudio;

    private bool movementStarted = false;
    private bool isInWinZone = false;
    public bool canShowCanvas = true;
    private float previousVelocityMagnitude = 0f;
    private GameManager gameManager;

    void Start()
    {
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    void Update()
    {
        if (!canShowCanvas) return;

        CheckMovement();
    }

    private void CheckMovement()
    {
        if (!movementStarted && ObjMovement.StartForce)
        {
            movementStarted = true;
        }

        float currentVelocityMagnitude = rb.velocity.magnitude;

        if (movementStarted)
        {
            if (isInWinZone && currentVelocityMagnitude < stopThreshold && previousVelocityMagnitude > stopThreshold)
            {
                ShowWinCanvas();
            }
            else if (!isInWinZone && currentVelocityMagnitude < stopThreshold && previousVelocityMagnitude > stopThreshold)
            {
                ShowLoseCanvas();
            }
        }

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
            if (gameManager != null) 
            {
                gameManager.UpdateScore(true);
            }
        }
    }

    private void ShowLoseCanvas()
    {
        if (loseCanvas != null && canShowCanvas)
        {
            canShowCanvas = false;
            StartCoroutine(ShowLoseCanvasAfterSound());
        }
    }

    private IEnumerator ShowLoseCanvasAfterSound()
    {
        if (crashAudio != null)
        {
            crashAudio.Play();
            yield return new WaitForSeconds(crashAudio.clip.length);
        }

        loseCanvas.SetActive(true);
        if (gameManager != null) 
        {
            gameManager.UpdateScore(false);
        }
    }

    public void ResetGameStates()
    {
        movementStarted = false;
        isInWinZone = false;
        canShowCanvas = true;
        rb.velocity = Vector2.zero;
    }
}