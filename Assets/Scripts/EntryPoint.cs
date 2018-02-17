/**

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UniRx;
using ExitGames.Client.Photon;


public class EntryPoint : Photon.PunBehaviour
{
    private static readonly string gameVersion = "0.1";

    [SerializeField]
    [Tooltip("ルームの定員")]
    byte MaxPlayersPerRoom = 4;



    void Awake()
    {
        // これつけないと勝手にロビーに入ってしまう
        PN.autoJoinLobby = false;

        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PN.automaticallySyncScene = true;
    }

    // Use this for initialization
    void Start () {
        Connect();
    }
    
    void Connect()
    {
        if (PN.connected)
        {
            PN.JoinRandomRoom();
        }
        else
        {
            PN.ConnectUsingSettings(gameVersion);
        }

    }

    {
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        if (global::PN.room.PlayerCount == 1)
        {
            Debug.Log("We load the 'Room for 1' ");

            // #Critical
            // Load the Room Level.
            global::PN.LoadLevel("RoonNameForOne");
        }
    }


    public override void OnDisconnectedFromPhoton()
    {
        Debug.LogWarning("OnDisconnectedFromPhoton() was called by PUN");
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        global::PN.CreateRoom(null, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null);
    }
}

**/
