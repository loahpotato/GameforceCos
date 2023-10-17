using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayManager : NetworkBehaviour
{
    //private SendInfo sendInfo;
    public TextMeshProUGUI animNumTextMeshPro;
    public GameObject displayCanvas;
    public GameObject models;
    public GameObject animationObject;
    public Animator animator;
    [SyncVar(hook = nameof(OnAnimChanged))]
    public int animNum;

    void OnAnimChanged(int _Old, int _New)
    {
        if (animNumTextMeshPro != null)
            animNumTextMeshPro.text = _New.ToString();
        if(animationObject!= null)
            animationObject.SetActive(false);

        animationObject = models.transform.GetChild(_New-1).gameObject;
        animationObject.SetActive(true);
        animator = animationObject.GetComponent<Animator>();
        animator.SetTrigger("Active");
    }


    void Awake()
    {
        var displayRoot = GameObject.Find("Display");
        models = displayRoot.transform.Find("Models").gameObject;
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
        Camera.main.transform.localPosition = new Vector3(0, 0, 0);


    }

    /*void Update()
    {
        if (!isLocalPlayer) { return; }

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 110.0f;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * 4f;

        transform.Rotate(0, moveX, 0);
        transform.Translate(0, 0, moveZ);
    }*/

}
