using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SendInfo : NetworkBehaviour
{
    public GameObject canvasStatusText;
    public PlayerTest playerScript;
    public DisplayManager display;

    [SyncVar(hook = nameof(OnAnimChanged))]
    public int anim;

    void OnAnimChanged(int _Old, int _New)
    {
        Debug.Log("anim" + anim.ToString());
        //display.animNumTextMeshPro.text = anim.ToString();
    }

    public void ButtonSendMessage(int flag)
    {
        //if (playerScript != null)
            //playerScript.CmdSendPlayerMessage(flag);
    }
}
