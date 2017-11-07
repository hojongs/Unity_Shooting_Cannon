using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shooter : NetworkBehaviour
{
    public const int POWER = 3000;
    public GameObject bulletPrefab;

    void Start()
    {
        Debug.Assert(bulletPrefab);

        InvokeRepeating("pollShoot", 0, 0.1f);
    }

    void Update() { }

    void pollShoot()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetAxis("Fire1") != 0)
            CmdShoot();
    }

    [Command] // run by only server
    void CmdShoot()
    {
        Debug.Log("CmdShoot()");

        var pos = transform.position + transform.forward;

        GameObject bulletObj = Instantiate(bulletPrefab, pos, transform.rotation);
        Debug.Assert(bulletObj);

        NetworkServer.Spawn(bulletObj); // spawn by all client
        RpcAddForceOnAll(bulletObj);
    }

    [ClientRpc]
    void RpcAddForceOnAll(GameObject bulletObj)
    {
        Bullet compoBullet = bulletObj.GetComponent<Bullet>();
        Rigidbody compoRigid = bulletObj.GetComponent<Rigidbody>();
        Debug.Assert(compoBullet && compoRigid);

        compoBullet.shooterObj = gameObject;
        compoRigid.AddForce(transform.forward * POWER);
    }
}
