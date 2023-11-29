using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class SettingHUD : MonoBehaviour
{
    public Toggle hostToggle;
    public TMP_InputField input;

    void Start()
    {
        hostToggle.onValueChanged.AddListener(ToggleHost);
    }
    public void ToggleHost(bool value)
    {
        if (hostToggle.isOn)
        {
            input.text = "host";
            input.interactable = false;

            var newColorBlock = input.colors;
            newColorBlock.normalColor = new Color(0.78f, 0.78f, 0.78f, 0.8f);
            input.colors = newColorBlock;
        }
        else
        {
            input.text = "";
            input.interactable = true;
            var newColorBlock = input.colors;
            newColorBlock.normalColor = Color.white;
            input.colors = newColorBlock;
        }
    } 
}
