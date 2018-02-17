using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using UnityEngine.Assertions;

public class GameEntryPoint : Photon.PunBehaviour
{

    [SerializeField]
    Transform playerEntry;

    bool isReady = false;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings(null);
        PhotonNetwork.autoJoinLobby = true;
        Debug.Log("Start");
	}

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("OnJoinLoby");
    }

    Player player;

    public override void OnJoinedRoom()
    {
        isReady = true;
        Debug.Log("OnJoinedRoom");

        this.player = Player.Create(this.playerEntry);
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        base.OnPhotonRandomJoinFailed(codeAndMsg);
        PhotonNetwork.CreateRoom(null);
    }
    /// <summary>
    /// プレイヤーの退室時に呼ばれます。
    /// </summary>
    /// <param name='otherPlayer'>
    /// プレイヤー情報
    /// </param>
    public override void OnPhotonPlayerDisconnected(PhotonPlayer player) { }

    private void Reset()
    {
        this.playerEntry = GameObject.Find("EnemySpawnPoint").transform;
    }

}
