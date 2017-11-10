using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shooter : NetworkBehaviour
{
    public int POWER;
    public GameObject bulletPrefab;
    Transform bodyTr;

    void Start()
    {
        Debug.Assert(bulletPrefab);
        bodyTr = transform.FindChild("body").transform;

        InvokeRepeating("pollShoot", 0, 0.1f);
    }

    void Update() { }

    void pollShoot()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetMouseButton(0))
            CmdShoot();
    }

    [Command] // run by only server
    void CmdShoot()
    {
        //Debug.Log("CmdShoot()");

        var pos = transform.position + transform.forward;

        GameObject bulletObj = Instantiate(bulletPrefab, pos, bodyTr.rotation);
        Debug.Assert(bulletObj);

        NetworkServer.Spawn(bulletObj); // spawn by all client
        RpcAddForceOnAll(bulletObj);
    }

    [ClientRpc]
    void RpcAddForceOnAll(GameObject bulletObj)
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        BulletCore bulletCore = bulletObj.GetComponent<BulletCore>();
        Rigidbody bulletRigid = bulletObj.GetComponent<Rigidbody>();
        Debug.Assert(bulletCore && bulletRigid);

        bulletCore.shooterObj = gameObject;
        bulletRigid.AddForce(rigid.velocity + bodyTr.up * POWER);
    }
}
