using UnityEngine;
using UnityEngine.InputSystem;

public class PictureInteraction : MonoBehaviour
{
    public GameObject interactionPrompt;
    public GameObject informationPanel;
    public InputManager inputManager;

    private bool playerNearby = false;

    void Start()
    {
        interactionPrompt.SetActive(false);
        informationPanel.SetActive(false);
    }

    void Update()
    {
        if (informationPanel.activeSelf)
        {
            if (Keyboard.current != null &&
                (Keyboard.current.eKey.wasPressedThisFrame ||
                 Keyboard.current.escapeKey.wasPressedThisFrame))
            {
                CloseInformation();
            }

            return;
        }

        if (playerNearby && Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            OpenInformation();
        }
    }

    private void OpenInformation()
    {
        informationPanel.SetActive(true);
        interactionPrompt.SetActive(false);

        inputManager.enabled = false;
    }

    private void CloseInformation()
    {
        informationPanel.SetActive(false);

        inputManager.enabled = true;

        if (playerNearby)
        {
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            if (!informationPanel.activeSelf)
            {
                interactionPrompt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            interactionPrompt.SetActive(false);
        }
    }
}
