using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonLeaner : MonoBehaviour
{
    private void Start()
    {
        Vector3 initialScale = new Vector3(5.0f, 5.0f, 5.0f);

        transform.localScale = initialScale;

        Vector3 smallerScale = new Vector3(2.5f, 2.5f, 2.5f);

        LeanTween.scale(gameObject, initialScale, 1.5f).setEaseInBack().setOnComplete(() =>
        {
            LeanTween.scale(gameObject, smallerScale, 1.5f).setEaseOutBack().setLoopPingPong();
        });
    }
}
