/**

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExitGames.Client.Photon;


public class GameManager : Photon.PunBehaviour
{

    public void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom()
    {
        PN.LeaveRoom();
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer other)
    {
        if (PN.isMasterClient)
        {
            Debug.Log("OnPhotonPlayerConnected isMasterClient " + PN.isMasterClient); // called before OnPhotonPlayerDisconnected

            LoadArena();
        }
    }

    public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
    {
        if (PN.isMasterClient)
        {
            Debug.Log("OnPhotonPlayerConnected isMasterClient " + PN.isMasterClient); // called before OnPhotonPlayerDisconnected

            LoadArena();
        }
    }


    void LoadArena()
    {
        if (!PN.isMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        Debug.Log("PhotonNetwork : Loading Level : " + PN.room.PlayerCount);
        PN.LoadLevel("Room for " + PN.room.PlayerCount);
    }
}

**/
