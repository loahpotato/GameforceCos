using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterButtonController : MonoBehaviour
{
    [SerializeField] private GameObject imageObject01;
    [SerializeField] private GameObject imageObject02;
    [SerializeField] private GameObject imageObject03;

    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject infoText;

    [SerializeField] private GameObject poseImage;
    [SerializeField] private GameObject nameText;

    [SerializeField] private Image image1;
    [SerializeField] private Image image2;

    [SerializeField] private GameObject closeButton;

    [SerializeField] private Animator animLock01, animLock02, animLock03;

    private Button thisButton;

    public bool isOpened = false;

    private void Start()
    {
        thisButton = GetComponent<Button>();
        InitializeUI();
    }

    public void ToggleButtonPress()
    {
        if (isOpened)
        {
            Close();
        }
        else
        {
            OpenBigger();
        }

        isOpened = !isOpened;
    }

    private void InitializeUI()
    {
        continueButton.transform.localScale = Vector3.zero;
        infoText.transform.localScale = Vector3.zero;
        closeButton.transform.localScale = Vector3.zero;
    }

    public void MorphImages(float duration)
    {
        StartCoroutine(MorphRoutine(0.6f));
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

    public void OpenBigger()
    {
        animLock01.enabled = false;
        animLock02.enabled = false;
        animLock03.enabled = false;

        //thisButton.enabled = false;

        // LeanTween animations for scaling and moving UI elements
        LeanTween.scale(gameObject, new Vector3(1.29f, 5.18f, 1.0f), 0.8f).setEaseOutBack();
        LeanTween.scale(continueButton, new Vector3(1.2f, 0.5f, 1.0f), 0.8f);
        //LeanTween.scale(infoText, new Vector3(1.7f, 0.5f, 1.0f), 0.8f);
        LeanTween.moveLocal(poseImage, new Vector3(-5, 17, 0), 0.8f);
        LeanTween.moveLocal(nameText, new Vector3(0, -12, 0), 0.8f);

        LeanTween.scale(closeButton, new Vector3(0.6f, 0.45f, 1.0f), 0.8f);

        MorphImages(0.6f);

        // LeanTween animations for scaling smaller image objects
        Smaller(imageObject01);
        Smaller(imageObject02);
        Smaller(imageObject03);
    }

    private void Smaller(GameObject obj)
    {
        LeanTween.scale(obj, new Vector3(1.14f, 4.58f, 1.0f), 0.8f);
    }

    public void Close()
    {
        if (isOpened == true)
        {
            LeanTween.scale(gameObject, new Vector3(1.2f, 4.8f, 1.2f), 0.8f).setEaseInBack();
            LeanTween.scale(continueButton, Vector3.zero, 0.8f);
            //LeanTween.scale(infoText, Vector3.zero, 0.8f);
            LeanTween.moveLocal(poseImage, new Vector3(-5, 12, 1), 0.8f);
            LeanTween.moveLocal(nameText, new Vector3(0, -21, 0), 0.8f);

            LeanTween.scale(closeButton, Vector3.zero, 0.8f);

            // Reverse the MorphImages effect
            StartCoroutine(ReverseMorphRoutine(0.6f));

            // Reverse the LeanTween animations for scaling smaller image objects
            Bigger(imageObject01);
            Bigger(imageObject02);
            Bigger(imageObject03);

            //thisButton.enabled = true;

            animLock01.enabled = true;
            animLock02.enabled = true;
            animLock03.enabled = true;
        }


    }

    private void Bigger(GameObject obj)
    {
        LeanTween.scale(obj, new Vector3(1.2f, 4.8f, 1.2f), 0.8f);
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
