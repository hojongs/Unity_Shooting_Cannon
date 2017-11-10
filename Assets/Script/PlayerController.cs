using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public int SPEED; // 움직임 속도
    public GameObject camPrefab; // 1인칭 카메라
    public Vector3 camPos, camRot;

    void Start ()
    {
        if (!isLocalPlayer)
            return;

        transform.position = new Vector3(0,1,0);

        // 1인칭 카메라 생성
        if (camPrefab)
        {
            // camObj exists only my scene
            var camObj = Instantiate(camPrefab, transform);
            camObj.transform.localPosition = camPos;
            camObj.transform.rotation = Quaternion.Euler(camRot);
        }
    }
	
	void Update ()
    {
        // if not local player, then return
        if (!isLocalPlayer)
            return;

        // get input
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        // Keyboard: W, S
        transform.Translate(Vector3.forward * v * SPEED * Time.deltaTime);
        // Keyboard: A, D
        transform.Translate(Vector3.right * h * SPEED * Time.deltaTime);
    }
}
