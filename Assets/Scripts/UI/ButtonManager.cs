using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private TextMeshProUGUI btnText;

    private void Start()
    {
        btnText = this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void CustomOnPressed()
    {

        btnText.color = ColorManager.Instance.color1;
    }

    public void CustomOnReleased()
    {

        btnText.color = ColorManager.Instance.color2;
    }
}
