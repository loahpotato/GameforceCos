using Mirror;
using System;
using UnityEngine;

public struct PlayerTypeMessage : NetworkMessage
{
    public int type;
    public PlayerTypeMessage(int t)
    {
        type = t;
    }
}

public class MyNetworkManager : NetworkManager
{
    public GameObject[] characters;
    public override void OnStartServer()
    {
        base.OnStartServer();

        NetworkServer.RegisterHandler<PlayerTypeMessage>(OnCreateCharacter);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        PlayerTypeMessage msg;
        
        if (NetworkClient.activeHost)
            msg = new PlayerTypeMessage(1);
        else
            msg = new PlayerTypeMessage(0);
        NetworkClient.Send(msg);

        // you can send the message here, or wherever else you want
        /*PlayerTypeMessage msg = new PlayerTypeMessage
        {
            race = Race.Elvish,
            name = "Joe Gaba Gaba",
            hairColor = Color.red,
            eyeColor = Color.green
        };

        NetworkClient.Send(msg);*/
    }

    void OnCreateCharacter(NetworkConnectionToClient conn, PlayerTypeMessage message)
    {
        // playerPrefab is the one assigned in the inspector in Network
        // Manager but you can use different prefabs per race for example
        if (message.type < 0)
        {
            message.type = 0;
        }

        GameObject player;
        Transform startPos = GetStartPosition();

        if (startPos != null)
        {
            playerPrefab = spawnPrefabs[message.type];
            player = Instantiate(playerPrefab, startPos.position, startPos.rotation) as GameObject;
        }
        else
        {
            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        }

        // call this to use this gameobject as the primary controller
        NetworkServer.AddPlayerForConnection(conn, player);
    }


}
