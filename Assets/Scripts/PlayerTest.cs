using Mirror;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTest : NetworkBehaviour
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
        //animNumTextMeshPro.text = animNum.ToString();
        /*if (display!=null)
        {
            CmdSendPlayerMessage(display, _New);
            Debug.Log("display");
        }
        else
        {
            Debug.Log("no display");
        }*/
    }

    void Awake()
    {
        //allow all players to run this
        display = GameObject.FindObjectOfType<DisplayManager>().gameObject;
        
    }

    [Command(requiresAuthority = false)]
    public void CmdSendPlayerMessage(GameObject target, int flag)
    {
        Debug.Log("is sending");

        //display.models.transform.GetChild()
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
            /*controllerCanvas = displayRoot.transform.Find("ControllerCanvas").gameObject;
            controllerCanvas.SetActive(true);


            var characterPanel = controllerCanvas.transform.Find("CharacterPanel").gameObject;
            var characterBtns = characterPanel.transform.Find("CharacterBtns").gameObject;
            int childCount = characterBtns.transform.childCount;
            
            for (int i = 0; i < childCount; i++)
            {
                int index = i+1;
                Button button = characterBtns.transform.GetChild(i).GetComponent<Button>();
                button.onClick.AddListener(() => ButtonSetAnim(index));
            }
           
            */
        }
        
    }

    
}
