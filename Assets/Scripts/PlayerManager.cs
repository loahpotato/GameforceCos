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
    [SyncVar(hook = nameof(OnCharacterChanged))]
    public int characterNum;
    [SyncVar(hook = nameof(OnPoseChanged))]
    public int poseNum;

    void Awake()
    {
        display = GameObject.FindObjectOfType<DisplayManager>().gameObject;

    }

    public static PlayerManager GetCurrentPlayer()
    {
        
        if (NetworkClient.localPlayer == null)
        {
            Debug.Log("player is null");
            return null;
        }
        var player = NetworkClient.localPlayer.gameObject;
        PlayerManager playerManager = player.GetComponent<PlayerManager>();
        return playerManager;
    }

    public static void SetCharacterAnimation(PlayerManager playerManager, int characterId)
    {
        //PlayerManager playerManager = GetCurrentPlayer();
        if (playerManager != null)
        {
            playerManager.characterNum = characterId;
        }
    }

    public static void SetPoseAnimation(PlayerManager playerManager, int poseId)
    {
        if (playerManager != null)
        {
            playerManager.poseNum = poseId;
        }  
    }

    private void ButtonSetCharacter(int flag)
    {
        characterNum = flag;

    }

    private void ButtonSetPose(int flag)
    {
        poseNum = flag;

    }


    void OnCharacterChanged(int _Old, int _New)
    {
        Debug.Log("pose changed");
        CmdSendCharacterMessage(display, _New);
    }

    void OnPoseChanged(int _Old, int _New)
    {
        Debug.Log("pose changed");
        CmdSendPoseMessage(display, _New);
    }


    [Command(requiresAuthority = false)]
    public void CmdSendCharacterMessage(GameObject target, int flag)
    {
        target.GetComponent<DisplayManager>().characterNum = flag;
    }

    [Command(requiresAuthority = false)]
    public void CmdSendPoseMessage(GameObject target, int flag)
    {
        target.GetComponent<DisplayManager>().poseNum = flag;
    }


    public override void OnStartLocalPlayer()
    {
        characterNum= 0;
        poseNum = 0;
        if (isLocalPlayer)
        {
            var displayRoot = GameObject.Find("Display");
            controllerCanvas = displayRoot.transform.Find("ControllerCanvas").gameObject;

        }
        
    }

    
}
