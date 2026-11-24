using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class MuseumUIController : MonoBehaviour
{
    public GameObject interactionPrompt;
    public GameObject informationPanel;
    public TMP_Text descriptionText;
    public InputManager inputManager;

    private PictureInteraction activePicture;
    public bool IsOpen { get; private set; }

    void Start()
    {
        interactionPrompt.SetActive(false);
        informationPanel.SetActive(false);
        IsOpen = false;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (IsOpen)
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                CloseInformation();
            }
        }
        else if (activePicture != null &&
                 Keyboard.current.eKey.wasPressedThisFrame)
        {
            OpenInformation(activePicture, activePicture.artworkDescription);
        }
    }

    public void ShowPrompt(PictureInteraction picture)
    {
        if (IsOpen) return;

        activePicture = picture;
        interactionPrompt.SetActive(true);
    }

    public void HidePrompt(PictureInteraction picture)
    {
        if (activePicture == picture && !IsOpen)
        {
            interactionPrompt.SetActive(false);
            activePicture = null;
        }
    }

    private void OpenInformation(PictureInteraction picture, string description)
    {
        activePicture = picture;
        interactionPrompt.SetActive(false);
        informationPanel.SetActive(true);
        descriptionText.text = description;

        IsOpen = true;
        inputManager.enabled = false;
    }

    private void CloseInformation()
    {
        informationPanel.SetActive(false);
        IsOpen = false;

        inputManager.enabled = true;

        if (activePicture != null)
        {
            activePicture.ShowPromptIfNearby();
        }
    }
}