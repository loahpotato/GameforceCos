using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeExperiment : MonoBehaviour
{
    public GameObject scrollbar;
    public float buttonScaleMultiplier = 1.2f;
    private float scrollPos = 0;
    private float[] buttonPositions;
    private bool isRunning = false;
    private float timer;
    private int selectedButtonIndex;

    void Start()
    {
        buttonPositions = new float[transform.childCount];
        float distance = 1f / (buttonPositions.Length - 1f);

        // Set initial positions for the buttons
        for (int i = 0; i < buttonPositions.Length; i++)
        {
            buttonPositions[i] = distance * i;
        }
    }

    void Update()
    {
        if (isRunning)
        {
            AdjustTransition();
            timer += Time.deltaTime;

            if (timer > 1f)
            {
                timer = 0;
                isRunning = false;
            }
        }

        float distance = 1f / (buttonPositions.Length - 1f);

        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < buttonPositions.Length; i++)
            {
                if (scrollPos < buttonPositions[i] + (distance / 2) && scrollPos > buttonPositions[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, buttonPositions[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < buttonPositions.Length; i++)
        {
            if (scrollPos < buttonPositions[i] + (distance / 2) && scrollPos > buttonPositions[i] - (distance / 2))
            {
                Debug.LogWarning("Current Selected Button: " + i);
                Transform currentButton = transform.GetChild(i);

                // Adjust scale of the selected button
                currentButton.localScale = Vector2.Lerp(currentButton.localScale, Vector2.one * buttonScaleMultiplier, 0.1f);

                // Adjust scale of other buttons
                for (int j = 0; j < buttonPositions.Length; j++)
                {
                    if (j != i)
                    {
                        Transform otherButton = transform.GetChild(j);

                        // Adjust scale of other buttons
                        otherButton.localScale = Vector2.Lerp(otherButton.localScale, Vector2.one * 0.8f, 0.1f);
                    }
                }

                // Store the selected button index
                selectedButtonIndex = i;
                isRunning = true;
            }
        }
    }

    private void AdjustTransition()
    {
        float distance = 1f / (buttonPositions.Length - 1f);

        // Adjust scrollbar value during animation
        scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, buttonPositions[selectedButtonIndex], 1f * Time.deltaTime);
    }
}
