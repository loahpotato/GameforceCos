using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class ButtonPoseController : MonoBehaviour
{
    [SerializeField] private GameObject poseImage;
    [SerializeField] private GameObject exitButton;

    [SerializeField] private float xPosSelected;
    [SerializeField] private float yPosUp;
    [SerializeField] private float yPosDown;

    [SerializeField] private float originalYPos;

    [SerializeField] private GameObject poseBtns;
    [SerializeField] private int animId;

    private Vector3 initialPoseImageScale;
    private Vector3 initialExitButtonScale;

    public bool isOpened = false;
    private PlayerManager playerManager;

    private void Start()
    {
        exitButton.SetActive(true);
        exitButton.transform.localScale = Vector3.zero;

        //LeanTween.moveLocal(poseBtns, new Vector3(0, -780, 0), 0.8f);

        //originalYPos = transform.localPosition.y;

        // Store the initial scales for later use in the ResetButtons method
        initialPoseImageScale = poseImage.transform.localScale;
        initialExitButtonScale = exitButton.transform.localScale;
    }

    private void OnEnable()
    {
        Debug.Log("enable pose");
        var player = NetworkClient.localPlayer.gameObject;
        if (player == null)
            Debug.Log("player is null");
        playerManager = player.GetComponent<PlayerManager>();
        playerManager.animNum = 1;
    }

    public void ToggleButtonPress()
    {
        if (isOpened)
        {
            ResetButtons();
            playerManager.animNum = 1;
        }
        else
        {
            ActivatePose();
            playerManager.animNum = animId;
        }

        isOpened = !isOpened;
    }

    public void ActivatePose()
    {
        LeanTween.moveLocalY(gameObject, yPosUp, 0.8f);
        LeanTween.scale(poseImage, new Vector3(2.8f, 0.96f, 1.1f), 0.8f);

        //LeanTween.scale(exitButton, new Vector3(0.62f, 0.44f, 1.0f), 0.8f);

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
        LeanTween.scale(poseImage, new Vector3(2.4f, 0.83f, 0.9f), 0.8f);
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
