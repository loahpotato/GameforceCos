using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayManager : NetworkBehaviour
{
    public GameObject flash;
    //public TextMeshProUGUI animNumTextMeshPro;
    public GameObject displayCanvas;
    public GameObject characters;
    public GameObject poses;
    public GameObject animationObject;
    public Animator animator;
    [SyncVar(hook = nameof(OnChracterChanged))]
    public int characterNum;
    [SyncVar(hook = nameof(OnPoseChanged))]
    public int poseNum;

    private float animSwitchTime = .3f;

    void OnChracterChanged(int _Old, int _New)
    {

        if (animationObject != null)
            animationObject.SetActive(false);

        animationObject = characters.transform.GetChild(_New - 1).gameObject;
        animationObject.SetActive(true);
        animator = animationObject.GetComponent<Animator>();
        animator.SetBool("Back", false); //when first time start default, need enter animation
        if (animator.HasState (0, Animator.StringToHash("root_rico_walk")))
        {
            animator.Play("root_rico_walk", 0, 0.7f);
        }
        //animator.SetTrigger("Active");

    }


    void OnPoseChanged(int _Old, int _New)
    {
        if (flash != null)
        {//&& _Old != 0)
            flash.GetComponent<Flash>().CameraFlash();
            StartCoroutine(CoolDown.Wait(0.4f, switchPose));
        }
    }


    void switchPose()
    {
        if (animationObject != null)
            animationObject.SetActive(false);

        if (poseNum == 0) //when go back from one pose to default, no need enter animation
        {
            if (characterNum > 0)
            {
                animationObject = characters.transform.GetChild(characterNum - 1).gameObject;
                animationObject.SetActive(true);
                animator = animationObject.GetComponent<Animator>();
                animator.SetBool("Back", true);
            }

        }
        else
        {
            animationObject = poses.transform.GetChild(poseNum - 1).gameObject;
            animationObject.SetActive(true);
        }
    }


    void Awake()
    {
        var displayRoot = GameObject.Find("Display");
        characters = displayRoot.transform.Find("EnterModel").gameObject;
        poses = displayRoot.transform.Find("PoseModel").gameObject;
        var canvas = displayRoot.transform.Find("CanvasHUD");
        flash = canvas.transform.Find("FlashImage").gameObject;
        //displayCanvas = GameObject.Find("Display").transform.GetChild(1).gameObject;
        //displayCanvas.SetActive(true);
        //animNumTextMeshPro = displayCanvas.GetComponentInChildren<TextMeshProUGUI>();
        //displayCanvas.GetComponent<Canvas>().worldCamera = Camera.main;

        //animNumText = displayCanvas.transform.GetChild(0).gameObject;
        //animNumTextMeshPro = animNumText.GetComponent<TextMeshProUGUI>();
        //animator = displayCanvas.GetComponentInChildren<Animator>();
        /*if (animNumTextMeshPro != null)
        {
            animNumTextMeshPro.text = "find server";
            Debug.Log("find text");
        }
        else
        {
            Debug.Log("no text");
        }*/
    }
    

    public override void OnStartLocalPlayer()
    {
        //sendInfo.display = this;
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 0, 0f);


    }

}
