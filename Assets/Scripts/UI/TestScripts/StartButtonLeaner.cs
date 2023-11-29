using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonLeaner : MonoBehaviour
{
    private void Start()
    {
        Vector3 initialScale = new Vector3(0f, 0f, 0f);

        transform.localScale = initialScale;

        Vector3 smallerScale = new Vector3(4f, 4f, 4f);
        Vector3 biggerScale = new Vector3(4.5f, 4.5f, 4.5f);

        LeanTween.scale(gameObject, initialScale, 1.15f).setEaseInBack().setOnComplete(() =>
        {
            LeanTween.scale(gameObject, smallerScale, 2f).setEaseInBack().setOnComplete(() =>
            {
                LeanTween.scale(gameObject, biggerScale, 2f).setLoopPingPong();
            });
        });

    }
}
