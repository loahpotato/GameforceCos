using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeExperiment : MonoBehaviour
{
    public Color[] colors;
    public GameObject scrollbar, imageContent;
    public float buttonScaleMultiplier = 1.2f; // Variable to adjust button scale from the Inspector
    private float scroll_pos = 0;
    float[] pos;
    private bool runIt = false;
    private float time;
    private Button takeTheBtn;
    private int btnNumber;

    void Start()
    {
        // Initialization code here if needed

        // Disable interactability for all buttons at the start
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        if (runIt)
        {
            GecisiDuzenle(distance, pos, takeTheBtn);
            time += Time.deltaTime;

            if (time > 1f)
            {
                time = 0;
                runIt = false;
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                Debug.LogWarning("Current Selected Level" + i);
                Transform currentButton = transform.GetChild(i);

                // Adjust scale of the selected button
                currentButton.localScale = Vector2.Lerp(currentButton.localScale, new Vector2(buttonScaleMultiplier, buttonScaleMultiplier), 0.1f);

                // Enable interaction for the selected button
                currentButton.GetComponent<Button>().interactable = true;

                // Adjust scale and color of other buttons
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        Transform otherButton = transform.GetChild(j);
                        Image otherImage = imageContent.transform.GetChild(j).GetComponent<Image>();

                        // Disable interactability for other buttons
                        otherButton.GetComponent<Button>().interactable = false;

                        // Adjust scale and color of other buttons
                        otherImage.color = colors[0];
                        otherImage.transform.localScale = Vector2.Lerp(otherImage.transform.localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        otherButton.localScale = Vector2.Lerp(otherButton.localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }

    private void GecisiDuzenle(float distance, float[] pos, Button btn)
    {
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[btnNumber], 1f * Time.deltaTime);
            }
        }

        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            btn.transform.name = ".";
        }
    }

    public void WhichBtnClicked(Button btn)
    {
        // Reset the interactability of all buttons
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

        btn.transform.name = "clicked";
        for (int i = 0; i < btn.transform.parent.transform.childCount; i++)
        {
            if (btn.transform.parent.transform.GetChild(i).transform.name == "clicked")
            {
                btnNumber = i;
                takeTheBtn = btn;
                time = 0;
                scroll_pos = (pos[btnNumber]);
                runIt = true;
            }
        }
    }
}
