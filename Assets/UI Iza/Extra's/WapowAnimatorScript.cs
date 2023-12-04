using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WapowAnimatorScript : MonoBehaviour
{
    public float minSize = 1f;
    public float maxSize = 3f;
    public float animationSpeed = 1f;
    public float rotationSpeed = 180f; // Added rotation speed

    public AudioClip wapowSound; // Add the audio clip variable
    private AudioSource audioSource; // Add the audio source variable

    private float targetScale;
    private bool scalingUp = true;

    private void Start()
    {
        targetScale = maxSize;

        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is not already attached, add it
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        PlayWapowSound();
    }

    private void Update()
    {
        float currentScale = transform.localScale.x;

        float step = Time.deltaTime * animationSpeed;
        float rotationStep = Time.deltaTime * rotationSpeed;

        if (scalingUp)
        {
            currentScale = Mathf.MoveTowards(currentScale, targetScale, step);
            transform.Rotate(Vector3.forward, rotationStep);

            if (Mathf.Approximately(currentScale, targetScale))
            {
                scalingUp = !scalingUp;
                targetScale = minSize;

                // Play the sound when the scaling direction changes

            }
        }
        else
        {
            currentScale = Mathf.MoveTowards(currentScale, targetScale, step);
            transform.Rotate(Vector3.forward, rotationStep);

            if (Mathf.Approximately(currentScale, targetScale))
            {
                if (targetScale == minSize)
                {
                    targetScale = 0f;
                }
                else
                {
                    scalingUp = !scalingUp;
                }
            }
        }

        transform.localScale = new Vector3(currentScale, currentScale, 1f);

        if (targetScale == 0f && Mathf.Approximately(currentScale, targetScale))
        {
            gameObject.SetActive(false);
        }
    }

    // Function to play the wapow sound
    private void PlayWapowSound()
    {
        if (wapowSound != null && audioSource != null)
        {
            // Play the sound through the AudioSource component
            audioSource.PlayOneShot(wapowSound);
        }
    }
}