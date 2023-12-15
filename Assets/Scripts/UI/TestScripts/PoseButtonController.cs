using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class PoseButtonController : MonoBehaviour
{

    //[SerializeField] private WapowAnimatorScript wapowanimator01;
    //[SerializeField] private WapowAnimatorScript wapowanimator02;

    [SerializeField] private GameObject poseImage;
    [SerializeField] private GameObject exitButton;

    [SerializeField] private float xPosSelected;
    [SerializeField] private float yPosUp;
    [SerializeField] private float yPosDown;

    [SerializeField] private float originalYPos;

    [SerializeField] private int animId;

    private Vector3 initialPoseImageScale;
    private Vector3 initialExitButtonScale;

    public bool isOpened = false;
    private static PoseButtonController[] allButtons;

    private void Start()
    {
        allButtons = FindObjectsOfType<PoseButtonController>();

        exitButton.SetActive(true);
        exitButton.transform.localScale = Vector3.zero;

        // Store the initial scales for later use in the ResetButtons method
        initialPoseImageScale = poseImage.transform.localScale;
        initialExitButtonScale = exitButton.transform.localScale;
    }

    /*private void OnEnable()
    {
        var player = NetworkClient.localPlayer.gameObject;
        if (player == null)
            Debug.Log("player is null");
        playerManager = player.GetComponent<PlayerManager>();
    }*/

    public void ToggleButtonPress()
    {
        if (isOpened)
        {
            ResetButtons();
            PlayerManager.SetAnimation(1);
        }
        else
        {
            ActivatePose();
            PlayerManager.SetAnimation(animId);
        }

    }

    public void ActivatePose()
    {
        LeanTween.moveLocalY(gameObject, yPosUp, 0.8f);
        LeanTween.scale(poseImage, new Vector3(2.8f, 0.96f, 1.1f), 0.8f);

        LowerOtherButtons();

        isOpened = true;
        //test wapow effect
        /*if (wapowanimator01 && wapowanimator02 != null)
        {
            wapowanimator01.PlayWapow();
            wapowanimator02.PlayWapow();
        }*/

    }

    private void LowerOtherButtons()
    {
        foreach (PoseButtonController otherButton in allButtons)
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
        isOpened = false;
    }

    public void ResetButtons()
    {
        // Reset other buttons
        foreach (PoseButtonController button in allButtons)
        {
            button.ResetButton();
        }
    }

    private void ResetButton()
    {
        LeanTween.moveLocalY(gameObject, originalYPos, 0.8f);
        LeanTween.scale(poseImage, initialPoseImageScale, 0.8f);
        LeanTween.scale(exitButton, initialExitButtonScale, 0.8f);
        isOpened = false;
    }

    public static void CloseAll()
    {
        foreach (PoseButtonController button in allButtons)
        {
            button.isOpened = false;
        }
    }
}
