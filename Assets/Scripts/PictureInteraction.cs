using UnityEngine;

public class PictureInteraction : MonoBehaviour
{
    public string artworkDescription;

    private bool playerNearby = false;
    private MuseumUIController uiController;

    void Start()
    {
        uiController = FindFirstObjectByType<MuseumUIController>();

        if (uiController == null)
        {
            Debug.LogError("MuseumUIController was not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            if (uiController != null && !uiController.IsOpen)
            {
                uiController.ShowPrompt(this);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;

            if (uiController != null)
            {
                uiController.HidePrompt(this);
            }
        }
    }

    public void ShowPromptIfNearby()
    {
        if (playerNearby && uiController != null)
        {
            uiController.ShowPrompt(this);
        }
    }
}