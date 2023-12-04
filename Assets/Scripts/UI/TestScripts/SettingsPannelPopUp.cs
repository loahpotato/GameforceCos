using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPannelPopUp : MonoBehaviour
{
    [SerializeField] GameObject settingsButton;

    [SerializeField] Animator animator;

    public bool isOpened = false;

    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void ToggleButtonPress()
    {
        if (isOpened)
        {
            Close();
        }
        else
        {
            Open();
        }

        isOpened = !isOpened;
    }


    // Update is called once per frame
    public void Open()
    {
        animator.enabled = false;

        transform.LeanScale(new Vector3(0.95f, 0.95f, 0.95f), 0.6f);
        //settingsButton.transform.LeanScale(Vector3.zero, 0.8f);
    }

    public void Close()
    {
        transform.LeanScale(Vector3.zero, 0.8f).setEaseInBack();
        //settingsButton.transform.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), 0.8f);

        animator.enabled = true;
    }
}
