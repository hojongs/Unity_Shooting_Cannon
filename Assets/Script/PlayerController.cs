using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    //public const int MAP_SIZE = 50;

    [SerializeField]
    int SPEED; // 움직임 속도
    [SerializeField]
    GameObject personalCam; // 1인칭 카메라

    void Start ()
    {
        if (!isLocalPlayer)
            return;

        //transform.position = new Vector3(Random.Range(-MAP_SIZE, MAP_SIZE), 1.8f, Random.Range(-MAP_SIZE, MAP_SIZE));

        // 1인칭 카메라 생성
        if (personalCam)
            Instantiate<GameObject>(personalCam, transform, false);
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
