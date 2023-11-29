using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverlay : MonoBehaviour
{
    [SerializeField] GameObject cloud1R;
    [SerializeField] GameObject cloud2R;
    [SerializeField] GameObject cloud3R;
    [SerializeField] GameObject cloud1L;
    [SerializeField] GameObject cloud2L;
    [SerializeField] GameObject cloud3L;
    [SerializeField] GameObject GFLogo;

    public void StartToOverlay()
    {
        StartCoroutine(SwitchRoutine());
    }

    private IEnumerator SwitchRoutine()
    {

        LeanTween.moveLocal(cloud1R, new Vector3(800, -186, 0), 0.6f).setEaseOutBack();
        LeanTween.moveLocal(cloud1L, new Vector3(-950, 169, 0), 0.5f).setEaseOutBack();

        yield return new WaitForSeconds(0.6f);

        LeanTween.moveLocal(cloud2R, new Vector3(950, -27, 0), 0.5f).setEaseOutBack();
        LeanTween.moveLocal(cloud2L, new Vector3(-843, 134, 0), 0.6f).setEaseOutBack();

        yield return new WaitForSeconds(0.6f);

        LeanTween.moveLocal(cloud3R, new Vector3(874, -135, 0), 0.6f).setEaseOutBack();
        LeanTween.moveLocal(cloud3L, new Vector3(-1031, 271, 0), 0.5f).setEaseOutBack();

        yield return new WaitForSeconds(0.4f);

        LeanTween.moveLocal(GFLogo, new Vector3(-450, -380, 0), 0.8f).setEaseOutBack();

    }
}
