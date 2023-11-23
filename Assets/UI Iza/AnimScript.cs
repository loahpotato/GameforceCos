using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    public Animator animator;
    public string animationTrigger = "ActivateAnimation"; // Change this to the name of your animation trigger
    public GameObject nextPanel;
    private bool isAnimationActive = false;

    void Update()
    {
        // Check for the boolean activation condition (replace this with your own condition)
        if (Input.GetKeyDown(KeyCode.Space)) // Example: Activates animation when the space key is pressed
        {
            StartCoroutine(PlayAnimationAndOpenNextPanel());
        }
    }

    IEnumerator PlayAnimationAndOpenNextPanel()
    {
        // Play the animation
        animator.SetBool(animationTrigger, true);

        // Wait for the animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Open the next panel (replace this with your own logic)
        if (nextPanel != null)
        {
            nextPanel.SetActive(true);
        }
    }
}
