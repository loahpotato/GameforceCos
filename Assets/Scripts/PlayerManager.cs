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
        //display.animator.SetTrigger("Active");
        //NetworkIdentity displayIdentity = target.GetComponent<NetworkIdentity>();
        //TargetDoMagic(displayIdentity.connectionToClient, damage);

    }


    public override void OnStartLocalPlayer()
    {
        //Camera.main.transform.SetParent(transform);
        //Camera.main.transform.localPosition = new Vector3(0, 0, 0);

        animNum = 0;
        if (isLocalPlayer)
        {
            var displayRoot = GameObject.Find("Display");
            controllerCanvas = displayRoot.transform.Find("ControllerCanvas").gameObject;
            //controllerCanvas.SetActive(true);


            //var poaePanel = controllerCanvas.transform.Find("PosePanel").gameObject;
            //var poseBtns = poaePanel.transform.Find("PoseBtns").gameObject;
            //poseBtns.GetComponent<ButtonPoseHUD>().currentClient = this;
            /*int childCount = poseBtns.transform.childCount;
            
            for (int i = 0; i < childCount; i++)
            {
                int index = i+1;
                Button button = poseBtns.transform.GetChild(i).GetComponent<Button>();
                button.onClick.AddListener(() => ButtonSetAnim(index));
            }
            */

        }
        
    }

    
}