using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterToPose : MonoBehaviour
{
    [SerializeField] private CharacterPickerLean characterPickerLean; // Reference to CharacterPickerLean

    [SerializeField] private TextMeshProUGUI text1; // Reference to the first TextMeshPro text component
    [SerializeField] private TextMeshProUGUI text2; // Reference to the second TextMeshPro text component

    [SerializeField] GameObject characterButtons;
    [SerializeField] GameObject backButton;

    [SerializeField] private GameObject poseBtns;

    [SerializeField] GameObject poseButton01;
    [SerializeField] GameObject poseButton02;
    [SerializeField] GameObject poseButton03;
    [SerializeField] GameObject poseButton04;

    public void CharacterToPosePanel()
    {
        StartCoroutine(SwitchRoutine());
    }

    public void PoseToCharacterPanel()
    {
        StartCoroutine(SwitchBackRoutine());
    }

    private IEnumerator SwitchRoutine()
    {
        // Call the Close method from CharacterPickerLean
        if (characterPickerLean != null)
        {
            characterPickerLean.Close();
        }

        yield return new WaitForSeconds(.4f);

        StartCoroutine(MorphRoutine(0.6f));

        LeanTween.moveLocal(characterButtons, new Vector3(0, -480, 0), 0.8f).setEaseInBack();

        yield return new WaitForSeconds(0.8f);

        StopCoroutine(MorphRoutine(0.6f));
        
        yield return new WaitForSeconds(.6f);

        LeanTween.moveLocal(backButton, new Vector3(-800, 400, 0), 0.8f).setEaseInBack();

        //poseButton01.transform.localScale = Vector3.zero;
        //poseButton02.transform.localScale = Vector3.zero;
        //poseButton03.transform.localScale = Vector3.zero;
        //poseButton04.transform.localScale = Vector3.zero;

        //LeanTween.moveLocal(poseBtns, new Vector3(0, -70, 0), 0.8f);

        yield return new WaitForSeconds(.2f);

        LeanTween.moveLocal(poseButton01, new Vector3(-480, -290, 0), 0.4f).setEaseOutBack();

        yield return new WaitForSeconds(.4f);

        LeanTween.moveLocal(poseButton02, new Vector3(-160, -240, 0), 0.4f).setEaseOutBack();

        yield return new WaitForSeconds(.4f);

        LeanTween.moveLocal(poseButton03, new Vector3(160, -315, 0), 0.4f).setEaseOutBack();

        yield return new WaitForSeconds(.4f);

        LeanTween.moveLocal(poseButton04, new Vector3(480, -290, 0), 0.4f).setEaseOutBack();
    }

    private IEnumerator SwitchBackRoutine()
    {
        // Call the Close method from CharacterPickerLean
        //if (characterPickerLean != null)
        //{
        //    characterPickerLean.Close();
        //}

        yield return new WaitForSeconds(.2f);

        LeanTween.moveLocal(backButton, new Vector3(-1000, 400, 0), 0.8f).setEaseOutBack();

        yield return new WaitForSeconds(.2f);

        LeanTween.moveLocal(poseButton04, new Vector3(480, -915, 0), 0.4f).setEaseInBack();

        yield return new WaitForSeconds(.4f);

        LeanTween.moveLocal(poseButton03, new Vector3(160, -940, 0), 0.4f).setEaseInBack();

        yield return new WaitForSeconds(.4f);

        LeanTween.moveLocal(poseButton02, new Vector3(-160, -865, 0), 0.4f).setEaseInBack();

        yield return new WaitForSeconds(.4f);

        LeanTween.moveLocal(poseButton01, new Vector3(-480, -915, 0), 0.4f).setEaseInBack();

        StartCoroutine(MorphbackRoutine(0.6f));

        yield return new WaitForSeconds(.8f);

        StopCoroutine(MorphbackRoutine(0.6f));

        //poseButton01.transform.localScale = Vector3.zero;
        //poseButton02.transform.localScale = Vector3.zero;
        //poseButton03.transform.localScale = Vector3.zero;
        //poseButton04.transform.localScale = Vector3.zero;

        //LeanTween.moveLocal(poseBtns, new Vector3(0, -70, 0), 0.8f);

        yield return new WaitForSeconds(.2f);

        LeanTween.moveLocal(characterButtons, new Vector3(0, 195, 0), 0.8f).setEaseOutBack();

    }

    private IEnumerator MorphRoutine(float duration)
    {
        float timeElapsed = 0f;

        Color startColor1 = text1.color;
        Color endColor1 = new Color(startColor1.r, startColor1.g, startColor1.b, 0f);

        Color startColor2 = text2.color;
        Color endColor2 = new Color(startColor2.r, startColor2.g, startColor2.b, 1f);

        // Fade out the alpha of the first text component
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            text1.color = Color.Lerp(startColor1, endColor1, t);
            yield return null;
            timeElapsed += Time.deltaTime;
        }

        text1.color = endColor1; // Ensure final color is accurate

        // Reset timeElapsed for the second phase
        timeElapsed = 0f;

        // Fade in the alpha of the second text component
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            text2.color = Color.Lerp(startColor2, endColor2, t);
            yield return null;
            timeElapsed += Time.deltaTime;
        }

        text2.color = endColor2; // Ensure final color is accurate
    }

    private IEnumerator MorphbackRoutine(float duration)
    {
        float timeElapsed = 0f;

        Color startColor1 = text1.color;
        Color endColor1 = new Color(startColor1.r, startColor1.g, startColor1.b, 1f);

        Color startColor2 = text2.color;
        Color endColor2 = new Color(startColor2.r, startColor2.g, startColor2.b, 0f);

        // Fade in the alpha of the second text component
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            text2.color = Color.Lerp(startColor2, endColor2, t);
            yield return null;
            timeElapsed += Time.deltaTime;
        }

        text2.color = endColor2; // Ensure final color is accurate

        // Reset timeElapsed for the second phase
        timeElapsed = 0f;

        // Fade out the alpha of the first text component
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            text1.color = Color.Lerp(startColor1, endColor1, t);
            yield return null;
            timeElapsed += Time.deltaTime;
        }

        text1.color = endColor1; // Ensure final color is accurate

    }
}
