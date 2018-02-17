using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Player : MonoBehaviour {
    bool isReady = true;

    float dist = 0.3f;

    Camera camera;

    public static Player Create(Transform transform)
    {
        var go = PhotonNetwork.Instantiate("GamePlayer", transform.position, Quaternion.identity, 0);
        return go.GetComponent<Player>();
    }

	void Update () {

        if (isReady)
        {
            if(camera == null)
            {
                this.camera = GameObject.FindObjectOfType<Camera>();
            }

            if (Input.GetKey(KeyCode.A)){
                this.transform.Translate(new Vector3(-1 * dist, 0, 0));
            }

            if (Input.GetKey(KeyCode.D)){
                this.transform.Translate(new Vector3(dist, 0, 0));
            }

            if (Input.GetKey(KeyCode.S)){
                this.transform.Translate(new Vector3(0, 0, -1 * dist));
            }

            if (Input.GetKey(KeyCode.W)){
                this.transform.Translate(new Vector3(0, 0, dist));
            }
            var newPosition = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z - 5);
            this.camera.transform.position = newPosition;
        }

        if (Input.GetMouseButtonDown(0) )
        {
            var syncObj = PhotonNetwork.Instantiate("Cube", this.transform.position, Quaternion.identity, 0);
            var rigidbody = syncObj.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            var rndPow = Random.Range(1.0f, 5.0f);
            rigidbody.AddForce(Vector3.forward * rndPow, ForceMode.Force);

        }

	}
}
