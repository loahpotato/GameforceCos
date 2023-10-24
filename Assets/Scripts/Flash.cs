using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flash : MonoBehaviour
{
    public float flashTimelength = .2f;
    //public bool doCameraFlash = false;

    private Image flashImage;
    private float startTime;
    private bool flashing = false;

    void Start()
    {
        flashImage = GetComponent<Image>();
        Color col = flashImage.color;
        col.a = 0.0f;
        flashImage.color = col;
    }

    public void CameraFlash()
    {
        Color col = flashImage.color;
        col.a = 1.0f;
        flashImage.color = col;

        // start time to fade over time
        startTime = Time.time;

        //doCameraFlash = false;       

        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        flashing = true;
        float step = 0.0f;
        Color col = flashImage.color;
        while (flashing)
        {
            step = (Time.time - startTime) / flashTimelength;

            if (step > 1.0f)
            {
                step = 1.0f;
                flashing = false;
            }

            col.a = Mathf.Lerp(1.0f, 0.0f, step);
            flashImage.color = col;

            yield return null;
        }

        yield break;
    }
}