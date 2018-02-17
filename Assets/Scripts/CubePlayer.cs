using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;

public class CubePlayer : Photon.PunBehaviour
{
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

    public override void OnJoinedRoom()
    {
        isReady = true;
        Debug.Log("OnJoinedRoom");
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        base.OnPhotonRandomJoinFailed(codeAndMsg);
        PhotonNetwork.CreateRoom(null);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && isReady)
        {
            var syncObj = PhotonNetwork.Instantiate("Cube", new Vector3(9.0f, 0, 0), Quaternion.identity, 0);
            var rigidbody = syncObj.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            var rndPow = Random.Range(1.0f, 5.0f);
            rigidbody.AddForce(Vector3.left * rndPow, ForceMode.Impulse);

        }    
    }

}
