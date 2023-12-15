using Mirror;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : NetworkBehaviour
{
    private GameObject display;
    public GameObject animButton;
    public GameObject controllerCanvas;

    [SyncVar(hook = nameof(OnAnimChanged))]
    public int animNum;

    private void ButtonSetAnim(int flag)
    {
        animNum = flag;

    }


    void OnAnimChanged(int _Old, int _New)
    {
        Debug.Log("anim changed");
        CmdSendPlayerMessage(display, _New);
    }

    void Awake()
    {
        display = GameObject.FindObjectOfType<DisplayManager>().gameObject;
        
    }

    [Command(requiresAuthority = false)]
    public void CmdSendPlayerMessage(GameObject target, int flag)
    {
        target.GetComponent<DisplayManager>().animNum = flag;
    }


    public override void OnStartLocalPlayer()
    {
        animNum = 0;
        if (isLocalPlayer)
        {
            var displayRoot = GameObject.Find("Display");
            controllerCanvas = displayRoot.transform.Find("ControllerCanvas").gameObject;

        }
        
    }

    
}
