using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHUD : MonoBehaviour
{
    public GameObject panel; 
    public Button buttonHost;
    public TMP_InputField input;
    public TextMeshProUGUI info;
    public Toggle hostToggle;

    public void Start()
    {
        buttonHost.onClick.AddListener(ButtonStart);
        hostToggle.onValueChanged.AddListener(ToggleHost);
    }

    public void ToggleHost(bool value)
    {
        if(hostToggle.isOn)
        {
            input.text = "host";
            input.interactable = false;

            var newColorBlock = input.colors;
            newColorBlock.normalColor = new Color(0.78f, 0.78f, 0.78f, 0.8f);
            input.colors = newColorBlock;
        }
        else
        {
            input.text = "";
            input.interactable = true;
            var newColorBlock = input.colors;
            newColorBlock.normalColor = Color.white;
            input.colors = newColorBlock;
        }
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
        // Here we will dump majority of the canvas UI that may be changed.
        if (!NetworkClient.isConnected && !NetworkServer.active)
        {
            if (NetworkClient.active)
            {
                info.text = "Connecting to " + NetworkManager.singleton.networkAddress + "..";
                StartCoroutine(Connecting());
            }
        }
        else
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
                panel.SetActive(false);
            }
        }
    }

    private IEnumerator Connecting()
    {
        while (NetworkClient.active)
        {
            yield return new WaitForSeconds(1);
        }
        info.text = "Connecting failed. Please check the setting.";

    }
    }
