using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking.Types;

public class CharacterButtonController : MonoBehaviour
{
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject infoText;

    [SerializeField] private GameObject poseImage;
    [SerializeField] private GameObject nameText;

    [SerializeField] private Image image1;
    [SerializeField] private Image image2;

    [SerializeField] private GameObject closeButton;

    [SerializeField] private Animator animLock01, animLock02, animLock03;
    [SerializeField] private int characterId;

    private Button thisButton;
    private CharacterButtonController[] allButtons;
    private PlayerManager currentPlayer;

    public bool isOpened = false;
    public bool isLocked = false;

    private void Awake()
    {
        currentPlayer = PlayerManager.GetCurrentPlayer();
    }

    private void Start()
    {
        allButtons = FindObjectsOfType<CharacterButtonController>();
        thisButton = GetComponent<Button>();
        InitializeUI();
    }

    public void ToggleButtonPress()
    {
        if(isLocked)
        {
            PlayerManager.SetCharacterAnimation(currentPlayer, characterId);
            ResetAll();
        }
        else
        {
            if (isOpened)
            {
                ResetAll();
            }
            else
            {
                Bigger();
                PlayerManager.SetCharacterAnimation(currentPlayer, characterId);
            }
        }
        

        //isOpened = !isOpened;
    }

    private void InitializeUI()
    {
        if(!isLocked)
        {
            continueButton.transform.localScale = Vector3.zero;
            infoText.transform.localScale = Vector3.zero;
            closeButton.transform.localScale = Vector3.zero;
        }
        
    }

    public void MorphImages(float duration)
    {
        StartCoroutine(MorphRoutine(duration));
    }

    private IEnumerator MorphRoutine(float duration)
    {
        float timeElapsed = 0f;

        //Color startColor1 = image1.color;
        //Color endColor1 = new Color(startColor1.r, startColor1.g, startColor1.b, 0f);

        Color startColor2 = image2.color;
        Color endColor2 = new Color(startColor2.r, startColor2.g, startColor2.b, 1f);

        // Fade out the alpha of the first image
        //while (timeElapsed < duration)
        //{
        //    float t = timeElapsed / duration;
        //    image1.color = Color.Lerp(startColor1, endColor1, t);
        //    yield return null;
        //    timeElapsed += Time.deltaTime;
        //}

        //image1.color = endColor1; // Ensure final color is accurate

        // Reset timeElapsed for the second phase
        timeElapsed = 0f;

        // Fade in the alpha of the second image
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            image2.color = Color.Lerp(startColor2, endColor2, t);
            yield return null;
            timeElapsed += Time.deltaTime;
        }

        image2.color = endColor2; // Ensure final color is accurate
    }

    public void Bigger()
    {
        //animLock01.enabled = false;
        //animLock02.enabled = false;
        //animLock03.enabled = false;

        //thisButton.enabled = false;

        // LeanTween animations for scaling and moving UI elements
        LeanTween.scale(gameObject, new Vector3(1.29f, 5.18f, 1.0f), 0.6f).setEaseOutBack();
        LeanTween.moveLocal(poseImage, new Vector3(-5, 17, 0), 0.6f);
        if (!isLocked) {
            LeanTween.scale(continueButton, new Vector3(1.25f, 0.48f, 1.2f), 0.6f);
            //LeanTween.scale(infoText, new Vector3(1.7f, 0.5f, 1.0f), 0.8f);
            LeanTween.moveLocal(nameText, new Vector3(0, -12, 0), 0.6f);
            LeanTween.scale(closeButton, new Vector3(0.6f, 0.45f, 1.0f), 0.6f);
            MorphImages(0.4f);
        }

        // LeanTween animations for scaling smaller image objects
        foreach (CharacterButtonController otherButton in allButtons)
        {
            if (otherButton != this)
            {
                otherButton.Smaller();
            }
        }
        isOpened= true;
    }

    private void Smaller()
    {
        LeanTween.scale(gameObject, new Vector3(1.14f, 4.58f, 1.0f), 0.6f);
        isOpened = false;
    }

    
    private void ResetButton(CharacterButtonController button)
    {
        LeanTween.scale(button.gameObject, new Vector3(1.2f, 4.8f, 1.2f), 0.6f).setEaseInBack();
        LeanTween.moveLocal(button.poseImage, new Vector3(-5, 12, 0), 0.6f);
        if (!button.isLocked)
        {
            LeanTween.scale(button.continueButton, Vector3.zero, 0.6f);
            //LeanTween.scale(button.infoText, Vector3.zero, 0.8f);
            LeanTween.moveLocal(button.nameText, new Vector3(0, -21, 0), 0.6f);
            LeanTween.scale(button.closeButton, Vector3.zero, 0.8f);
            button.isOpened = false;
            // Reverse the MorphImages effect
            StartCoroutine(button.ReverseMorphRoutine(0.4f));
        }
    }

    // Reverse the LeanTween animations for scaling image objects
    public void ResetAll()
    {
        foreach (CharacterButtonController button in allButtons)
        {
            ResetButton(button);
        }

    }

    private IEnumerator ReverseMorphRoutine(float duration)
    {
        float timeElapsed = 0f;

        //Color startColor1 = image1.color;
        //Color endColor1 = new Color(startColor1.r, startColor1.g, startColor1.b, 1f);

        Color startColor2 = image2.color;
        Color endColor2 = new Color(startColor2.r, startColor2.g, startColor2.b, 0f);

        // Fade out the alpha of the second image
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            image2.color = Color.Lerp(startColor2, endColor2, t);
            yield return null;
            timeElapsed += Time.deltaTime;
        }

        image2.color = endColor2; // Ensure final color is accurate

        // Reset timeElapsed for the second phase
        timeElapsed = 0f;

        //// Fade in the alpha of the first image
        //while (timeElapsed < duration)
        //{
        //    float t = timeElapsed / duration;
        //    image1.color = Color.Lerp(startColor1, endColor1, t);
        //    yield return null;
        //    timeElapsed += Time.deltaTime;
        //}

        //image1.color = endColor1; // Ensure final color is accurate
    }

        
}
