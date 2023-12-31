using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUp : MonoBehaviour
{
    [SerializeField] GameObject settingsButton;

    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    public void Open()
    {
        transform.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), 0.8f);
        settingsButton.transform.LeanScale(Vector3.zero, 0.8f);
    }

    public void Close()
    {
        transform.LeanScale(Vector3.zero, 1f).setEaseInBack();
        settingsButton.transform.LeanScale(Vector3.one, 0.8f);
    }
}
