using Mirror;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHUD : MonoBehaviour
{
    //public GameObject panel; 
    //public Button butttonHost;
    public TMP_InputField input;
    public TextMeshProUGUI info;
    public GameObject controllerCanvas;
    

    private GameOverlay gameOverlay;
    private GameObject startButton;
    private GameObject settingButton;
    private GameObject background;


    public void Start()
    {
        startButton = this.transform.Find("StartButton").gameObject;
        settingButton = this.transform.Find("Setting").gameObject;
        background = this.transform.Find("Background").gameObject;
        background.SetActive(true);
        gameOverlay = GetComponent<GameOverlay>();
        startButton.GetComponent<Button>().onClick.AddListener(ButtonStart);
        
    }

    public void ButtonStart()
    {

        if (input.text == "")
        {
            NetworkManager.singleton.networkAddress = "localhost";
            NetworkManager.singleton.StartClient();
        }
        else if(input.text == "host")
        {
            NetworkManager.singleton.StartHost();
            //gameOverlay.StartToOverlay();
        }
        else
        {
            NetworkManager.singleton.networkAddress = input.text;
            NetworkManager.singleton.StartClient();
            
        }

        SetupCanvas();


    }


    public void SetupCanvas()
    {
        info.gameObject.SetActive(true);
        // Here we will dump majority of the canvas UI that may be changed.
        if (!NetworkClient.isConnected && !NetworkServer.active)
        {
            if (NetworkClient.active)
            {
                info.text = "Connecting to " + NetworkManager.singleton.networkAddress + "..";
                StartCoroutine(Connecting());
            }
        }

        else if (NetworkClient.isConnected)
        {
            info.text = "Client: address=" + NetworkManager.singleton.networkAddress;
            info.text = "";
            info.gameObject.SetActive(false);
            ButtonHide();
        }
        /*else
        {
            // server / client status message
            //if (NetworkServer.active)
            //{
            //    info.text = "Server: active. Transport: " + Transport.active;
            //    // Note, older mirror versions use: Transport.activeTransport
            //}
            if (NetworkClient.isConnected)
            {
                info.text = "Client: address=" + NetworkManager.singleton.networkAddress;
                ButtonHide();
            }
        }*/
    }

    private IEnumerator Connecting()
    {
        while (NetworkClient.active && !NetworkClient.isConnected)
        {
            yield return new WaitForSeconds(1);
        }
        if (!NetworkClient.isConnected)
            info.text = "Connecting failed. Please check the setting.";
        else
            SetupCanvas();
    }

    public void ButtonHide()
    {
        startButton.GetComponent<Animator>().enabled = false;
        if (NetworkClient.activeHost)
        {
            //gameOverlay.StartToOverlay();
            background.SetActive(false);
            StartCoroutine(HideRoutine());
        }
        else
        {
            StartCoroutine(HideRoutine());
            controllerCanvas.SetActive(true);
            GameObject characterPanel = controllerCanvas.transform.Find("CharacterPanel").gameObject;
            characterPanel.SetActive(true);
        }
    }

    private IEnumerator HideRoutine()
    {
        startButton.transform.LeanScale(new Vector3(0.0f, 0.0f, 0.0f), 0.8f).setEaseInBack();
        settingButton.transform.LeanScale(new Vector3(0.0f, 0.0f, 0.0f), 0.8f).setEaseInBack();

        yield return new WaitForSeconds(.8f);

        startButton.SetActive(false); // Disable the button immediately after scaling
        settingButton.SetActive(false); // Disable the button immediately after scaling

        yield return new WaitForSeconds(.2f);


    }
}
