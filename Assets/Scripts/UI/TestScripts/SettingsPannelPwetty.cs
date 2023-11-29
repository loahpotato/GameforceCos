using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPannelPwetty : MonoBehaviour
{
    [SerializeField] GameObject settingsButton;

    [SerializeField] Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    public void Open()
    {
        animator.enabled = false;

        transform.LeanScale(new Vector3(1.05f, 1.05f, 1.0f), 0.8f);
        settingsButton.transform.LeanScale(Vector3.zero, 0.8f);
    }

    public void Close()
    {
        transform.LeanScale(Vector3.zero, 1f).setEaseInBack();
        settingsButton.transform.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), 0.8f);

        animator.enabled = true;
    }
}
