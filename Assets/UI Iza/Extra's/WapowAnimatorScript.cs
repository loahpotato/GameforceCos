using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WapowAnimatorScript : MonoBehaviour
{
    public GameObject imageObject;
    public float initialScale = 1.0f;
    public float targetScale = 2.0f;
    public float duration = 1.0f;

    public void PlayWapow()
    {
        // Voeg een voorbeeldafbeelding toe als die nog niet is toegewezen
        if (imageObject == null)
        {
            // Maak een kubus als voorbeeldafbeelding
            imageObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }

        // Schaal de afbeelding naar de initiële schaal
        imageObject.transform.localScale = new Vector3(initialScale, initialScale, initialScale);

        // Start de schaalanimatie
        ScaleImage();
    }

    void ScaleImage()
    {
        // Tween de schaal van de afbeelding van de initiële schaal naar de doelschaal
        LeanTween.scale(imageObject, new Vector3(targetScale, targetScale, targetScale), duration)
            .setEase(LeanTweenType.easeOutBack) // Pas de gewenste easing-functie toe
            .setOnComplete(ResetScale); // Roep ResetScale aan als de animatie is voltooid
    }

    void ResetScale()
    {
        // Wacht even en schaal de afbeelding terug naar de initiële schaal
        LeanTween.scale(imageObject, new Vector3(initialScale, initialScale, initialScale), duration)
            .setEase(LeanTweenType.easeInBack); // Pas de gewenste easing-functie toe
    }
}