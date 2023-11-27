using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonPoseController : MonoBehaviour
{
    [SerializeField] private GameObject poseImage;
    [SerializeField] private GameObject exitButton;

    [SerializeField] private float xPosSelected;
    [SerializeField] private float yPosUp;
    [SerializeField] private float yPosDown;

    [SerializeField] private float originalYPos;

    private Vector3 initialPoseImageScale;
    private Vector3 initialExitButtonScale;

    private void Start()
    {
        exitButton.SetActive(true);
        exitButton.transform.localScale = Vector3.zero;

        originalYPos = transform.localPosition.y;

        // Store the initial scales for later use in the ResetButtons method
        initialPoseImageScale = poseImage.transform.localScale;
        initialExitButtonScale = exitButton.transform.localScale;
    }

    public void ActivatePose()
    {
        LeanTween.moveLocalY(gameObject, yPosUp, 0.8f);
        LeanTween.scale(poseImage, new Vector3(2.9f, 1.0f, 1.1f), 0.8f);

        LeanTween.scale(exitButton, new Vector3(1.0f, 1.0f, 1.0f), 0.8f);

        LowerOtherButtons();
    }

    private void LowerOtherButtons()
    {
        ButtonPoseController[] otherButtons = FindObjectsOfType<ButtonPoseController>();

        foreach (ButtonPoseController otherButton in otherButtons)
        {
            if (otherButton != this)
            {
                otherButton.Lower();
            }
        }
    }

    private void Lower()
    {
        LeanTween.moveLocalY(gameObject, yPosDown, 0.8f);
        LeanTween.scale(poseImage, new Vector3(2.3f, 0.8f, 0.9f), 0.8f);
        LeanTween.scale(exitButton, new Vector3(0.0f, 0.0f, 0.0f), 0.8f);
    }

    public void ResetButtons()
    {
        LeanTween.moveLocalY(gameObject, originalYPos, 0.8f);
        LeanTween.scale(poseImage, initialPoseImageScale, 0.8f);
        LeanTween.scale(exitButton, initialExitButtonScale, 0.8f);

        // Reset other buttons
        ButtonPoseController[] allButtons = FindObjectsOfType<ButtonPoseController>();

        foreach (ButtonPoseController button in allButtons)
        {
            if (button != this)
            {
                button.ResetButton();
            }
        }
    }

    private void ResetButton()
    {
        LeanTween.moveLocalY(gameObject, originalYPos, 0.8f);
        LeanTween.scale(poseImage, initialPoseImageScale, 0.8f);
        LeanTween.scale(exitButton, initialExitButtonScale, 0.8f);
    }
}
