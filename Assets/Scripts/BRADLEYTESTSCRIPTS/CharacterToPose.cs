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

    [SerializeField] GameObject poseButton01;
    [SerializeField] GameObject poseButton02;
    [SerializeField] GameObject poseButton03;
    [SerializeField] GameObject poseButton04;

    public void CharacterToPosePanel()
    {
        StartCoroutine(SwitchRoutine());
    }

    private IEnumerator SwitchRoutine()
    {
        // Call the Close method from CharacterPickerLean
        if (characterPickerLean != null)
        {
            characterPickerLean.Close();
        }

        yield return new WaitForSeconds(.8f);

        StartCoroutine(MorphRoutine(2));

        yield return new WaitForSeconds(2f);

        StopCoroutine(MorphRoutine(2));
        
        yield return new WaitForSeconds(.8f);

        LeanTween.moveLocal(backButton, new Vector3(-800, 400, 0), 0.8f);

        characterButtons.transform.LeanScale(new Vector3(0.0f, 0.0f, 0.0f), 0.8f);

        poseButton01.transform.localScale = Vector3.zero;
        poseButton02.transform.localScale = Vector3.zero;
        poseButton03.transform.localScale = Vector3.zero;
        poseButton04.transform.localScale = Vector3.zero;

        yield return new WaitForSeconds(.8f);

        poseButton01.transform.LeanScale(new Vector3(1.2f, 4.8f, 1.0f), 0.8f);

        yield return new WaitForSeconds(.8f);

        poseButton02.transform.LeanScale(new Vector3(1.2f, 4.8f, 1.0f), 0.8f);

        yield return new WaitForSeconds(.8f);

        poseButton03.transform.LeanScale(new Vector3(1.2f, 4.8f, 1.0f), 0.8f);

        yield return new WaitForSeconds(.8f);

        poseButton04.transform.LeanScale(new Vector3(1.2f, 4.8f, 1.0f), 0.8f);
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
}
