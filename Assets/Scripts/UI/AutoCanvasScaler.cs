using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCanvasScaler : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        CanvasScaler canvasScaler= GetComponent<CanvasScaler>();

        float standard_width = canvasScaler.referenceResolution.x;
        float standard_height = canvasScaler.referenceResolution.y;
        float device_width = Screen.width;
        float device_height = Screen.height;

        float standard_aspect = standard_width / standard_height;
        float device_aspect = device_width / device_height;

        if(device_aspect < standard_aspect)
        {
            canvasScaler.matchWidthOrHeight = 0;
        }
        else
        {
            canvasScaler.matchWidthOrHeight = 1;
        }
    }
}
