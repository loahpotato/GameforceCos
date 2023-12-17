using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartToCharacter : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject settingsButton;

    [SerializeField] GameObject oldPanel;
    [SerializeField] GameObject newPanel;
    [SerializeField] GameObject newCanvas;

    [SerializeField] GameObject pickAText;
    [SerializeField] GameObject characterText;
    [SerializeField] GameObject characterButtons;

    [SerializeField] Animator animator;

    public void StartToCharacterPanel()
    {
        StartCoroutine(SwitchRoutine());
    }

    private IEnumerator SwitchRoutine()
    {
        //animator = GetComponent<Animator>();
        animator.enabled = false;

        startButton.transform.LeanScale(new Vector3(0.0f, 0.0f, 0.0f), 0.6f).setEaseInBack();
        settingsButton.transform.LeanScale(new Vector3(0.0f, 0.0f, 0.0f), 0.6f).setEaseInBack();

        yield return new WaitForSeconds(.8f);

        startButton.SetActive(false); // Disable the button immediately after scaling
        settingsButton.SetActive(false); // Disable the button immediately after scaling

        yield return new WaitForSeconds(1);

        newCanvas.SetActive(true);
        newPanel.SetActive(true);
        oldPanel.SetActive(false);

        pickAText.transform.localScale = Vector3.zero;
        characterText.transform.localScale = Vector3.zero;
        characterButtons.transform.localScale = Vector3.zero;

        pickAText.transform.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), 0.6f);

        yield return new WaitForSeconds(0.6f);

        characterText.transform.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), 0.6f).setEaseOutBack();

        yield return new WaitForSeconds(0.8f);

        characterButtons.transform.LeanScale(new Vector3(1.15f, 1.15f, 1.15f), 0.8f).setEaseOutBack();

    }
}
