using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCore : MonoBehaviour
{
    [HideInInspector]
    public GameObject shooterObj;

    private void Start () { }
	
	private void Update () { }

    private void OnCollisionEnter(Collision col)
    {
        var colObj = col.gameObject;
        var interacter = colObj.GetComponent<PlayerInteracter>();
        if (colObj.CompareTag("Player"))
            interacter.die();
    }
}
