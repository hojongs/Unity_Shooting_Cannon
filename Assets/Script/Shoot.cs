using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public const int FORCE = 3000;
    public GameObject bulletPrefab;

	void Start ()
    {
        Debug.Assert(bulletPrefab);
	}
	
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
            var rigid = bulletInstance.GetComponent<Rigidbody>();
            Debug.Assert(rigid);
            rigid.AddForce(transform.forward * FORCE);
        }
	}
}
