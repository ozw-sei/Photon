using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Player : Photon.MonoBehaviour {
    float dist = 0.3f;

    Camera camera;

    public static Player Create(Transform transform)
    {
        var go = PhotonNetwork.Instantiate("GamePlayer", transform.position, Quaternion.identity, 0);
        return go.GetComponent<Player>();
    }

    [PunRPC]
    void ShotBullet()
    {
        var shot = Shot.Create(transform.position);
    }

	void Update () {

        if (!photonView.isMine)
        {
            return;
        }
        if(camera == null)
        {
            this.camera = GameObject.FindObjectOfType<Camera>();
        }

        if (Input.GetKey(KeyCode.A)){
            this.transform.Translate(Vector3.right * dist);
        }

        if (Input.GetKey(KeyCode.D)){
            this.transform.Translate(Vector3.left * dist);
        }

        if (Input.GetKey(KeyCode.S)){
            this.transform.Translate(Vector3.back * dist);
        }

        if (Input.GetKey(KeyCode.W)){
            this.transform.Translate(Vector3.forward * dist);
        }
        var newPosition = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z - 5);
        this.camera.transform.localPosition = newPosition;

        if (Input.GetMouseButtonDown(0))
        {
            this.photonView.RPC("ShotBullet", PhotonTargets.All);

        }

	}
}
