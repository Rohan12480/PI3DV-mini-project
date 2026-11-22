using UnityEngine;
using UnityEngine.InputSystem;

public class PictureInteraction : MonoBehaviour
{
    public GameObject interactionPrompt;

    private bool playerNearby = false;

    void Start()
    {
        interactionPrompt.SetActive(false);
    }

    void Update()
    {
        if (playerNearby && Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("Picture interaction activated!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            interactionPrompt.SetActive(true);
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