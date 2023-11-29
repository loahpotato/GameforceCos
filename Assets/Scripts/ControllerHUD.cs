using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHUD : MonoBehaviour
{

    [SerializeField] GameObject pickAText;
    [SerializeField] GameObject characterText;
    [SerializeField] GameObject characterButtons;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(StartControllerRoutine());
    }

    private IEnumerator StartControllerRoutine()
    {
        pickAText.transform.localScale = Vector3.zero;
        characterText.transform.localScale = Vector3.zero;
        characterButtons.transform.localScale = Vector3.zero;

        pickAText.transform.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), 0.8f);

        yield return new WaitForSeconds(0.8f);

        characterText.transform.LeanScale(new Vector3(1.0f, 1.0f, 1.0f), 0.8f).setEaseOutBack();

        yield return new WaitForSeconds(0.8f);

        characterButtons.transform.LeanScale(new Vector3(1.15f, 1.15f, 1.15f), 0.8f).setEaseOutBack();

    }
}
